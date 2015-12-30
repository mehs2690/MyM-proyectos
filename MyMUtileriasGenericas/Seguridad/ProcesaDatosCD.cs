using System;
using System.Collections.Generic;
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
                throw e;
            }
            return resultado;
        }
    }
}
