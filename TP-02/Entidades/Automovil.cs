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
        /// Por defecto, TIPO será Monovolumen
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
            tipo = ETipo.Monovolumen;
        }

        public Automovil(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
            : this(marca, chasis, color)
        {
            this.tipo = tipo;

        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Los automoviles son medianos
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

      

       
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
