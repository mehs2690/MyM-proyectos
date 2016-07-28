using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMUtileriasGenericas.AccesoDatos
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="R"></typeparam>
    /// <typeparam name="I"></typeparam>
    public abstract class AbstractRepository<R,I>
    {
        /// <summary>
        /// 
        /// </summary>
        protected R contexto;
        /// <summary>
        /// 
        /// </summary>
        protected I identifier;

        /// <summary>
        /// 
        /// </summary>
        public AbstractRepository()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        public abstract void Confirm();

        /// <summary>
        /// 
        /// </summary>
        public abstract void Reset();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="identifier"></param>
        protected abstract void SelectById(I identifier);
    }
}
