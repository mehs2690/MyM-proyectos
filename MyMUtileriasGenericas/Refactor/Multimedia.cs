using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.Configuration;

namespace MyMUtileriasGenericas.Refactor
{
    /// <summary>
    /// Clase encargada de procesar peticiones 
    /// de tipo multimedia, tales como correo electrónico
    /// compresión de archivos
    /// </summary>
    /// <remarks>
    ///  Desarrollado por: T.P. Mauro Etzael Henaro Sánchez
    ///  Version: 12.01.2015
    /// </remarks>
    public static class Multimedia
    {
        /// <summary>
        /// Direccion del servicio SMTP
        /// </summary>
        public static string smtpAdress = string.Empty;
        /// <summary>
        /// Número del puerto
        /// </summary>
        public static int portNumber = 0;
        /// <summary>
        /// Establece si se utiliza SSL
        /// </summary>
        public static bool enableSSL = true;
        private static readonly ILog log = LogManager.GetLogger(typeof(Multimedia));

        /// <summary>
        /// Método que envia correos electrónicos
        /// </summary>
        /// <param name="correoDe">correo electrónico remitente</param>
        /// <param name="correoPara">lista de correos electrónicos receptores</param>
        /// <param name="password">clave de acceso del correo remitente</param>
        /// <param name="asunto">describe el asunto del correo</param>
        /// <param name="cuerpoCorreo">describe el contenido del correo</param>
        /// <param name="archivosAdjuntos">lista de rutas de archivos adjuntos en el correo</param>
        public static void EnviaCorreo(string correoDe,List<string> correoPara,string password,string asunto,string cuerpoCorreo,params string[] archivosAdjuntos)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(correoDe);
                    foreach (string correoDestino in correoPara)
                        mail.To.Add(correoDestino);
                    mail.Subject = asunto;
                    mail.Body = cuerpoCorreo;
                    mail.IsBodyHtml = true;
                    foreach (string archivo in archivosAdjuntos)
                        mail.Attachments.Add(new Attachment(archivo));
                    using (SmtpClient smtp = new SmtpClient(smtpAdress, portNumber))
                    {
                        smtp.Credentials = new NetworkCredential(correoDe, password);
                        smtp.EnableSsl = enableSSL;
                        smtp.Send(mail);
                    }
                }
            }
            catch (Exception e)
            {
                log.Error("Error en el método EnviaCorreo.", e);
                throw new Exception("Error al enviar el correo electrónico: " + e.Message);
            }
        }

        /// <summary>
        /// Método que comprime archivos
        /// </summary>
        /// <param name="archivos"></param>
        public static string ComprimeArchivos(params string[] archivos)
        {
            string rutaArchivoComprimido = string.Empty;
            try
            {
                rutaArchivoComprimido = ConfigurationManager.AppSettings["RutaTempZip"].ToString();
                using (ZipArchive modFile = ZipFile.Open(string.Empty, ZipArchiveMode.Create))
                {
                    foreach (string archivo in archivos)
                    {
                        modFile.CreateEntryFromFile(archivo, string.Empty,CompressionLevel.Optimal);
                    }
                }
            }
            catch (Exception e)
            {
                log.Error("Error en el método ComprimeArchivos.", e);
                throw e;
            }

            return rutaArchivoComprimido;
        }
    }
}
