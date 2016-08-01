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
    public interface ISelectAsList<ObjectType>
    {
        List<ObjectType> SelectAsList();
    }
}
