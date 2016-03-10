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
    internal class ImplCrudMymPersona : CrudAbstractMymInfo, ICrud
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(ImplCrudMymPersona));

        #region CONSTRUCTORES

        ImplCrudMymPersona(Guid idPersona,string Conexion)
        {
            idEntidadRelacional = idPersona;
            CadenaConexionBd = Conexion;
        }

        #endregion CONSTRUCTORES

        #region MÉTODOS PÚBLICOS

        public void ActualizaRegistro()
        {
            throw new NotImplementedException();
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

        public override void ObtieneRegistroPorId()
        {
            try
            {

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
