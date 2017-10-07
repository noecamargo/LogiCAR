using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;
using Moq;
using System.Collections.Generic;
using System.Web.Http.Results;
using System.Net.Http;
using LogiCAR.Entidades;
using LogiCAR.CapaLogicaNegocio;
using Logi.CAR.WebApi.Controllers;

namespace LogiCAR.WebApi.Test
{


        [TestClass]
        public class PuertoControllerTests
        {
            [TestMethod]
            public void AltaPuerto()
            {
                //Arrange
                var Puerto = CrearPuerto();

                var mockLogicaPatio = new Mock<ILogicaNegocioPatio>();
                mockLogicaPatio
                    .Setup(bl => bl.AltaPuerto(Puerto))
                        .Returns(true);

                var controller = new PuertoController(mockLogicaPatio.Object);

                //Act
                IHttpActionResult obtainedResult = controller.Post(Puerto);
                var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Puerto>;

                //Assert
                mockLogicaPatio.VerifyAll();
                Assert.IsNotNull(createdResult);
                Assert.AreEqual("DefaultApi", createdResult.RouteName);
                Assert.AreEqual(Puerto, createdResult.Content);
            }

            [TestMethod]
            public void ObtenerPuerto()
            {
                //Arrange: Construimos el mock y seteamos las expectativas
                var Puerto = CrearPuerto();
                var mockLogicaPatio = new Mock<ILogicaNegocioPatio>();
                mockLogicaPatio
                    .Setup(bl => bl.ObtenerPuerto())
                    .Returns(Puerto);

                var controller = new PuertoController(mockLogicaPatio.Object);

                //Act: Efectuamos la llamada al controller
                IHttpActionResult obtainedResult = controller.Get();

                //Assert
                var contentResult = obtainedResult as OkNegotiatedContentResult<Puerto>;
                mockLogicaPatio.VerifyAll();
                Assert.IsNotNull(contentResult);
                Assert.IsNotNull(contentResult.Content);
                Assert.AreEqual(Puerto, contentResult.Content);
            }

           
            [TestMethod]
            public void ModificarPuerto(List<Vehiculo> vehiculos)
            {
                //Arrange: Construimos el mock y seteamos las expectativas
                var Puerto = CrearPuerto();
                var mockLogicaPatio = new Mock<ILogicaNegocioPatio>();
                mockLogicaPatio
                    .Setup(bl => bl.ModificarPuerto(vehiculos))
                    .Returns(true);

                var controller = new PuertoController(mockLogicaPatio.Object);

                //Act: Efectuamos la llamada al controller
                IHttpActionResult obtainedResult = controller.Put(vehiculos);

                //Assert
                var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Puerto>;
                mockLogicaPatio.VerifyAll();
                Assert.IsNotNull(createdResult);
               }

           

            private Puerto CrearPuerto()
            {
                Puerto Puerto = new Puerto();
                Puerto.Nombre = "Puerto Principal";
                return Puerto;
            }

       
    }
}
