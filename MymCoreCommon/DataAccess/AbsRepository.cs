using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MymCoreCommon.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="EntityType"></typeparam>
    /// <typeparam name="ContextType"></typeparam>
    public abstract class AbsRepository<EntityType, ContextType>
    {
        /// <summary>
        /// 
        /// </summary>
        protected EntityType entity;

        /// <summary>
        /// 
        /// </summary>
        protected ContextType context;

        /// <summary>
        /// 
        /// </summary>
        public abstract void Commit();

        /// <summary>
        /// 
        /// </summary>
        public abstract void RollBack();
    }
}
