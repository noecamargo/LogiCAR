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
        public void ObtenerVehiculos()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            var vehiculos = GenerarVehiculos();
            var mockVehiculosLogica = new Mock<ILogicaNegocioVehiculo>();
            mockVehiculosLogica
                .Setup(bl => bl.Get())
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

    //Función auxiliar
    //    private IEnumerable<Breed> GetFakeBreeds()
    //    {
    //        return new List<Breed>
    //        {
    //            new Breed
    //            {
    //                Id = new Guid("e5020d0b-6fce-4b9f-a492-746c6c8a1bfa"),
    //                Name = "Pug",
    //                HairType  = "short fur",
    //                HairColors = new List<string>
    //                {
    //                    "blonde"
    //                }
    //            },
    //            new Breed
    //            {
    //                Id = new Guid("6b718186-fa8c-4e14-9af8-2601e153db71"),
    //                Name = "Golden Retriever",
    //                HairType  = "hairy fur",
    //                HairColors = new List<string>
    //                {
    //                    "blonde"
    //                }
    //            }
    //        };
    //    }
}
}
