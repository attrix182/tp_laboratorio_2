using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T>
    {
        /// <summary>
        /// Metodo que se utilizara para guardar datos en un archivo
        /// </summary>
        /// <param name="archivo">Ruta</param>
        /// <param name="datos">Entrada de datos</param>
        /// <returns></returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Metodo que se utilizara para leer datos de un archivo
        /// </summary>
        /// <param name="archivo">Ruta</param>
        /// <param name="datos">Salida de datos</param>
        /// <returns></returns>
        bool Leer(string archivo, out T datos);


    }
}
