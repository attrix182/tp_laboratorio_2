using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T> where T : class
    {
        /// <summary>
        /// Metodo que toma datos de tipo T para guardarlos en un archivo de formato
        /// .xml en la ruta espicificada.
        /// </summary>
        /// <param name="archivo">Ruta</param>
        /// <param name="datos">Entrada de datos</param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            bool retornoAux;
            try
            {
                XmlSerializer xmls = new XmlSerializer(typeof(T));
                TextWriter tw = new StreamWriter(archivo);
                xmls.Serialize(tw, datos);
                retornoAux = true;
                tw.Close();
            }
            catch (Exception e)
            {
                retornoAux = false;
                Console.WriteLine("No se pudo guardar el archivo xml");
                throw new ArchivosException(e);
            }
            return retornoAux;
        }

        /// <summary>
        /// Metodo que permite leer datos tipo T de un archivo de formato .xml
        /// </summary>
        /// <param name="archivo">Ruta</param>
        /// <param name="datos">Salida de datos</param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            bool retornoAux;
            datos = default(T);
            try
            {
                XmlSerializer xmls = new XmlSerializer(typeof(T));
                StreamReader sr = new StreamReader(archivo);
                datos = (T)xmls.Deserialize(sr);
                retornoAux = true;
                sr.Close();
            }
            catch (Exception e)
            {
                retornoAux = false;
                Console.WriteLine("No se pudo leer el archivo xml");
                throw new ArchivosException(e);
            }

            return retornoAux;
        }
    }
}
