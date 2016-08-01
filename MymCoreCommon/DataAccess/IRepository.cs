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
    /// <typeparam name="ObjectType"></typeparam>
    /// <typeparam name="IdentityType"></typeparam>
    public interface IRepository<ObjectType, IdentityType> : ICreate<ObjectType>, 
        ISelectAsList<ObjectType>, 
        ISelect<ObjectType, 
        IdentityType>, 
        IUpdate<IdentityType>, 
        IDelete<IdentityType>
    {

    }
}
