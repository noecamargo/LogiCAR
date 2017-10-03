using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net.Http;
using LogiCAR.CapaLogicaNegocio;
using LogiCAR.Entidades;
using Moq;
using System.Web.Http.Results;
using System.Web.Http;
using LogiCAR.WebApi.Controllers;

namespace LogiCAR.WebApi.Tests
{
    [TestClass]
    public class VehiculoControllerTests
    {
        [TestMethod]
        public void CrearVehiculo()
        {
            //Arrange
            var vehiculo= GenerarVehiculo();

            var mockVehiculosLogica = new Mock<ILogicaNegocioVehiculo>();
            mockVehiculosLogica
                .Setup(bl => bl.CrearVehiculo(vehiculo))
                    .Returns(vehiculo.VIN);

            var controller = new VehiculoController(mockVehiculosLogica.Object);

            //Act
            IHttpActionResult obtainedResult = controller.Post(vehiculo);
            var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

            //Assert
            mockVehiculosLogica.VerifyAll();
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(vehiculo.VIN, createdResult.RouteValues["id"]);
            Assert.AreEqual(vehiculo, createdResult.Content);
        }

        [TestMethod]
        public void ObtenerVehiculo()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            var vehiculo = GenerarVehiculo();
            var mockVehiculosLogica = new Mock<ILogicaNegocioVehiculo>();
            mockVehiculosLogica
                .Setup(bl => bl.ObtenerVehiculo(vehiculo.VIN))
                .Returns(vehiculo);

            var controller = new VehiculoController(mockVehiculosLogica.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult obtainedResult = controller.Get(vehiculo.VIN);

            //Assert
            var contentResult = obtainedResult as OkNegotiatedContentResult<Vehiculo>;
            mockVehiculosLogica.VerifyAll();
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(vehiculo, contentResult.Content);
        }

        [TestMethod]
        public void ObtenerVehiculos()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            var vehiculos = GenerarVehiculos();
            var mockVehiculosLogica = new Mock<ILogicaNegocioVehiculo>();
            mockVehiculosLogica
                .Setup(bl => bl.ListaVehiculos())
                .Returns(vehiculos);

            var controller = new VehiculoController(mockVehiculosLogica.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult obtainedResult = controller.Get();

            //Assert
            var contentResult = obtainedResult as OkNegotiatedContentResult<IEnumerable<Vehiculo>>;
            mockVehiculosLogica.VerifyAll();
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(vehiculos, contentResult.Content);
        }

        [TestMethod]
        public void ModificarVehiculo()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            var vehiculo = GenerarVehiculo();
            var mockVehiculosLogica = new Mock<ILogicaNegocioVehiculo>();
            mockVehiculosLogica
                .Setup(bl => bl.ModificarVehiculo(vehiculo.VIN,vehiculo))
                .Returns(true);

            var controller = new VehiculoController(mockVehiculosLogica.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult obtainedResult = controller.Put(vehiculo.VIN,vehiculo);

            //Assert
            var contentResult = obtainedResult as OkNegotiatedContentResult<IEnumerable<Vehiculo>>;
            mockVehiculosLogica.VerifyAll();
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(true, obtainedResult);

        }

        private IEnumerable<Vehiculo> GenerarVehiculos()
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

    }
}
