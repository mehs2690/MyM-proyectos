using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMUtileriasGenericas.AccesoDatos;
using MyMUtileriasGenericas.Seguridad;

namespace MyMUtileriasGenericas
{
    /// <summary>
    /// Clase de pruebas
    /// </summary>
    class TestUtilerias
    {
        private enum ListaAcciones { AYUDA=0,LISTA_ACCIONES,CIFRADO_MD5,CIFRADO_DES, DESCIFRADO_DES,CIFRADO_RFC289, DESCIFRADO_RFC289 }
        private static string[] cadenas;

        private static void ConfiguraLogNet()
        {

        }

        private static void CreaInstrucciones()
        {
            string pathArchivo = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), @"ArchivosPlanos\Instrucciones.txt");
            List<string> instrucciones=LecturaArchivos.LeeArchivoLineaPorLinea(pathArchivo);
            foreach (string renglon in instrucciones)
            {
                Console.WriteLine(renglon);
            }
            Console.WriteLine("Lista de acciones principales del ejecutable:");
            CreaListaAcciones();
        }

        private static void CreaListaAcciones()
        {
            var a = Enum.GetValues(typeof(ListaAcciones));
            int cont = 1;
            Console.WriteLine();
            foreach (ListaAcciones item in a)
            {
                Console.WriteLine(cont+".- "+item.ToString().ToLower());
                cont++;
            }
        }

        private static void ProcesaCadenaParaMD5(string[] aProcesar)
        {
            foreach (string item in aProcesar)
            {
                cadenas = item.Split(';');
                Console.WriteLine();
                Console.WriteLine(string.Format("texto a cifrar: {0}", cadenas[0]));
                Console.WriteLine();
                Console.WriteLine("Resultado en UpperCase:");
                Console.WriteLine();
                string cifrado = ProcesaDatosCD.ObtienePassword(cadenas[1], true);
                Console.WriteLine(cifrado);
                Console.WriteLine();
                Console.WriteLine("Resultado en LowerCase:");
                Console.WriteLine();
                cifrado = ProcesaDatosCD.ObtienePassword(cadenas[1], false);
                Console.WriteLine(cifrado);
                Console.WriteLine();
            }
        }

        private static void CifraTextoConDES(string textoOriginal,string password)
        {
            Console.WriteLine(string.Format("El texto a cifrar es: {0}", textoOriginal));
            Console.WriteLine();
            Console.WriteLine("Texto cifrado:");
            Console.WriteLine();
            if (string.IsNullOrEmpty(password))
                Console.WriteLine(ProcesaDatosCD.CifraTextoEnDES(textoOriginal));
            else
                Console.WriteLine(ProcesaDatosCD.CifraTextoEnDES(textoOriginal, password));
            Console.WriteLine();
            Console.WriteLine("Texto cifrado en formato hexadecimal:");
            Console.WriteLine();
            if (string.IsNullOrEmpty(password))
                Console.WriteLine(ProcesaDatosCD.FormatoHexadecimal(ProcesaDatosCD.CifraTextoEnDES(textoOriginal)));
            else
                Console.WriteLine(ProcesaDatosCD.FormatoHexadecimal(ProcesaDatosCD.CifraTextoEnDES(textoOriginal,password)));
            Console.WriteLine();
        }

        private static void DescifraTextoConDES(string textoCifrado,string password)
        {
            Console.WriteLine();
            Console.WriteLine("Texto descifrado desde el formato hexadecimal:");
            Console.WriteLine();
            string textoCifradoHex = ProcesaDatosCD.DesformateaHexadecimal(textoCifrado);
            Console.WriteLine(textoCifradoHex);
            Console.WriteLine();
            Console.WriteLine(string.Format("El texto cifrado es: {0}", textoCifradoHex));
            Console.WriteLine();
            Console.WriteLine("Texto descifrado:");
            Console.WriteLine();
            if (string.IsNullOrEmpty(password))
                Console.WriteLine(ProcesaDatosCD.DescifraTextoDES(textoCifradoHex));
            else
                Console.WriteLine(ProcesaDatosCD.DescifraTextoDES(textoCifradoHex, password));
            Console.WriteLine();
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
                        case ListaAcciones.CIFRADO_MD5:
                            string[] opcionesProcesar = new string[args.Length - 1];
                            for (int i = 1; i < opcionesProcesar.Length + 1; i++)
                            {
                                opcionesProcesar[i - 1] = args[i];
                            }
                            ProcesaCadenaParaMD5(opcionesProcesar);
                            break;
                        case ListaAcciones.CIFRADO_DES:
                            if (args.Length >= 3)
                                CifraTextoConDES(args[1], args[2]);
                            else
                                CifraTextoConDES(args[1], string.Empty);
                            break;
                        case ListaAcciones.DESCIFRADO_DES:
                            if (args.Length >= 3)
                                DescifraTextoConDES(args[1], args[2]);
                            else
                                DescifraTextoConDES(args[1], string.Empty);
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
