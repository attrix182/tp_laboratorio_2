using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        /// <summary>
        /// Enumerado del estado del paquete.
        /// </summary>
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }


        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        public delegate void DelegadoEstado(object emisor, EventArgs evento);
        public event DelegadoEstado InformaEstado;

        /// <summary>
        ///  Propiedad de lectura y escritura de la direccion de entrega.
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del estado.
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del Tracking ID.
        /// </summary>
        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }

        /// <summary>
        /// Constructor de la clase paquete
        /// </summary>
        /// <param name="direccionEntrega">Direccion de entrega del paquete</param>
        /// <param name="trackingID">Tracking ID paquete</param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.TrackingID = trackingID;
            this.DireccionEntrega = direccionEntrega;
            this.Estado = EEstado.Ingresado;
        }

        /// <summary>
        /// Hace que un paquete cambie de estado en un tiempo determinado
        /// </summary>
        public void MockCicloDeVida()
        {
            while (this.Estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.Estado += 1;
                this.InformaEstado(this, new EventArgs());
            }
            PaqueteDAO.Insertar(this);


        }

        /// <summary>
        /// Muestra la informacion de un paquete.
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete p = (Paquete)elemento;


            return string.Format("{0} para {1}", p.trackingID, p.direccionEntrega);
        }

        /// <summary>
        /// Retorna los datos de un paquete incluido tu estado.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this) + " " + this.Estado.ToString();
        }

        /// <summary>
        ///  Verifica si dos paquetes son iguales por su Tracking ID.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool retorno = false;

            if (!Object.Equals(p1, null) && !Object.Equals(p2, null))
            {
                if (p1.TrackingID == p2.TrackingID)
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        /// <summary>
        ///  Verifica si dos paquetes son distintos por su Tracking ID.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }



    }
}
