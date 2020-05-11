using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Automovil : Vehiculo
    {
        #region "Enumerados"
        public enum ETipo
        {
            Monovolumen,
            Sedan
        }
        #endregion

        #region "Atributos"

        private ETipo tipo;

        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor parametrizado. Asigna el tipo(Por defecto, será Monovolumen)
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
            tipo = ETipo.Monovolumen;
        }

        /// <summary>
        /// Constructor parametrizado. Sobrecargado
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        /// <param name="tipo"></param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
            : this(marca, chasis, color)
        {
            this.tipo = tipo;

        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        ///Propiedad que retorna el tamaño del Automovil(Por defecto Mediano)
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

      

       /// <summary>
       /// Muestra los datos de un Automovil
       /// </summary>
       /// <returns>Retornara una cadena con los datos</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");
            sb.AppendLine(base.Mostrar());
            sb.Append("TAMAÑO : " + this.Tamanio.ToString());
            sb.Append(" TIPO : " + this.tipo.ToString());
            sb.AppendLine(" ");
            sb.AppendLine("\r\n---------------------");

            return sb.ToString();
        }
        #endregion
    }
}
