//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyMDatos.ORM.ForMySQL
{
    using System;
    using System.Collections.Generic;
    
    public partial class mym_cat_tipo_comunicacion
    {
        public mym_cat_tipo_comunicacion()
        {
            this.mym_comunicacion = new HashSet<mym_comunicacion>();
        }
    
        public int id { get; set; }
        public string descripcion { get; set; }
        public int estatus { get; set; }
    
        public virtual ICollection<mym_comunicacion> mym_comunicacion { get; set; }
    }
}