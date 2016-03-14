using log4net;
using MyMDatos.ORM.ForMySQL;
using MyMUtileriasGenericas.AccesoDatos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyMDatos.CRUD.MySQL.MymInfo
{
    internal class ImplCrudMymPersona : CrudAbstractMymInfo, ICrud
    {
        private mym_persona Persona;
        private List<mym_persona> Personas;

        /// <summary>
        /// Obtiene o establece el valor de la 
        /// colección de tipo Persona.
        /// </summary>
        public List<mym_persona> personas
        {
            get { return Personas; }
            set { Personas = value; }
        }

        /// <summary>
        /// Obtiene o establece el valor del objeto 
        /// de tipo persona
        /// </summary>
        public mym_persona persona
        {
            get { return Persona; }
            set { Persona = value; }
        }

        private static readonly ILog log = LogManager.GetLogger(typeof(ImplCrudMymPersona));

        #region CONSTRUCTORES

        /// <summary>
        /// Método Constructor
        /// </summary>
        /// <param name="idPersona">identificador GUID de una persona</param>
        /// <param name="Conexion">Cadena de conexión</param>
        public ImplCrudMymPersona(Guid idPersona,string Conexion)
        {
            idEntidadRelacional = idPersona;
            CadenaConexionBd = Conexion;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPersona">identificador GUID de la persona</param>
        /// <param name="entidad">objeto entidad de la BD</param>
        public ImplCrudMymPersona(Guid idPersona,mymEntities entidad)
        {
            idEntidadRelacional = idPersona;
            base.entidad = entidad;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="persona"></param>
        /// <param name="entidad"></param>
        public ImplCrudMymPersona(mym_persona persona,mymEntities entidad)
        {
            Persona = persona;
            base.entidad = entidad;
        }

        #endregion CONSTRUCTORES

        #region MÉTODOS PÚBLICOS

        /// <summary>
        /// Actualiza un registro de tipo Persona
        /// </summary>
        public void ActualizaRegistro()
        {
            try
            {
                if (idEntidadRelacional == null)
                    throw new ArgumentNullException("no se ha inicializado el valor del GUID a consultar");
                else if (Persona == null)
                    throw new ArgumentNullException("no se ha incializado el objeto con los valores a modificar");
                var personaUpdate = Persona;
                ObtieneRegistroPorId();
                Type tipoObjetoPersona = Persona.GetType();
                Type tipoUpdatePersona = personaUpdate.GetType();
                foreach (PropertyInfo propiedad in tipoObjetoPersona.GetProperties())
                {
                    if (!(propiedad.Name == "id"))
                    {
                        PropertyInfo perInfo = tipoObjetoPersona.GetProperty(propiedad.Name);
                        if (perInfo != null)
                        {
                            var valor = propiedad.GetValue(Persona, null);
                            if (valor != null)
                            {
                                switch (perInfo.PropertyType.Name)
                                {
                                    case "Nullable`1":
                                        perInfo.SetValue(Persona, Convert.ChangeType(valor, perInfo.PropertyType.GetGenericArguments()[0]), null);
                                        break;
                                    default:
                                        perInfo.SetValue(Persona, Convert.ChangeType(valor, perInfo.PropertyType.GetGenericArguments()[0]), null);
                                        break;
                                }
                            }
                        }
                    }
                }
                entidad.SaveChanges();
            }
            catch (Exception e)
            {
                log.Error(string.Format("Error al actualizar los datos del registro con GUID: {0}", Persona.id), e);
                throw e;
            }
        }

        /// <summary>
        /// Consulta un registro persona por su GUID
        /// </summary>
        public void ConsultaSimple()
        {
            ObtieneRegistroPorId();
        }

        /// <summary>
        /// Consulta todos los registros de la entidad
        /// relacional mym_persona
        /// </summary>
        public void ConsultaTodo()
        {
            try
            {
                this.Personas = (from p in entidad.mym_persona
                                 select p).ToList();
            }
            catch (Exception e)
            {
                log.Error("Error al consultar los registros de personas. ", e);
                throw e;
            }
        }

        /// <summary>
        /// Elimina un registro de tipo persona
        /// </summary>
        public void EliminaRegistro()
        {
            var personaAEliminar = entidad.mym_persona.Where(p => p.id == idEntidadRelacional).SingleOrDefault();
            if (personaAEliminar != null)
            {
                entidad.mym_persona.Remove(personaAEliminar);
                entidad.SaveChanges();
            }
            else
                throw new InvalidOperationException("La persona con el id ingresado no existe en la Base de Datos.");
        }

        /// <summary>
        /// Inserta un nuevo registro de tipo persona
        /// </summary>
        public void InsertaRegistro()
        {
            try
            {
                if (this.Persona == null)
                    throw new ArgumentNullException("No se ha iniciado el objeto que será insertado");
                entidad.mym_persona.Add(this.Persona);
                entidad.SaveChanges();
            }
            catch (Exception e)
            {
                log.Error("Error al insertar registro de tipo persona", e);
                throw e;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void ObtieneRegistroPorId()
        {
            try
            {
                this.Persona = (from p in entidad.mym_persona
                                where p.id == idEntidadRelacional
                                select p).SingleOrDefault();
            }
            catch (Exception e) 
            {
                log.Error("Error al consultar una persona por ID. ", e);
                throw e; 
            }
        }

        #endregion MÉTODOS PÚBLICOS
    }
}
