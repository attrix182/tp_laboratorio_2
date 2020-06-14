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
        /// Test unitario que crea un Alumno con un DNI invalido y prueba la excepcion DniInvalidoException
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
        /// Test que crea un Alumno con Nacionalidad invalida para comprobar el funcionamiento de NacionalidadInvalidaException
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
        /// Test que crea una universidad sin profesor para probar SinProfesorException
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
        /// Test unitario que crear e intenta agregar DOS Alumnos IGUALES, para comprobar AlumnoRepetidoException
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







        /// <summary>
        /// Test que mediante AllItemsAreNotNull, Comprueba si todos los elementos de la colección Alumnos
        /// no son nulos.
        /// </summary>
        [TestMethod]
        public void TestColeccionAlumnos()
        {

            Universidad uni = new Universidad();

            CollectionAssert.AllItemsAreNotNull(uni.Alumnos);

        }




        /// <summary>
        /// Test que mediante AllItemsAreNotNull, Comprueba si todos los elementos de la colección Jornadas
        /// no son nulos
        /// </summary>
        [TestMethod]
        public void TestColeccionJornadas()
        {

            Universidad uni = new Universidad();

            CollectionAssert.AllItemsAreNotNull(uni.Jornadas);
        }


        /// <summary>
        /// Test que mediante AllItemsAreNotNull, Comprueba si todos los elementos de la colección profesores
        /// no son nulos
        /// </summary>
        [TestMethod]
        public void TestColeccionProfesores()
        {

            Universidad uni = new Universidad();

            CollectionAssert.AllItemsAreNotNull(uni.Instructores);
        }




    }

}
