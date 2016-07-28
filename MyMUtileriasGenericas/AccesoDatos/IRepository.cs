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
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="O"></typeparam>
    public interface IRepository<T,O>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Create(T entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="identifier"></param>
        void Update(O identifier);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="identifier"></param>
        void Delete(O identifier);
    }
}
