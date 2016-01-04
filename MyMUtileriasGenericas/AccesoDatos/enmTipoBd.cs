using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMUtileriasGenericas.AccesoDatos
{
    /// <summary>
    /// Enumerador para obtener
    /// la base de datos a usar
    /// </summary>
    public enum enmTipoBd
    {
        /// <summary>
        /// Microsoft SQL Server
        /// </summary>
        MSSQL=0,
        /// <summary>
        /// Oracle BD
        /// </summary>
        ORACLE,
        /// <summary>
        /// MySQL BD
        /// </summary>
        MYSQL,
        /// <summary>
        /// Postgre BD
        /// </summary>
        POSTGRE,
        /// <summary>
        /// Microsoft Access
        /// </summary>
        MSACCESS,
        /// <summary>
        /// Mongo BD
        /// </summary>
        MONGOBD
    }
}
