using LogiCAR.AccesoDatos;
using LogiCAR.CapaAccesoDatos;
using LogiCAR.CapaLogicaNegocio;
using LogiCAR.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

namespace LogiCAR.CapaLogicaNegocioTests
{
    [TestClass]
    public class VehiculoTest
    {
        [TestMethod]
        public void CrearVehiculo()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            Vehiculo vehiculo = GenerarVehiculo();
            var mockVehiculoAccesoDatos = new Mock<IRepositorioVehiculo>();

            mockVehiculoAccesoDatos
                .Setup(ad => ad.InsertarVehiculo(vehiculo))
                .Returns(true);


            var logicaVehiculo = new LogicaNegocioVehiculo(mockVehiculoAccesoDatos.Object);

            bool resultado = logicaVehiculo.CrearVehiculo(vehiculo);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

            //Assert
            mockVehiculoAccesoDatos.VerifyAll();
            Assert.AreEqual(resultado, true);

        }

        [TestMethod]
        public void ObtenerVehiculo()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            Vehiculo vehiculo = GenerarVehiculo();
            var mockVehiculoAccesoDatos = new Mock<IRepositorioVehiculo>();

            mockVehiculoAccesoDatos
                .Setup(ad => ad.ObtenerVehiculo(vehiculo.VIN))
                .Returns(vehiculo);


            var logicaVehiculo = new LogicaNegocioVehiculo(mockVehiculoAccesoDatos.Object);

            Vehiculo resultado = logicaVehiculo.ObtenerVehiculo(vehiculo.VIN);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

            //Assert
            mockVehiculoAccesoDatos.VerifyAll();
            Assert.IsNotNull(resultado);
            Assert.AreEqual(resultado, vehiculo);
        }

        [TestMethod]
        public void ObtenerVehiculos()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            ICollection<Vehiculo> vehiculos = GenerarVehiculos();
            var mockVehiculoAccesoDatos = new Mock<IRepositorioVehiculo>();

            mockVehiculoAccesoDatos
                .Setup(ad => ad.ObtenerVehiculos())
                .Returns(vehiculos);


            var logicaVehiculo = new LogicaNegocioVehiculo(mockVehiculoAccesoDatos.Object);

            IEnumerable <Vehiculo> resultado = logicaVehiculo.ListaVehiculos();
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

            //Assert
            mockVehiculoAccesoDatos.VerifyAll();
            Assert.IsNotNull(resultado);
            Assert.AreEqual(resultado, vehiculos);
        }

        [TestMethod]
        public void ActualizarVehiculo()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            Vehiculo vehiculo = GenerarVehiculo();
            var mockVehiculoAccesoDatos = new Mock<IRepositorioVehiculo>();

            mockVehiculoAccesoDatos
                .Setup(ad => ad.ActualizarVehiculo(vehiculo.VIN,vehiculo))
                .Returns(true);


            var logicaVehiculo = new LogicaNegocioVehiculo(mockVehiculoAccesoDatos.Object);

            bool resultado = logicaVehiculo.ActualizarVehiculo(vehiculo.VIN,vehiculo);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

            //Assert
            mockVehiculoAccesoDatos.VerifyAll();
            Assert.IsNotNull(resultado);
            Assert.AreEqual(true, resultado);
        }

        private Vehiculo GenerarVehiculo()
        {
            return new Vehiculo
            {
                VIN = Guid.NewGuid(),
                Marca = "Renault",
                Modelo = "Clio",
                Color = "gris",
                Anio = "2012"
            };

        }

        private ICollection<Vehiculo> GenerarVehiculos()
        {
            return new List<Vehiculo>
            {
                new Vehiculo
                {
                    VIN = Guid.NewGuid(),
                    Marca = "Peugeot",
                    Modelo = "208",
                    Color = "azul",
                    Anio = "2014"
                },
                 new Vehiculo
                {
                    VIN = Guid.NewGuid(),
                    Marca = "Renault",
                    Modelo = "Clio",
                    Color = "gris",
                    Anio = "2012"
                }
            };

        }
    }
}
