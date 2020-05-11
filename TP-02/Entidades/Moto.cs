using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {
        #region "Constructores"

        /// <summary>
        ///  Constructor parametrizado. 
        /// </summary>
        /// <param name="marca">Marca de la Moto</param>
        /// <param name="chasis">Chasis  de la Moto</param>
        /// <param name="color">Color de la Moto</param>
        public Moto(EMarca marca, string chasis, ConsoleColor color) : base(chasis, marca, color)
        {
           
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        ///Propiedad que retorna el tamaño de la Moto(Por defecto Chico)
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }

        /// <summary>
        /// Muestra los datos de una Moto
        /// </summary>
        /// <returns>Retorna los datos en formato de cadena</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MOTO");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("TAMAÑO: " + this.Tamanio.ToString());
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
