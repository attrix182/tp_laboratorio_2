using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Archivos;
using ClasesInstanciables;
using Excepciones;
using EntidadesAbstractas;



namespace Pruebas
{
    [TestClass]
    public class TestsUnitarios
    {

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestDniInvalido()
        {
            try
            {
                Alumno a = new Alumno(2, "Juan", "Perez", "1abc5678", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestNacionalidadInvalida()
        {
            try
            {
                Alumno a = new Alumno(2, "Juana", "Martinez", "12234458", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }


        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestSinProfesor()
        {
            try
            {
                Universidad u = new Universidad();
                u += Universidad.EClases.Laboratorio;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(SinProfesorException));
            }
        }


        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestAlumnoRepetido()
        {
            try
            {
                Universidad uni = new Universidad();
                Alumno a = new Alumno(2, "Roberto", "Repetidor", "12334458", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                Alumno a1 = new Alumno(2, "Roberto", "Repetidor", "12334458", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

                uni += a;
                uni += a1;
            
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }






    }

}
