using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using MyMUtileriasGenericas.AccesoDatos;
using MyMDatos.ORM.ForMySQL;

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
        private mymEntities entidad;

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

        /// <summary>
        /// Método Constructor
        /// </summary>
        /// <param name="entidad"></param>
        public FactoryCrudMymInfo(mymEntities entidad)
        {
            this.entidad = entidad;
        }

        #region FÁBRICA PARA LA ENTIDAD RELACIONAL mym_personas

        /// <summary>
        /// Crea una instancia de ImplCrudMymPersona
        /// para ser usada en consultas y eliminaciones
        /// </summary>
        /// <param name="id">identificador GUID de la persona</param>
        public void CreaImplCrudMymPersona(Guid id)
        {
            procesoCrud = new ImplCrudMymPersona(id, entidad);
        }

        /// <summary>
        /// Crea una instancia de ImplCrudMymPersona
        /// para realizar ediciones
        /// </summary>
        /// <param name="persona">objteo de tipo persona</param>
        public void CreaImplCrudMymPersona(mym_persona persona)
        {
            procesoCrud = new ImplCrudMymPersona(persona, entidad);
        }

        /// <summary>
        /// Obsoleto por el momento
        /// </summary>
        /// <param name="id">identificador GUID de la persona</param>
        /// <param name="stringConnection">cadena de conexión en la BD</param>
        public void CreaImplCrudMymPersona(Guid id,string stringConnection)
        {
            procesoCrud = new ImplCrudMymPersona(id, stringConnection);
        }

        #endregion FÁBRICA PARA LA ENTIDAD RELACIONAL mym_personas
    }
}
