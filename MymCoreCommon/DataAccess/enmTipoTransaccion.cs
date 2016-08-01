using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MymCoreCommon.DataAccess
{
    /// <summary>
    /// Enumerador para la identificación de los 
    /// tipos de procesos hacia un Origen de Datos
    /// </summary>
    /// <remarks>
    /// Creado por: T.P. Mauro Etzael Henaro Sánchez
    /// Version: 24.12.2015
    /// </remarks>
    public enum enmTipoTransaccion
    {
        /// <summary>
        /// Proceso de inserción 
        /// </summary>
        INSERT=0,
        /// <summary>
        /// Proceso de actualización
        /// </summary>
        UPDATE,
        /// <summary>
        /// Proceso de eliminación
        /// </summary>
        DELETE
    }
}
