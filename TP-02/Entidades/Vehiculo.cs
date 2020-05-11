using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.(abstract)
    /// </summary>
    public abstract class Vehiculo
    {
        #region "Enumerados"
        public enum EMarca
        {
            Chevrolet,
            Ford,
            Renault,
            Toyota,
            BMW,
            Honda
        }

        public enum ETamanio
        {
            Chico,
            Mediano,
            Grande
        }
        #endregion

        #region "Atributos"
        private EMarca marca;
        private string chasis;
        private ConsoleColor color;
        #endregion

        #region "Propiedades"

        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        protected abstract ETamanio Tamanio { get; }

        #endregion

        #region "Constructores"

        /// <summary>
        ///  Constructor parametrizado. asigna chasis, marca y color de un vehiculo
        /// </summary>
        /// <param name="chasis">Chasis del vehiculo</param>
        /// <param name="marca"></param>
        /// <param name="color"></param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }
        #endregion

        #region "Metodos"
        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns>Retorna una cadena con los datos de un vehiculo</returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }
        #endregion

        #region "Operadores"

        /// <summary>
        /// Convierte de forma explicita los datos de un vehiculo a string
        /// </summary>
        /// <param name="p">Vehiculo a convertir</param>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();


            sb.AppendLine("CHASIS: " + p.chasis.ToString());
            sb.AppendLine("MARCA: " + p.marca.ToString());
            sb.AppendLine("COLOR: " + p.color.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }


        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1">Vehiculo a comprar A</param>
        /// <param name="v2">Vehiculo a comprar B</param>
        /// <returns>Retornara True si son iguales, false en caso contrario</returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1">Vehiculo a comprar A</param>
        /// <param name="v2">Vehiculo a comprar B</param>
        /// <returns>Retornara True si son diferentes, false en caso contrario</returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1.chasis == v2.chasis);
        }

        #endregion


    }
}
