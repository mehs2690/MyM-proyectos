using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MymCoreCommon.DataAccess
{
    /// <summary>
    /// Interfaz que implementa la estructura CRUD
    /// para las operaciones de acceso a datos
    /// </summary>
    /// <remarks>
    /// Creado por: T.P. Mauro Etzael Henaro Sánchez
    /// Version: 24.12.2015
    /// </remarks>
    public interface ICrud
    {
        /// <summary>
        /// 
        /// </summary>
        void Create();

        /// <summary>
        /// 
        /// </summary>
        void Update();

        /// <summary>
        /// 
        /// </summary>
        void Delete();
    }
}
