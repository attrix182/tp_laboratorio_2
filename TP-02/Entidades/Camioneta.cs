using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Camioneta : Vehiculo
    {
        #region "Constructores"

        /// <summary>
        /// Constructor parametrizado. 
        /// </summary>
        /// <param name="marca">Marca de la Camioneta</param>
        /// <param name="chasis">Chasis de la Camioneta</param>
        /// <param name="color">Color de la Camioneta</param>
        public Camioneta(EMarca marca, string chasis, ConsoleColor color) : base(chasis, marca, color)
        {

        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Propiedad que retorna el tamaño de la Camioneta(Por defecto Grande)
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }

        /// <summary>
        /// Muestra los datos de una Camioneta
        /// </summary>
        /// <returns>Retorna los datos en formato de cadena</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CAMIONETA");
            sb.AppendLine(base.Mostrar());
            sb.AppendFormat("TAMAÑO  : {0}", this.Tamanio);
            sb.AppendLine("");
            sb.AppendLine("\r\n---------------------");

            return sb.ToString();
        }

        #endregion
    }
}

