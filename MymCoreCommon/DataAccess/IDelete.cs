using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MymCoreCommon.DataAccess
{
    public interface IDelete<IdentityType>
    {
        void Delete(IdentityType id);
    }
}
