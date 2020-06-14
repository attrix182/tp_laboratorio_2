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

        static Profesor()
        {
            random = new Random();

        }

        private Profesor()
        {

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
            Universidad.EClases aux;
            aux = (Universidad.EClases)Profesor.random.Next(1, 4);
            this.clasesDelDia.Enqueue(aux);

        }

        /// <summary>
        /// Muestra el mensaje "CLASES DEL DÍA" junto al nombre de la clases que da
        /// </summary>
        /// <returns>Retorna una cadena con la/s clase/s que da un profesor</returns>
        protected override string ParticiparEnClase()
        {
            string cadena = "";
            int tam = this.clasesDelDia.Count;

            foreach (Universidad.EClases unaClase in this.clasesDelDia)
            {
                cadena += "\n" + Enum.GetName(typeof(Universidad.EClases), unaClase);
            }

            return "\nCLASES DEL DIA " + cadena;
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

            foreach (Universidad.EClases c in i.clasesDelDia)
            {
                if (c == clase)
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
            return this.MostrarDatos();
        }

    }
}
