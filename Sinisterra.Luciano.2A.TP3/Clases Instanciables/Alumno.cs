using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        public Universidad.EClases claseQueToma;
        public EEstadoCuenta estadoCuenta;

        /// <summary>
        /// Construcroe por defecto de la clase
        /// </summary>
        public Alumno() : base()
        {

        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="id">id del alumno</param>
        /// <param name="nombre">Nombre del alumno</param>
        /// <param name="apellido">Apellido del alumno</param>
        /// <param name="dni">DNI del alumno </param>
        /// <param name="nacionalidad">Nacionalidad del alumno</param>
        /// <param name="claseQueToma">Clase que toma el alumno </param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Sobrecarga del constructor parametrizado
        /// </summary>
        /// <param name="id">id del alumno</param>
        /// <param name="nombre">Nombre del alumno</param>
        /// <param name="apellido">Apellido del alumno</param>
        /// <param name="dni">DNI del alumno </param>
        /// <param name="nacionalidad">Nacionalidad del alumno</param>
        /// <param name="claseQueToma">Clase que toma el alumno </param>
        /// <param name="estadoCuenta">Estado de cuenta del alumno</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        /// <summary>
        ///Muestra los datos de un alumno 
        /// </summary>
        /// <returns>Retorna una cadena con los datos de un alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.Append("ESTADO DE CUENTA: ");

            switch (this.estadoCuenta)
            {
                case EEstadoCuenta.AlDia:
                    sb.Append("Cuota al dia");

                    break;
                case EEstadoCuenta.Deudor:
                    sb.Append("Deudor");
                    break;
                case EEstadoCuenta.Becado:

                    sb.Append("Becado");
                    break;
            }
            return sb.ToString() + this.ParticiparEnClase();
        }


        /// <summary>
        /// Muestra la clase que toma un alumno
        /// </summary>
        /// <returns>Retorna una cadena conteniendo la clase toma un alumno</returns>
        protected override string ParticiparEnClase()
        {
            return "\nTOMA CLASE DE " + this.claseQueToma.ToString();
        }

        /// <summary>
        /// Invoca un metodo que muestra los datos de un alumno
        /// </summary>
        /// <returns>Retorna una cadena con los datos del alumno</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Verifica si un alumno toma la clase
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>Retorna true si pertenece, false en caso contrario</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool retornoAux = false;

            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                retornoAux = true;
            }

            return retornoAux;

        }

        /// <summary>
        /// Verifica si un alumno no toma la clase
        /// </summary>
        /// <param name="a"></param>
        /// <param name="clase"></param>
        /// <returns>Retorna true si no pertenece, false en caso contrario</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
        }

    }
}
