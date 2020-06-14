using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {


        public DniInvalidoException() : this("dni invalido")
        {

        }

        public DniInvalidoException(Exception e) : this(e.Message)
        {

        }

        public DniInvalidoException(string mensaje) : base(mensaje)
        {

        }
        public DniInvalidoException(string mensaje, Exception e) : base(mensaje, e)
        {

        }

    }
}
