using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ClasesInstanciables;
using Excepciones;
using Archivos;


namespace ClasesInstanciables
{


    public class Universidad
    {
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }


        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

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

        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                profesores = value;
            }
        }

        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                jornada = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }

            set
            {
                this.jornada[i] = value;
            }
        }



        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornada = new List<Jornada>();

        }

        /// <summary>
        /// Verifica si un alumno pertenece en una Universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Retorna true si pertenece, false en caso contrario</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno i in g.alumnos)
            {
                if (i == a)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }
        /// <summary>
        /// Verifica si un profesor pertenece en una Universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>Retorna true si pertenece, false en caso contrario</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;

            foreach (Profesor p in g.profesores)
            {
                if (i == p)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Retorna el primer profesor este capacitado para dar la clase indicada.
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Retorna un profesor para la clase, o una excepcion si no hay</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            Profesor retorno = null;
            bool flag = false;


            foreach (Profesor p in u.profesores)
            {
                if (p == clase)
                {
                    retorno = p;
                    flag = true;
                    break;
                }
            }

            if (!flag)
            {
                throw new SinProfesorException();
            }


            return retorno;

        }

        /// <summary>
        /// Verifica si un alumno no pertenece en una universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Retorna true si esta, false en caso contrario</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Verifica si un profesor no esta en una Universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>Reorna true si no esta, false en caso contrario</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Retorna el primer profesor que no este capacitado para dar la clase
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>retorna un profesor que no pueda dar la clase</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor retorno = null;


            foreach (Profesor p in u.profesores)
            {
                if (p != clase)
                {
                    retorno = p;
                    break;
                }
            }

            return retorno;
        }

        /// <summary>
        /// Agrega un profesor que pueda dar una clase y los alumnos que puedan tomarla
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Retorna una jornada con profesor y alumnos</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            int i;
            Profesor p = g == clase;
            g.jornada.Add(new Jornada(clase, p));
            i = g.jornada.Count - 1;

            foreach (Alumno a in g.alumnos)
            {
                if (a == clase)
                {
                    g.jornada[i] += a;
                }
            }

            return g;
        }

        /// <summary>
        /// Agrega un alumno a la universidad, verifiacando que no este repetido
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Universidad con el alumno agregado, o una excepcion si no se pudo</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return u;
        }

        /// <summary>
        /// Agrega un profesor a la universidad, verificando que no este repetido
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="i">Porfesor</param>
        /// <returns>Universiad con el profesor agregado</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.profesores.Add(i);
            }
            return u;
        }

        /// <summary>
        /// Guarda los datos de una universiad en un archivo .xml (si no existe lo crea)
        /// </summary>
        /// <param name="u">Universidad a guardar</param>
        /// <returns>Retorna true si la universi</returns>
        public static bool Guardar(Universidad u)
        {
            bool retorno = false;
            Xml<Universidad> xml = new Xml<Universidad>();
            xml.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/archivoXML.xml", u);

            return retorno;
        }

        /// <summary>
        /// Lee el archivo donde se encuentra la universiad
        /// </summary>
        /// <returns></returns>
        public Universidad Leer()
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            xml.Leer(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/archivoXML.xml", out Universidad u);

            return u;

        }

        /// <summary>
        /// muestra una universidad
        /// </summary>
        /// <returns>Retorna una cadena con los datos de una universidad</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Crea una cadena con los datos de una universidad
        /// </summary>
        /// <param name="uni">Universidad a mostrar</param>
        /// <returns>Retorna una cadena con los datos de la universidad</returns>
        private static string MostrarDatos(Universidad uni)
        {
            string cadena;

            cadena = "\nJORNADA:";
            foreach (Jornada j in uni.jornada)
            {
                cadena += "\n" + j.ToString();
                cadena += "<---------------------------------------------->";
            }

            return cadena;
        }
    }
}
