using log4net;
using MyMDatos.ORM.ForMySQL;
using MyMUtileriasGenericas.AccesoDatos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMDatos.CRUD.MySQL.MymInfo
{
    internal class ImplCrudMymPersona : ICrud
    {
        private mym_persona Persona;
        private List<mym_persona> Personas;
        private string conexion;
        private mymEntities Entidad;
        private static readonly ILog log=LogManager.GetLogger(typeof(ImplCrudMymPersona));

        /// <summary>
        /// Obtiene o establece el valor de la 
        /// propiedad persona
        /// </summary>
        public mym_persona persona
        {
            get { return Persona; }
            set { Persona = value; }
        }

        /// <summary>
        /// Obtiene o establece una lista de objetos 
        /// de tipo mym_persona
        /// </summary>
        public List<mym_persona> personas
        {
            get { return Personas; }
            set { Personas = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Entidad"></param>
        ImplCrudMymPersona(mymEntities Entidad)
        {
            this.Entidad = Entidad;
        }

        /// <summary>
        /// Método Constructor
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="Persona"></param>
        ImplCrudMymPersona(string conexion,mym_persona Persona)
        {
            this.conexion = conexion;
            this.Persona = Persona;
            Debug.WriteLine("Cadena de conexión recibida: ");
            Debug.WriteLine(this.conexion);
            Debug.WriteLine("Objeto persona recibido: ");
            Debug.WriteLine(JsonConvert.SerializeObject(Persona));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Entidad"></param>
        /// <param name="Persona"></param>
        ImplCrudMymPersona(mymEntities Entidad,mym_persona Persona)
        {
            this.Entidad = Entidad;
            this.Persona = Persona;
            Debug.WriteLine("Objeto persona recibido: ");
            Debug.WriteLine(JsonConvert.SerializeObject(Persona));
        }

        public void ActualizaRegistro()
        {
            try
            {
                var p = (from prsn in Entidad.mym_persona
                         where prsn.id == persona.id
                         select prsn).SingleOrDefault();
                p.nombre = persona.nombre;
                p.rfc = persona.rfc;
                p.sexo = persona.sexo;
                p.ultima_modificacion = persona.ultima_modificacion;
                p.url_fotografia = persona.url_fotografia;
                int resultado = Entidad.SaveChanges();
                if (resultado == 0)
                    throw new Exception("No se pudo actualizar el registro en la BD");
            }
            catch (Exception e)
            {
                log.Error("Ocurrió un error en ImplCrudMymPersona, método ActualizaRegistro", e);
                throw e;
            }
        }

        public void ConsultaSimple()
        {
            throw new NotImplementedException();
        }

        public void ConsultaTodo()
        {
            throw new NotImplementedException();
        }

        public void EliminaRegistro()
        {
            throw new NotImplementedException();
        }

        public void InsertaRegistro()
        {
            throw new NotImplementedException();
        }
    }
}
