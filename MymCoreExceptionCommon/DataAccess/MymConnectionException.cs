using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MymCoreExceptionCommon.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    public class MymConnectionException:Exception 
    {
        /// <summary>
        /// 
        /// </summary>
        public MymConnectionException()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public MymConnectionException(string message) : base(message)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public MymConnectionException(string message,Exception inner) : base(message, inner)
        {

        }
    }
}
