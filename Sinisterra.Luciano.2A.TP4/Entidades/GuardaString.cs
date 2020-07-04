using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Crea un archivo de texto con el string y nombre recibido por parametros, en el escritorio del usaurio.
        /// </summary>
        /// <param name="texto">Texto a guradar</param>
        /// <param name="archivo">Nombre del archivo a guardar</param>
        /// <returns>Retorna true si pudo, false en caso contrario</returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool exito = false;

            try
            {
                using (StreamWriter escritor = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + archivo, true))
                {
                    escritor.WriteLine(texto);
                    exito = true;
                }
            }
            catch (Exception)
            {

            }

            return exito;
        }
    }
}
