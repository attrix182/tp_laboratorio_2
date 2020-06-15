using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace ClasesInstanciables
{
    public class Jornada
    {

        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                alumnos = value;
            }
        }


        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                clase = value;
            }
        }
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                instructor = value;
            }
        }

        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }


        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        /// <summary>
        /// Verifica si un alumno pertenece a la clase de la jornada
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>Retorna true si el alumno participa, false en caso contrario.</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retornoAux = false;

            foreach (Alumno i in j.alumnos)
            {
                if (i == a)
                {
                    retornoAux = true;
                    break;
                }
            }

            return retornoAux;
        }

        /// <summary>
        /// Verifica si un alumno no pertenece a la clase de la jornada
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>Retorna true si el alumno no pertenece, false en caso contrario</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Verifica su un alumno participa en la clase de la jornada, en caso de que participe y no este en la jornada
        /// lo agrega
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>Retorna la jornada con el alumno, si esta repetido una excepcion</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return j;
        }

        /// <summary>
        /// Crea una cadena con los datos de la jornada
        /// </summary>
        /// <returns>Retorna una cadena con los datos de la jornada</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASE DE " + this.clase.ToString() + " POR NOMBRE COMPLETO: " + this.instructor.ToString());

            sb.AppendLine("\nALUMNOS:");
            foreach (Alumno a in this.alumnos)
            {
                sb.AppendLine("NOMBRE COMPLETO: " + a.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Guarda un archivo de texto con los datos de la jornada
        /// </summary>
        /// <param name="jornada">Jornada a guardar</param>
        /// <returns>True si la jornada es valida</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto writer = new Texto();

            try
            {
                return writer.Guardar("JornadaTXT.txt", jornada.ToString());
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Lee el archivo de texto donde se guarda la jornada
        /// </summary>
        /// <returns>Retorna los datos como cadena</returns>
        public static string Leer()
        {
            Texto reader = new Texto();
            string retorno;

            try
            {
                reader.Leer("JornadaTXT.txt", out retorno);
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retorno;

        }
    }
}
