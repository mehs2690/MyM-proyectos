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
    interface ISelectByCondition<ObjectType>
    {
        List<ObjectType> SelectByCondition(Dictionary<string, object> propertiesAndValues);
    }
}
