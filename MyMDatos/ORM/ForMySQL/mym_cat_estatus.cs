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
    
    public partial class mym_cat_estatus
    {
        public mym_cat_estatus()
        {
            this.mym_academia = new HashSet<mym_academia>();
            this.mym_geo_ciudad = new HashSet<mym_geo_ciudad>();
            this.mym_comunicacion = new HashSet<mym_comunicacion>();
            this.mym_geo_codigo_postal = new HashSet<mym_geo_codigo_postal>();
            this.mym_direccion = new HashSet<mym_direccion>();
            this.mym_geo_estado = new HashSet<mym_geo_estado>();
            this.mym_experiencia_laboral = new HashSet<mym_experiencia_laboral>();
            this.mym_geo_municipio = new HashSet<mym_geo_municipio>();
            this.mym_rel_persona_academia = new HashSet<mym_rel_persona_academia>();
            this.mym_rel_persona_comunicacion = new HashSet<mym_rel_persona_comunicacion>();
            this.mym_rel_persona_direccion = new HashSet<mym_rel_persona_direccion>();
            this.mym_rel_persona_exp_laboral = new HashSet<mym_rel_persona_exp_laboral>();
            this.mym_rel_persona_tipo_persona = new HashSet<mym_rel_persona_tipo_persona>();
        }
    
        public int id { get; set; }
        public string descripcion { get; set; }
        public bool activo { get; set; }
    
        public virtual ICollection<mym_academia> mym_academia { get; set; }
        public virtual ICollection<mym_geo_ciudad> mym_geo_ciudad { get; set; }
        public virtual ICollection<mym_comunicacion> mym_comunicacion { get; set; }
        public virtual ICollection<mym_geo_codigo_postal> mym_geo_codigo_postal { get; set; }
        public virtual ICollection<mym_direccion> mym_direccion { get; set; }
        public virtual ICollection<mym_geo_estado> mym_geo_estado { get; set; }
        public virtual ICollection<mym_experiencia_laboral> mym_experiencia_laboral { get; set; }
        public virtual ICollection<mym_geo_municipio> mym_geo_municipio { get; set; }
        public virtual ICollection<mym_rel_persona_academia> mym_rel_persona_academia { get; set; }
        public virtual ICollection<mym_rel_persona_comunicacion> mym_rel_persona_comunicacion { get; set; }
        public virtual ICollection<mym_rel_persona_direccion> mym_rel_persona_direccion { get; set; }
        public virtual ICollection<mym_rel_persona_exp_laboral> mym_rel_persona_exp_laboral { get; set; }
        public virtual ICollection<mym_rel_persona_tipo_persona> mym_rel_persona_tipo_persona { get; set; }
    }
}
