using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MyMUtileriasGenericas.AccesoDatos
{
    /// <summary>
    /// Clase encargada de generar una transacción 
    /// hacia un origen de datos y ejecutar las operaciones 
    /// que se le asignen
    /// </summary>
    /// <remarks>
    /// Creado por: T.P. Mauro Etzael Henaro Sánchez
    /// Version: 24.12.2015
    /// </remarks>
    public class TransaccionBd
    {
        private TransactionScope transaccion;

        /// <summary>
        /// Método Constructor
        /// </summary>
        /// <param name="transaccion">instancia del objeto TransactionScope</param>
        public TransaccionBd(TransactionScope transaccion)
        {
            this.transaccion = transaccion;
        }

        private void EvaluaTipoOperacion(TransaccionGenerica transaccion)
        {
            try
            {
                switch (transaccion.TipoTransaccion)
                {
                    case enmTipoTransaccion.INSERT:
                        transaccion.Operacion.InsertaRegistro();
                        break;
                    case enmTipoTransaccion.UPDATE:
                        transaccion.Operacion.ActualizaRegistro();
                        break;
                    case enmTipoTransaccion.DELETE:
                        transaccion.Operacion.EliminaRegistro();
                        break;
                    case enmTipoTransaccion.SELECT_SINGLE:
                        throw new InvalidOperationException("Las operaciones de selección no son válidas para entrar en una transacción.");
                    case enmTipoTransaccion.SELECT_ALL:
                        throw new InvalidOperationException("Las operaciones de selección no son válidas para entrar en una transacción.");
                    default:
                        throw new InvalidCastException("El tipo de operación no es válido");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Método que ejecuta las operaciones CRUD 
        /// dentro de una transacción de origen de datos
        /// </summary>
        /// <param name="operaciones">lista de objetos de la transaccion genérica</param>
        public void EjecutaOperacionesEnTransaccion(List<TransaccionGenerica> operaciones)
        {
            using (transaccion=new TransactionScope())
            {
                foreach (TransaccionGenerica t in operaciones)
                    EvaluaTipoOperacion(t);
            }
        }
    }
}
