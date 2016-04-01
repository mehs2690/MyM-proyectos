using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMUtileriasGenericas.AccesoDatos
{
    /// <summary>
    /// Clase estática encargada de leer 
    /// archivos planos txt
    /// </summary>
    /// <remarks>
    ///     creado por: T.P. Mauro Etzael Henaro Sánchez
    ///     version 29.12.2015
    /// </remarks>
    public static class LecturaArchivos
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(LecturaArchivos));

        /// <summary>
        /// Método que lee el contenido de un 
        /// archivo plano línea por línea
        /// </summary>
        /// <param name="rutaArchivo">ruta del archivo</param>
        /// <returns>Lista de strings con el contenido del archivo</returns>
        public static List<string> LeeArchivoLineaPorLinea(string rutaArchivo)
        {
            log.Info("Ingresa a LeeArchivoLineaPorLinea");
            log.Info("Ruta de archivo proporcionada:");
            log.Info(rutaArchivo);
            List<string> lineas = new List<string>();
            try
            {
                string[] lines = File.ReadAllLines(rutaArchivo);
                foreach (string item in lines)
                {
                    lineas.Add(item);
                }
            }
            catch (Exception e)
            {
                log.Error("error en LeeArchivoLineaPorLinea.", e);
                throw e;
            }
            return lineas;
        }

        /// <summary>
        /// método encargado de crear archivos planos
        /// </summary>
        /// <param name="contenido"></param>
        /// <param name="ruta"></param>
        /// <param name="nombreArchivo"></param>
        /// <param name="extensionArchivo"></param>
        /// <returns></returns>
        public static string CreaArchivo(List<string> contenido,string ruta,string nombreArchivo,string extensionArchivo)
        {
            log.Info("Ingresa al método CreaArchivo");
            log.Info(string.Format("contenido: {0}; nombre del archivo: {1}; extensión del archivo: {2};",
                                    contenido,
                                    nombreArchivo,
                                    extensionArchivo));
            string rutaArchivo = string.Empty;
            try
            {
                foreach (string cadena in contenido)
                {

                }
            }
            catch (Exception e)
            {
                log.Error("error al crear un archivo", e);
                throw e;
            }
            return rutaArchivo;
        }
    }
}
