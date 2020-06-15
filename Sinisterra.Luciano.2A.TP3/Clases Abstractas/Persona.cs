using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        /// <summary>
        /// Propiedad get/set del atributo Apellido
        /// 
        /// get: Retorna el apellido
        /// 
        /// set: Asigna el apellido validandolo previamente
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad get/set del atributo DNI
        /// 
        /// get: Retorna el DNI
        /// 
        /// set: Asigna el DNI validandolo previamente
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        /// <summary>
        /// Propiedad get/set del atributo nacionalidad
        /// 
        /// get: Retorna la nacionalidad
        /// 
        /// set: Asigna la nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                nacionalidad = value;
            }
        }

        /// <summary>
        /// Propiedad get/set del atributo Nombre
        /// 
        /// get: Retorna el nombre
        /// 
        /// set: Asigna el nombre validandolo previamente
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad set del atributo DNI si es de tipo Cadena
        /// 
        /// set: Asigna el DNI validandolo previamente
        /// </summary>
        public string StringToDNI
        {
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }


        /// <summary>
        /// Constructor por defecto de la clase Persona
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Constructor parametrizado
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad) : this()
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;

        }

        /// <summary>
        /// Constructor parametrizado que recibe DNI
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>>
        /// <param name="dni">DNI de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {

            this.dni = dni;

        }

        /// <summary>
        /// Constructor parametrizado que recibe el DNI como string
        /// </summary>
        /// <param name="nombre">Nombre de la persona</param>
        /// <param name="apellido">Apellido de la persona</param>>
        /// <param name="dni">DNI de la persona</param>
        /// <param name="nacionalidad">Nacionalidad de la persona</param
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {

            this.StringToDNI = dni;
        }

        /// <summary>
        /// Se encarga de retornar datos en tipo string
        /// </summary>
        /// <returns>Retorna los datos de una persona</returns>
        public override string ToString()
        {
            return this.apellido + ", " + this.nombre + "\nNacionalidad: " + this.nacionalidad.ToString();
        }

        /// <summary>
        /// Valida un DNI si es un entero, teniendo en cuenta que 
        /// el dni Argentino debe estar entre 1 y 89999999 y el extrangero entre 90000000 y 99999999.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona</param>
        /// <param name="dato">DNI de tipo int</param>
        /// <returns>Si es valido retorna en dni, en caso contrario un excepcion</returns>
        private static int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int retornoAux = 1;

            if (nacionalidad == ENacionalidad.Argentino)
            {
                if (dato > 0 && dato < 90000000)
                {
                    retornoAux = dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException();
                }
            }

            else if (nacionalidad == ENacionalidad.Extranjero)
            {
                if (dato >= 90000000 && dato <= 99999999)
                {
                    retornoAux = dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException();
                }
            }

            return retornoAux;

        }

        /// <summary>
        /// Valida que el DNI de tipo cadena sea valido
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns>Retorna el dni validad, o si es invalido una excepcion </returns>
        private static int ValidarDni(ENacionalidad nacionalidad, string dato)
        {


            if (int.TryParse(dato, out int numero))
            {
                return ValidarDni(nacionalidad, numero);
            }
            else
            {
                throw new DniInvalidoException("Se ingreso un dato invalido");
            }



        }

        /// <summary>
        /// Valida un apellido recibido como dato, verificando que cada caracter sea una letra
        /// </summary>
        /// <param name="dato">Cadena a validad</param>
        /// <returns>Retorna el apellido validado </returns>
        private string ValidarNombreApellido(string dato)
        {
            bool esLetra;

            foreach (char c in dato)
            {
                esLetra = char.IsLetter(c);
                if (!esLetra)
                {
                    dato = "";
                    break;
                }
            }

            return dato;
        }


    }
}
