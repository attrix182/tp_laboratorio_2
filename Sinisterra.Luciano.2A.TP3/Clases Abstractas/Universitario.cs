using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        /// <summary>
        /// Constructor por defecto de la clase universitario
        /// </summary>
        public Universitario():base()
        {

        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="legajo">Numero de legajo</param>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="dni">DNI de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        /// <summary>
        /// Verifica que el objeto a comparar sea de tipo Universitario y si lo es verifica que sea igual al objeto que
        /// llama la funcion
        /// </summary>
        /// <param name="obj">Objeto a comparar</param>
        /// <returns>true si son iguales, falso si no lo son</returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;

            if (obj is Universitario)
            {
                if (this == (Universitario)obj)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        /// <summary>
        /// Muestra los datos de un Universitario
        /// </summary>
        /// <returns>Retorna los datos de un universitario en formato cadena</returns>
        protected virtual string MostrarDatos()
        {
            return base.ToString() + "\n\nLEGAJO NUMERO: " + this.legajo.ToString();
        }

        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Compara y verifica a dos universitarios por su DNI y legajo 
        /// </summary>
        /// <param name="pg1">Universitario Uno</param>
        /// <param name="pg2">Universitario Dos</param>
        /// <returns>Retorna true si son iguales, false en caso contrario</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;

            if (pg1.GetType() == pg2.GetType() && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI))
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Compara a dos Universitarios verificando si son diferentes
        /// </summary>
        /// <param name="pg1">Universitario 1</param>
        /// <param name="pg2">Universitario 2</param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }


    }
}
