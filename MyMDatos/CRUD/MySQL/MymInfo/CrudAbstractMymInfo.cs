using MyMDatos.ORM.ForMySQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMDatos.CRUD.MySQL.MymInfo
{
    internal abstract class CrudAbstractMymInfo
    {
        #region PROPIEDADES

        protected mymEntities entidad;
        protected Guid idEntidadRelacional;
        protected int idIntEntidadRelacional;
        protected string CadenaConexionBd;
        protected bool procesoCorrecto;

        #endregion PROPIEDADES

        public abstract void ObtieneRegistroPorId();
    }
}
