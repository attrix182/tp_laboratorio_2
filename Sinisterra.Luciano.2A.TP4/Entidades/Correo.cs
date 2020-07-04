using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        /// <summary>
        /// Propiedad de lectura y escritura de la lista de paquetes del correo.
        /// </summary>
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }


        /// <summary>
        /// Constructor de la clase correo.
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        /// <summary>
        /// Se encarga de cerrar los hilos
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread hilo in this.mockPaquetes)
            {
                if (!Object.Equals(hilo, null))
                {
                    if (hilo.IsAlive)
                    {
                        hilo.Abort();
                    }
                }
            }

        }

        /// <summary>
        /// Muestra los datos de un paquete
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns>Retorna los datos de un paquete(id, direccion y estado)</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder datos = new StringBuilder();

            List<Paquete> listaPaquetes = ((Correo)elementos).Paquetes;

            foreach (Paquete p in listaPaquetes)
            {
                datos.AppendLine(string.Format("{0} para {1} ({2})", p.TrackingID, p.DireccionEntrega, p.Estado.ToString()));
            }


            return datos.ToString();

        }

        /// <summary>
        /// Agrega un paquete a la lista de paquetes dentro de correo
        /// </summary>
        /// <param name="c">Correo</param>
        /// <param name="p">Paquete</param>
        /// <returns>Retorna un correo con el paquete</returns>
        public static Correo operator +(Correo c, Paquete p)
        {

            Thread hilo = new Thread(p.MockCicloDeVida);

            foreach (Paquete paquete in c.Paquetes)
            {
                if (paquete == p)
                {
                    throw new TrackingIdRepetidoException("El tracking ID " + p.TrackingID + " ya esta en la lista de envios.");
                }
            }

            c.Paquetes.Add(p);
            c.mockPaquetes.Add(hilo);
            hilo.Start();

            return c;
        }
    }
}