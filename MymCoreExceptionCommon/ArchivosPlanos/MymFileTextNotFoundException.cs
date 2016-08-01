using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MymCoreExceptionCommon.ArchivosPlanos
{
    /// <summary>
    /// 
    /// </summary>
    public class MymFileTextNotFoundException: Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public MymFileTextNotFoundException()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public MymFileTextNotFoundException(string message) : base(message)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="inner"></param>
        public MymFileTextNotFoundException(string message,Exception inner) : base(message, inner)
        {

        }
    }
}
