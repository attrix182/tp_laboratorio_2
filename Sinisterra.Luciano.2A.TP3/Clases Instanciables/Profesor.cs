using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;


namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;


        public Profesor() : base()
        {
            clasesDelDia = new Queue<Universidad.EClases>();
            _randomClases();

        }

        /// <summary>
        /// Constructor estático que inicializa random
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }


        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        /// <summary>
        /// Agrega dos clases a un profesor, las clases pueden o no ser iguales.
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(1, 4));
            this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(1, 4));

        }

        /// <summary>
        /// Muestra el mensaje "CLASES DEL DÍA" junto al nombre de la clases que da
        /// </summary>
        /// <returns>Retorna una cadena con la/s clase/s que da un profesor</returns>
        protected override string ParticiparEnClase()
        {
            string CadenaDeSalida = " \nCLASES DEL DIA: \n";

            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                CadenaDeSalida += clase + "\n";
            }

            CadenaDeSalida += "\n";

            return CadenaDeSalida;
        }

        /// <summary>
        /// Muestra una cadena con los datos de un profesor
        /// </summary>
        /// <returns>Retorna una cadena con los datos de un profesor y la clase que toma</returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + this.ParticiparEnClase();

        }

        /// <summary>
        /// Verifica si un profesor da una clase
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">Clase</param>
        /// <returns>Retorna true si pertenece, false en caso contrario</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retornoAux = false;

            foreach (Universidad.EClases claseDelProfesor in i.clasesDelDia)
            {
                if (claseDelProfesor == clase)
                {
                    retornoAux = true;
                    break;
                }
            }

            return retornoAux;

        }

        /// <summary>
        /// Verifica si un profesor no da una clase
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">Clase</param>
        /// <returns>Retorna true si no pertenece, false en caso contrario</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        /// <summary>
        /// Muestra los datos de un profesor
        /// </summary>
        /// <returns>Retorna una cadena con los datos de un profesor</returns>
        public override string ToString()
        {
            return MostrarDatos();
        }

    }
}
