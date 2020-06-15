using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using Archivos;
using Excepciones;


namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Implementacion del metodo Guardar de la interfa IArchivos.
        /// Se encargara de guardar los datos
        /// </summary>
        /// <param name="archivo">Ruta</param>
        /// <param name="datos">Entrada de datos</param>
        /// <returns>Retornara true si pudo</returns>
        public bool Guardar(string archivo, string datos)
        {
            bool retornoAux = false;

            try
            {
                using (StreamWriter sw = new StreamWriter(archivo))
                {
                    sw.WriteLine(datos);
                    retornoAux = true;

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo GUARDAR el Archivo");
                throw new ArchivosException(e);
            }

            return retornoAux;
        }


        /// <summary>
        /// Implementacion del metodo Leer de la interface IArchivos
        /// Se encargara de leer los archivos en formato txt
        /// </summary>
        /// <param name="archivo">Ruta</param>
        /// <param name="datos">Salida de datos</param>
        /// <returns>Retornara true si pudo</returns>
        public bool Leer(string archivo, out string datos)
        {
            bool retornoAux = false;

            try
            {
                using (StreamReader sr = new StreamReader(archivo))
                {
                    datos = sr.ReadToEnd();

                    retornoAux = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo LEER el Archivo");
                throw new ArchivosException(e);
            }

            return retornoAux;
        }

    }
}
