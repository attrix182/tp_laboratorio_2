using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {

        /// <summary>
        /// Verifica si la lista de paquetes del correo esta instanciada.
        /// </summary>
        [TestMethod]
        public void TESTListaPaquetesInstanciada()
        {
            Correo correo = new Correo();
            Assert.IsNotNull(correo.Paquetes);
        }

        /// <summary>
        /// Verifica que no se pueda cargar dos paquetes con el mismo Tracking ID.
        /// </summary>
        [TestMethod]
        public void TESTPaquetesRepetidos()
        {
            try
            {
                Correo correo = new Correo();
                Paquete p1 = new Paquete("Chaco 1515", "123-456-7899");

                correo += p1;
                correo += p1;
                Assert.Fail("El Tracking ID ya figura en la lista de envios.");
            }
            catch (Exception error)
            {
                Assert.IsInstanceOfType(error, typeof(TrackingIdRepetidoException));
            }
        }
    }
}