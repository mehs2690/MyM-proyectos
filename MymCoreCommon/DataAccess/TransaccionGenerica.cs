using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MymCoreCommon.DataAccess
{
    /// <summary>
    /// Modelo generico para la digestión 
    /// de los procesos que serán ejecutados
    /// dentro de una transacción
    /// </summary>
    /// <remarks>
    /// Creado por: T.P. Mauro Etzael Henaro Sánchez
    /// Version: 24.12.2015
    /// </remarks>
    public class TransaccionGenerica
    {
        private ICrud operacion;
        private enmTipoTransaccion tipoTransaccion;

        /// <summary>
        /// obtiene o establece el valor de la 
        /// propiedad operacion
        /// </summary>
        public ICrud Operacion
        {
            get
            {
                return operacion;
            }

            set
            {
                operacion = value;
            }
        }

        /// <summary>
        /// obtiene o establece el valor de la 
        /// propiedad tipoTransaccion
        /// </summary>
        public enmTipoTransaccion TipoTransaccion
        {
            get
            {
                return tipoTransaccion;
            }

            set
            {
                tipoTransaccion = value;
            }
        }

        /// <summary>
        /// Método Constructor
        /// </summary>
        public TransaccionGenerica()
        {
        }
    }
}
