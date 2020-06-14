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
        /// 
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public bool Guardar(string archivo, T datos)
        {
            bool retorno;
            try
            {
                XmlSerializer xmls = new XmlSerializer(typeof(T));
                TextWriter tw = new StreamWriter(archivo);
                xmls.Serialize(tw, datos);
                retorno = true;
                tw.Close();
            }
            catch (Exception e)
            {
                retorno = false;
                Console.WriteLine("No se pudo guardar el archivo xml");
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
        public bool Leer(string archivo, out T datos)
        {
            bool retorno;
            datos = default(T);
            try
            {
                XmlSerializer xmls = new XmlSerializer(typeof(T));
                StreamReader sr = new StreamReader(archivo);
                datos = (T)xmls.Deserialize(sr);
                retorno = true;
                sr.Close();
            }
            catch (Exception e)
            {
                retorno = false;
                Console.WriteLine("No se pudo leer el archivo xml");
                throw new ArchivosException(e);
            }

            return retorno;
        }
    }
}
