using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyMUtileriasGenericas.Seguridad
{
    /// <summary>
    /// Clase encargada de gestionar 
    /// la creación y manipulación de 
    /// un token para acceso a servicios
    /// REST API o aplicaciones web
    /// </summary>
    /// <remarks>
    ///     T.P. Mauro Etzael Henaro Sánchez
    ///     20.04.2016
    ///     Basado en:
    ///     http://www.primaryobjects.com/2015/05/08/token-based-authentication-for-web-service-apis-in-c-mvc-net/
    /// </remarks>
    public class TokenGenerator
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(TokenGenerator));
        private const string _ALGORITMO= "HmacSHA256";
        private const string _SALT = "@1B2c3D4e5F6g7H8";
        private const int _EXPIRATIONMINS = 20;
        private enum digestToken { HASH = 0, USERNAME = 1, TICKS = 2 }

        /// <summary>
        /// Obtiene la IP del cliente que intenta
        /// obtener acceso a la aplicación.
        /// </summary>
        /// <param name="request">Objeto Request de las peticiones</param>
        /// <returns>string con el valor de la IP</returns>
        public static string GetIP(HttpRequestBase request)
        {
            string ip = request.Headers["X-Forwarded-For"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = request.UserHostAddress;
            }
            return ip;
        }

        /// <summary>
        /// Obtiene un token para el inicio de sesió para una aplicación
        /// </summary>
        /// <param name="username">nombre de usuario</param>
        /// <param name="password">password </param>
        /// <param name="ip">ip máquina cliente</param>
        /// <param name="userAgent">agente de usuario</param>
        /// <param name="ticks">fecha de inicio de sesión en formato long</param>
        /// <returns>token procesado</returns>
        public static string GenerateToken(string username,string password,string ip,string userAgent,long ticks)
        {
            string hash = string.Join(":", new string[] { username, password, ip, userAgent, ticks.ToString() });
            string hashLeft = string.Empty;
            string hashRight = string.Empty;
            using (HMAC hmac = HMAC.Create(_ALGORITMO))
            {
                hmac.Key = Encoding.UTF8.GetBytes(GetHashedPassword(password));
                hmac.ComputeHash(Encoding.UTF8.GetBytes(hash));
                hashLeft = Convert.ToBase64String(hmac.Hash);
                hashRight = string.Join(":", new string[] { username, ticks.ToString() });
            }
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Join(":", hashLeft, hashRight)));
        }

        /// <summary>
        /// Obtiene el hash del password
        /// </summary>
        /// <param name="password">cadena a cifrar</param>
        /// <returns>password cifrado</returns>
        public static string GetHashedPassword(string password)
        {
            string key = string.Join(":", new string[] { password, _SALT });
            using (HMAC hmac=HMACSHA256.Create(_ALGORITMO))
            {
                hmac.Key = Encoding.UTF8.GetBytes(_SALT);
                hmac.ComputeHash(Encoding.UTF8.GetBytes(key));
                return Convert.ToBase64String(hmac.Hash);
            }
        }

        /// <summary>
        /// Valida si el token obtenido es válido para 
        /// la sesión
        /// </summary>
        /// <param name="token">token de autenticación</param>
        /// <param name="ip">ip de la máquina cliente</param>
        /// <param name="userAgent">agente de usuario</param>
        /// <param name="userFromBd">usuario a validar obtenido desde la Bd</param>
        /// <param name="passFromBd">password obtenido desde la Bd</param>
        /// <returns>True o False</returns>
        public static bool IsTokenValid(string token,string ip,string userAgent,string userFromBd,string passFromBd)
        {
            bool valido = false;
            string hash, username;
            long ticks;
            try
            {
                string key = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                string[] parts = key.Split(new char[] { ':' });
                if (parts.Length == 3)
                {
                    hash = parts[(int)digestToken.HASH];
                    username = parts[(int)digestToken.USERNAME];
                    ticks = long.Parse(parts[(int)digestToken.TICKS]);
                    DateTime timeStamp = new DateTime(ticks);
                    bool expired = Math.Abs((DateTime.UtcNow - timeStamp).TotalMinutes) > _EXPIRATIONMINS;
                    if (!expired)
                    {
                        if (username == userFromBd)
                        {
                            string computedToken = GenerateToken(username, passFromBd, ip, userAgent, ticks);
                            valido = (token == computedToken);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                log.Error("Error al validar el token: ", e);
                throw e;
            }
            return valido;
        }
    }
}
