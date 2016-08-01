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
    /// <typeparam name="IdentityType"></typeparam>
    public interface IUpdate<IdentityType>
    {
        void Update(IdentityType id);
    }
}
