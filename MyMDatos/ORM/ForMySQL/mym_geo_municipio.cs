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
    
    public partial class mym_geo_municipio
    {
        public mym_geo_municipio()
        {
            this.mym_direccion = new HashSet<mym_direccion>();
            this.mym_geo_ciudad = new HashSet<mym_geo_ciudad>();
            this.mym_geo_codigo_postal = new HashSet<mym_geo_codigo_postal>();
        }
    
        public int id { get; set; }
        public int id_pais { get; set; }
        public int id_estado { get; set; }
        public string nombre { get; set; }
        public string coordenadas { get; set; }
        public int estatus { get; set; }
    
        public virtual mym_cat_estatus mym_cat_estatus { get; set; }
        public virtual ICollection<mym_direccion> mym_direccion { get; set; }
        public virtual ICollection<mym_geo_ciudad> mym_geo_ciudad { get; set; }
        public virtual ICollection<mym_geo_codigo_postal> mym_geo_codigo_postal { get; set; }
        public virtual mym_geo_estado mym_geo_estado { get; set; }
        public virtual mym_geo_pais mym_geo_pais { get; set; }
    }
}
