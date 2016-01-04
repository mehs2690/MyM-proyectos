using MyMUtileriasGenericas.Seguridad;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMUtileriasGenericas.AccesoDatos
{
    /// <summary>
    /// Clase estática encargada de conectar a una BD
    /// </summary>
    /// <remarks>
    /// Creado por: T.P. Mauro Etzael Henaro Sánchez
    /// Version: 23.12.2015
    /// </remarks>
    public static class Conexion
    {
        private static string cadena = string.Empty, server = string.Empty,cadenaConfig = string.Empty;
        private static string bd=string.Empty,user=string.Empty,pwd=string.Empty;

        /// <summary>
        /// Obtiene la cadena de conexión de prueba.
        /// 
        /// IMPORTANTE: los valores de esta cadena conexión 
        /// son vulnerables en los temas de seguridad
        /// </summary>
        /// <returns>cadena de conexión al BD origen en MSSQL</returns>
        public static string ObtieneCadenaConexion()
        {
            return cadenaConfig = ConfigurationManager.ConnectionStrings["CadenaPrueba"].ConnectionString;
        }

        /// <summary>
        /// Método que obtiene la cadena de conexión 
        /// de la BD específica.
        /// </summary>
        /// <param name="llave">llave (key) que identifica la cadena de conexión a usar</param>
        /// <param name="cifrado">establece si los valores vienen cifrados o no.</param>
        /// <returns>cadena de conexión armada</returns>
        public static string ObtieneCadenaConexion(string llave,bool cifrado)
        {
            try
            {
                cadenaConfig = ConfigurationManager.ConnectionStrings[llave].ConnectionString;
                if (cifrado)
                {
                    server = ProcesaDatosCD.DescifraTextoDES(ConfigurationManager.AppSettings["Server"]);
                    bd = ProcesaDatosCD.DescifraTextoDES(ConfigurationManager.AppSettings["Bd"]);
                    user = ProcesaDatosCD.DescifraTextoDES(ConfigurationManager.AppSettings["Usr"]);
                    pwd = ProcesaDatosCD.DescifraTextoDES(ConfigurationManager.AppSettings["Pwd"]);
                }
                else
                {
                    server = ConfigurationManager.AppSettings["Server"];
                    bd = ConfigurationManager.AppSettings["Bd"];
                    user = ConfigurationManager.AppSettings["Usr"];
                    pwd = ConfigurationManager.AppSettings["Pwd"];
                }
                cadena = cadenaConfig.Replace("{Server}", server)
                                       .Replace("{BD}", bd)
                                       .Replace("{Usr}", user)
                                       .Replace("{Pwd}", pwd);
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Error al obtener la cadena de conexión: {0}", e.Message));
            }
            return cadena;
        }

        /// <summary>
        /// Método que obtiene la cadena de conexión 
        /// de la BD específica.
        /// </summary>
        /// <param name="llave">llave (key) que identifica la cadena de conexión a usar</param>
        /// <param name="cifrado">establece si los valores vienen cifrados o no.</param>
        /// <param name="password">clave para descifrar la información si está cifrada</param>
        /// <returns>cadena de conexión armada</returns>
        public static string ObtieneCadenaConexion(string llave, bool cifrado,string password)
        {
            try
            {
                cadenaConfig = ConfigurationManager.ConnectionStrings[llave].ConnectionString;
                if (cifrado)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        server = ProcesaDatosCD.DescifraTextoDES(ConfigurationManager.AppSettings["Server"], password);
                        bd = ProcesaDatosCD.DescifraTextoDES(ConfigurationManager.AppSettings["Bd"], password);
                        user = ProcesaDatosCD.DescifraTextoDES(ConfigurationManager.AppSettings["Usr"], password);
                        pwd = ProcesaDatosCD.DescifraTextoDES(ConfigurationManager.AppSettings["Pwd"], password);
                    }
                    else
                        throw new ArgumentNullException("el password no puedo ser nulo o vacío");
                }
                else
                {
                    server = ConfigurationManager.AppSettings["Server"];
                    bd = ConfigurationManager.AppSettings["Bd"];
                    user = ConfigurationManager.AppSettings["Usr"];
                    pwd = ConfigurationManager.AppSettings["Pwd"];
                }
                cadena = cadenaConfig.Replace("{Server}", server)
                                       .Replace("{BD}", bd)
                                       .Replace("{Usr}", user)
                                       .Replace("{Pwd}", pwd);
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Error al obtener la cadena de conexión: {0}", e.Message));
            }
            return cadena;
        }

        /// <summary>
        /// Método que construye la cadena de 
        /// conexión de la BD correspondiente
        /// </summary>
        /// <param name="cadenaConexion">key de la cadena de conexión a armar</param>
        /// <param name="server">nombre de la key del servidor</param>
        /// <param name="bd">nombre de la key de la BD</param>
        /// <param name="user">nombre de la key del user</param>
        /// <param name="pwd">nombre de la key del password</param>
        /// <param name="cifrado">establece si los valores están cifrados</param>
        /// <returns>cadena de conexión armada</returns>
        public static string ObtieneCadenaConexion(string cadenaConexion,string server,string bd,string user,string pwd,bool cifrado)
        {
            try
            {
                cadenaConfig = ConfigurationManager.ConnectionStrings[cadenaConexion].ConnectionString;
                if (cifrado)
                {
                    Conexion.server = ProcesaDatosCD.DescifraTextoDES(ConfigurationManager.AppSettings[server]);
                    Conexion.bd = ProcesaDatosCD.DescifraTextoDES(ConfigurationManager.AppSettings[bd]);
                    Conexion.user = ProcesaDatosCD.DescifraTextoDES(ConfigurationManager.AppSettings[user]);
                    Conexion.pwd = ProcesaDatosCD.DescifraTextoDES(ConfigurationManager.AppSettings[pwd]);
                }
                else
                {
                    Conexion.server = ConfigurationManager.AppSettings[server];
                    Conexion.bd = ConfigurationManager.AppSettings[bd];
                    Conexion.user = ConfigurationManager.AppSettings[user];
                    Conexion.pwd = ConfigurationManager.AppSettings[pwd];
                }
                cadena = cadenaConfig.Replace("{Server}", Conexion.server)
                                       .Replace("{BD}", Conexion.bd)
                                       .Replace("{Usr}", Conexion.user)
                                       .Replace("{Pwd}", Conexion.pwd);
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Error al obtener la cadena de conexión: {0}", e.Message));
            }
            return cadena;
        }

        /// <summary>
        /// Método que construye la cadena de 
        /// conexión de la BD correspondiente
        /// </summary>
        /// <param name="cadenaConexion">key de la cadena de conexión a armar</param>
        /// <param name="server">nombre de la key del servidor</param>
        /// <param name="bd">nombre de la key de la BD</param>
        /// <param name="user">nombre de la key del user</param>
        /// <param name="pwd">nombre de la key del password</param>
        /// <param name="cifrado">establece si los valores están cifrados</param>
        /// <param name="password">clave para descifrar la información si está cifrada</param>
        /// <returns>cadena de conexión armada</returns>
        public static string ObtieneCadenaConexion(string cadenaConexion, string server, string bd, string user, string pwd, bool cifrado,string password)
        {
            try
            {
                cadenaConfig = ConfigurationManager.ConnectionStrings[cadenaConexion].ConnectionString;
                if (cifrado)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        Conexion.server = ProcesaDatosCD.DescifraTextoDES(ConfigurationManager.AppSettings[server], password);
                        Conexion.bd = ProcesaDatosCD.DescifraTextoDES(ConfigurationManager.AppSettings[bd], password);
                        Conexion.user = ProcesaDatosCD.DescifraTextoDES(ConfigurationManager.AppSettings[user], password);
                        Conexion.pwd = ProcesaDatosCD.DescifraTextoDES(ConfigurationManager.AppSettings[pwd], password);
                    }
                    else
                        throw new ArgumentNullException("el password no puedo ser nulo o vacío");
                }
                else
                {
                    Conexion.server = ConfigurationManager.AppSettings[server];
                    Conexion.bd = ConfigurationManager.AppSettings[bd];
                    Conexion.user = ConfigurationManager.AppSettings[user];
                    Conexion.pwd = ConfigurationManager.AppSettings[pwd];
                }
                cadena = cadenaConfig.Replace("{Server}", Conexion.server)
                                       .Replace("{BD}", Conexion.bd)
                                       .Replace("{Usr}", Conexion.user)
                                       .Replace("{Pwd}", Conexion.pwd);
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Error al obtener la cadena de conexión: {0}", e.Message));
            }
            return cadena;
        }

        /// <summary>
        /// Método que arma la cadena conexión con la 
        /// estructura de Entity FrameWork
        /// </summary>
        /// <param name="cadenaConexion">llave de la cadena de conexión a usar</param>
        /// <param name="cifrado">establece si los valores están cifrados</param>
        /// <param name="tipoBD">tipo de de origen de BD</param>
        /// <returns>cadena de conexión armada</returns>
        public static string ObtieneCadenaEF(string cadenaConexion,bool cifrado,enmTipoBd tipoBD)
        {
            EntityConnectionStringBuilder ecb = new EntityConnectionStringBuilder();
            try
            {
                cadenaConfig = ObtieneCadenaConexion(cadenaConexion, cifrado);
                SqlConnectionStringBuilder mssqlsbc;
                MySqlConnectionStringBuilder mysqlsbc;
                switch (tipoBD)
                {
                    case enmTipoBd.MSSQL:
                        ecb.Metadata = "res://*/MSSQL.MymConfigEf.BDMym.csdl|res://*/MSSQL.MymConfigEf.BDMym.ssdl|res://*/MSSQL.MymConfigEf.BDMym.msl";
                        ecb.Provider = "System.Data.SqlClient";
                        mssqlsbc = new SqlConnectionStringBuilder(cadenaConfig);
                        ecb.ProviderConnectionString = mssqlsbc.ConnectionString;
                        break;
                    case enmTipoBd.ORACLE:
                        throw new NotImplementedException("las clases para la BD Oracle aún no han sido implementados");
                    case enmTipoBd.MYSQL:
                        ecb.Metadata = "res://*/MySQL.MymEf.EventoSocial.csdl|res://*/MySQL.MymEf.EventoSocial.ssdl|res://*/MySQL.MymEf.EventoSocial.msl";
                        ecb.Provider = "MySql.Data.MySqlClient";
                        mysqlsbc = new MySqlConnectionStringBuilder(cadenaConfig);
                        ecb.ProviderConnectionString = mysqlsbc.ConnectionString;
                        break;
                    case enmTipoBd.POSTGRE:
                        throw new NotImplementedException("las clases para la BD PostgreSQL aún no han sido implementados");
                    case enmTipoBd.MSACCESS:
                        throw new NotImplementedException("las clases para la BD Access aún no han sido implementados");
                    case enmTipoBd.MONGOBD:
                        throw new NotImplementedException("las clases para la BD Mongo aún no han sido implementados");
                    default:
                        ecb.Metadata = "res://*/MSSQL.MymConfigEf.BDMym.csdl|res://*/MSSQL.MymConfigEf.BDMym.ssdl|res://*/MSSQL.MymConfigEf.BDMym.msl";
                        ecb.Provider = "System.Data.SqlClient";
                        mssqlsbc = new SqlConnectionStringBuilder(cadenaConfig);
                        ecb.ProviderConnectionString = mssqlsbc.ConnectionString;
                        break;
                }
                cadena = ecb.ConnectionString;
            }
            catch (Exception e)
            {
                throw e;
            }
            return cadena;
        }
    }
}
