using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMUtileriasGenericas.AccesoDatos;

namespace MyMUtileriasGenericas
{
    /// <summary>
    /// Clase de pruebas
    /// </summary>
    class TestUtilerias
    {
        private enum ListaAcciones { AYUDA=0,LISTA_ACCIONES,CIFRADO_MD5,CIFRADO_DES, DESCIFRADO_DES,CIFRADO_RFC289, DESCIFRADO_RFC289 }

        private static void ConfiguraLogNet()
        {

        }

        public static void CreaInstrucciones()
        {
            string pathArchivo = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), @"ArchivosPlanos\Instrucciones.txt");
            List<string> instrucciones=LecturaArchivos.LeeArchivoLineaPorLinea(pathArchivo);
            foreach (string renglon in instrucciones)
            {
                Console.WriteLine(renglon);
            }
        }

        public static void CreaListaAcciones()
        {

        }

        /// <summary>
        /// Método Principal
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            if (args.Length <= 0)
            {
                CreaInstrucciones();
            }
            else
            {
                if (Enum.IsDefined(typeof(ListaAcciones), (args[0].ToUpper())))
                {
                    ListaAcciones accion = (ListaAcciones)Enum.Parse(typeof(ListaAcciones), args[0], true);
                    switch (accion)
                    {
                        case ListaAcciones.AYUDA:
                            CreaInstrucciones();
                            break;
                        case ListaAcciones.LISTA_ACCIONES:
                            break;
                        case ListaAcciones.CIFRADO_MD5:
                            break;
                        case ListaAcciones.CIFRADO_DES:
                            break;
                        case ListaAcciones.DESCIFRADO_DES:
                            break;
                        case ListaAcciones.CIFRADO_RFC289:
                            break;
                        case ListaAcciones.DESCIFRADO_RFC289:
                            break;
                        default:
                            CreaInstrucciones();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("La opción ingresada es errónea");
                }
            }
            Console.Read();
        }
    }
}
