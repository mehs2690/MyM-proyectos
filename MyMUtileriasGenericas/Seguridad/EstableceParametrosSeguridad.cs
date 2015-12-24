using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyMUtileriasGenericas.Seguridad
{
    /// <summary>
    /// Clase que establece los valores 
    /// para las llaves que se ocupan en el 
    /// cifrado de datos
    /// </summary>
    internal class EstableceParametrosSeguridad:IDisposable
    {
        private static string passwordHash = string.Empty, saltKey = string.Empty, viKey = string.Empty;

        public static string PasswordHash
        {
            get
            {
                return passwordHash;
            }
        }

        public static string SaltKey
        {
            get
            {
                return saltKey;
            }
        }

        public static string ViKey
        {
            get
            {
                return viKey;
            }
        }

        /// <summary>
        /// Método que establece las variables de seguridad
        /// </summary>
        public static void EstableceVariablesSeguridad(string passwordHash,string saltKey,string viKey)
        {
            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
            byte[] hashed = null;
            hashed = sha.ComputeHash(Encoding.UTF8.GetBytes(passwordHash));
            EstableceParametrosSeguridad.passwordHash = passwordHash;
            EstableceParametrosSeguridad.saltKey = saltKey;
            EstableceParametrosSeguridad.viKey = viKey;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
