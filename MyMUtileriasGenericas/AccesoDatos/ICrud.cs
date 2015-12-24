using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMUtileriasGenericas.AccesoDatos
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
        /// Método que realiza una consulta simple
        /// a un origen de datos
        /// </summary>
        void ConsultaSimple();

        /// <summary>
        /// Método que obtiene la consulta de todos 
        /// los registros de una entidad desde un 
        /// origen de datos
        /// </summary>
        void ConsultaTodo();

        /// <summary>
        /// Método que realiza la inserción de un 
        /// nuevo registro desde un origen de datos
        /// </summary>
        void InsertaRegistro();

        /// <summary>
        /// Método que actualiza la información de 
        /// un registro desde un origen de datos
        /// </summary>
        void ActualizaRegistro();

        /// <summary>
        /// Método que elimina un registro desde 
        /// un origen de datos
        /// </summary>
        void EliminaRegistro();
    }
}
