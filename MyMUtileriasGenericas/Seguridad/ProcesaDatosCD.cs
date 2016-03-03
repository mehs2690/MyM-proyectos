using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyMUtileriasGenericas.Seguridad
{
    /// <summary>
    /// Clase encargada de procesar la información 
    /// y digirirla para obtener resultados en hash
    /// o cifrados
    /// </summary>
    /// <remarks>
    ///  Desarrollado por: T.P. Mauro Etzael Henaro Sánchez
    ///  Versión: 29.12.2015
    /// </remarks>
    public static class ProcesaDatosCD
    {
        private const string PASSWORDHASH = "P@@Sw0rd";
        private const string SALTKEY = "S@LT_KEY";
        private const string VIKEY = "@1B2c3D4e5F6g7H8";
        private static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("megaloma");
        private static readonly ILog log = LogManager.GetLogger(typeof(ProcesaDatosCD));

        /// <summary>
        /// Método que digiere la cadena de caracteres
        /// y la procesa con MD5
        /// </summary>
        /// <param name="cadenaEntrada">cadena a ser procesada</param>
        /// <param name="formatoUpperCase">establece si el formato del resultado sería en Upper Case</param>
        public static string ObtienePassword(string cadenaEntrada,bool formatoUpperCase)
        {
            string resultado = string.Empty;
            try
            {
                MD5 md5 = System.Security.Cryptography.MD5.Create();
                byte[] obtieneBytesCadenaEntrada = Encoding.UTF8.GetBytes(cadenaEntrada);
                byte[] hash = md5.ComputeHash(obtieneBytesCadenaEntrada);

                StringBuilder cadena = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    if (formatoUpperCase)
                        cadena.Append(hash[i].ToString("X2"));
                    else
                        cadena.Append(hash[i].ToString("x2"));
                }
                resultado = cadena.ToString();
            }
            catch (Exception e)
            {
                log.Error("error en ObtienePassword.", e);
                throw e;
            }
            return resultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textoOriginal"></param>
        /// <returns></returns>
        public static string CifraTextoEnDES(string textoOriginal)
        {
            log.Info("Ingresa a CifraTextoEnDES");
            string resultado = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(textoOriginal))
                    throw new ArgumentNullException("El texto acifrar no puede ser nulo o vacío");
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                MemoryStream memory = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memory, 
                                                             des.CreateEncryptor(bytes, bytes), 
                                                             CryptoStreamMode.Write);
                StreamWriter writer = new StreamWriter(cryptoStream);
                writer.Write(textoOriginal);
                writer.Flush();
                cryptoStream.FlushFinalBlock();
                writer.Flush();
                resultado = Convert.ToBase64String(memory.GetBuffer(), 0, (int)memory.Length);
            }
            catch (Exception e)
            {
                log.Error("error en CifraTextoEnDES. ", e);
                throw e;
            }
            log.Info(string.Format("resultado del método CifraTextoEnDES: {0}", resultado));
            log.Info("Termina el método CifraTextoEnDES");
            return resultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textoOriginal"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string CifraTextoEnDES(string textoOriginal,string password)
        {
            string resultado = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(textoOriginal))
                    throw new ArgumentNullException("El texto a cifrar no puede ser nulo o vacío");
                if (string.IsNullOrEmpty(password))
                    throw new ArgumentNullException("El password para cifrar no puede ser nulo o vacío");
                bytes = ASCIIEncoding.ASCII.GetBytes(password);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                MemoryStream memory = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memory,
                                                             des.CreateEncryptor(bytes, bytes),
                                                             CryptoStreamMode.Write);
                StreamWriter writer = new StreamWriter(cryptoStream);
                writer.Write(textoOriginal);
                writer.Flush();
                cryptoStream.FlushFinalBlock();
                writer.Flush();
                resultado = Convert.ToBase64String(memory.GetBuffer(), 0, (int)memory.Length);
            }
            catch (Exception e)
            {
                log.Error("error en CifraTextoEnDES.", e);
                throw e;
            }
            return resultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textoCifrado"></param>
        /// <returns></returns>
        public static string DescifraTextoDES(string textoCifrado)
        {
            string resultado = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(textoCifrado))
                    throw new ArgumentNullException("El texto a descifrar no puede ser nulo o vacío");
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                MemoryStream memory = new MemoryStream(Convert.FromBase64String(textoCifrado));
                CryptoStream cryptoStream = new CryptoStream(memory,
                                                             des.CreateDecryptor(bytes, bytes),
                                                             CryptoStreamMode.Read);
                StreamReader reader = new StreamReader(cryptoStream);
                resultado = reader.ReadToEnd();
            }
            catch (Exception e)
            {
                log.Error("error en DescifraTextoDES.", e);
                throw e;
            }
            return resultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textoCifrado"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string DescifraTextoDES(string textoCifrado,string password)
        {
            string resultado = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(textoCifrado))
                    throw new ArgumentNullException("El texto a descifrar no puede ser nulo o vacío");
                if (string.IsNullOrEmpty(password))
                    throw new ArgumentNullException("El password para descifrar no puede ser nulo o vacío");
                bytes = ASCIIEncoding.ASCII.GetBytes(password);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                MemoryStream memory = new MemoryStream(Convert.FromBase64String(textoCifrado));
                CryptoStream cryptoStream = new CryptoStream(memory,
                                                             des.CreateDecryptor(bytes, bytes),
                                                             CryptoStreamMode.Read);
                StreamReader reader = new StreamReader(cryptoStream);
                resultado = reader.ReadToEnd();
            }
            catch (Exception e)
            {
                log.Error("error en DescifraTextoDES.", e);
                throw e;
            }
            return resultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sCipherText"></param>
        /// <returns></returns>
        public static string FormatoHexadecimal(string sCipherText)
        {
            string resultado = string.Empty;
            try
            {
                char[] letras = sCipherText.ToCharArray();
                StringBuilder sb = new StringBuilder();
                foreach (char item in letras)
                {
                    int iValorNumerico = Convert.ToInt32(item);
                    string sHexaSalida = string.Format("{0:X}", iValorNumerico);
                    sb.Append(sHexaSalida);
                }
                resultado = sb.ToString();            }
            catch (Exception e)
            {
                log.Error("error en FormatoHexadecimal.", e);
                throw e;
            }
            return resultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="textoHexadecimal"></param>
        /// <returns></returns>
        public static string DesformateaHexadecimal(string textoHexadecimal)
        {
            string resultado = string.Empty;
            try
            {
                char[] numeros = textoHexadecimal.ToCharArray();
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < numeros.Length; i++)
                {
                    int valor = 0;
                    if ((i + 1) < numeros.Length)
                    {
                        valor = Convert.ToInt32(string.Format("{0}{1}",
                                                   numeros[i].ToString(),
                                                   numeros[i + 1].ToString()), 16);
                        sb.Append((char)valor);
                    }
                    i++;
                }
                resultado = sb.ToString();
            }
            catch (Exception e)
            {
                log.Error("error en DesformateaHexadecimal.", e);
                throw e;
            }
            return resultado;
        }
    }
}
