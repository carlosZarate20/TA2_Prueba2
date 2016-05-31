using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using TA2_GRUD;
using TA2_GRUD.Controllers;
using TA2_GRUD.Models;
using NUnit.Framework;

namespace TA2_GRUD.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        public List<Persona> LstPersona { get; set; }

       /* [Test]
        public void RegistarClienteCorrecto()
        {
            // Arrange
            Persona persona = new Persona();
            persona.Nombre = "Carlos";
            persona.Apellido = "Zarate";
            persona.DNI = "10556680";
            persona.Edad = 20;
            // Act

            // Assert
            Assert.IsNotNull(result);
        }*/
        
        [Test]
        public void ValidarSumaIgual()
        {
            HomeController controller = new HomeController();
            const int sumando1 = 3;
            const int sumando2 = 4;
            const int esperado = 7;

            var actual = controller.Suma(sumando1, sumando2);

            Assert.AreEqual(esperado, actual);
        }

        [Test]
        public void ValidarRestaNoIgual()
        {
            HomeController controller = new HomeController();
            const int resta1 = 8;
            const int resta2 = 4;
            const int esperado = 5;

            var actual = controller.Resta(resta1, resta2);

            Assert.AreNotEqual(esperado, actual);
        }
       
        [Test]
        public void TestValidarMAx()
        {
            HomeController controller = new HomeController();
            Assert.IsFalse(controller.validarMax(3),"Esta variable no es false: ");
        }
        [Test]
        public void TestArrayEquals()
        {
            String[] nombresEsperados = { "carlos", "Rances", "Juan" };
            String[] nombresActuales = { "carlos", "Rances", "Juan" };

            Assert.AreEqual(nombresEsperados, nombresActuales);
        }
        [Test]
        public void TestArrayNoEquals()
        {
            String[] nombresEsperados = { "carlos", "Rances", "Juan" };
            String[] nombresActuales = { "Jose", "Rances", "Juan" };

            Assert.AreNotEqual(nombresEsperados, nombresActuales);
        }
     



    }
}
