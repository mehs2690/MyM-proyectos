using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using MyMUtileriasGenericas.AccesoDatos;

namespace MyMDatos.CRUD.MySQL.MymInfo
{
    /// <summary>
    /// 
    /// </summary>
    public class FactoryCrudMymInfo
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(FactoryCrudMymInfo));
        private ICrud procesoCrud;
        private string cadenaConexionBd;

        /// <summary>
        /// Obtiene o establece un objeto ICrud 
        /// con su correspondiente instancia
        /// </summary>
        public ICrud Crud
        {
            get { return procesoCrud; }
            set { procesoCrud = value; }
        }

        /// <summary>
        /// Método Constructor
        /// </summary>
        public FactoryCrudMymInfo()
        {

        }

        /// <summary>
        /// Método Constructor
        /// </summary>
        /// <param name="connectionStringBd">cadena de conexión para la BD de la aplicación</param>
        public FactoryCrudMymInfo(string connectionStringBd)
        {
            cadenaConexionBd = connectionStringBd;
        }


    }
}
