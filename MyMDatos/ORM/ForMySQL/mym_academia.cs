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
    
    public partial class mym_academia
    {
        public mym_academia()
        {
            this.mym_rel_persona_academia = new HashSet<mym_rel_persona_academia>();
        }
    
        public System.Guid id { get; set; }
        public string nombre { get; set; }
        public int tipo_academia { get; set; }
        public System.DateTime fecha_ingreso { get; set; }
        public Nullable<System.DateTime> fecha_egreso { get; set; }
        public int titulo { get; set; }
        public int estatus { get; set; }
    
        public virtual mym_cat_estatus mym_cat_estatus { get; set; }
        public virtual mym_cat_tipo_academia mym_cat_tipo_academia { get; set; }
        public virtual mym_cat_titulo mym_cat_titulo { get; set; }
        public virtual ICollection<mym_rel_persona_academia> mym_rel_persona_academia { get; set; }
    }
}