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
        /// 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;

            try
            {
                using (StreamWriter sw = new StreamWriter(archivo))
                {
                    sw.WriteLine(datos);
                    retorno = true;

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo guardar el archivo");
                throw new ArchivosException(e);
            }

            return retorno;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;

            try
            {
                using (StreamReader sr = new StreamReader(archivo))
                {
                    datos = sr.ReadToEnd();

                    retorno = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo leer el archivo");
                throw new ArchivosException(e);
            }

            return retorno;
        }

    }
}
