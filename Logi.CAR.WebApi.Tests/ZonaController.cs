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
        public class ZonaControllerTests
        {
            [TestMethod]
            public void AltaZona()
            {
                //Arrange
                var zona = AltaZonaFalse();

                var mockLogicaPatio = new Mock<ILogicaNegocioPatio>();
                mockLogicaPatio
                    .Setup(bl => bl.AltaZona(zona))
                        .Returns(true);

                var controller = new ZonaController(mockLogicaPatio.Object);

                //Act
                IHttpActionResult obtainedResult = controller.Post(zona);
                var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Zona>;

                //Assert
                mockLogicaPatio.VerifyAll();
                Assert.IsNotNull(createdResult);
                Assert.AreEqual("DefaultApi", createdResult.RouteName);
                Assert.AreEqual(zona, createdResult.Content);
            }

        private Zona AltaZonaFalse()
        {
            Zona zona = new Zona();
            zona.Nombre = "Zona1";
            zona.Capacidad = 20;
            return zona;
        }

        [TestMethod]
            public void ObtenerZona()
            {
                //Arrange: Construimos el mock y seteamos las expectativas
                var zona = AltaZonaFalse();
                var mockLogicaPatio = new Mock<ILogicaNegocioPatio>();
                mockLogicaPatio
                    .Setup(bl => bl.ObtenerZona(1))
                    .Returns(zona);

                var controller = new ZonaController(mockLogicaPatio.Object);

                //Act: Efectuamos la llamada al controller
                IHttpActionResult obtainedResult = controller.Get();

                //Assert
                var contentResult = obtainedResult as OkNegotiatedContentResult<Zona>;
                mockLogicaPatio.VerifyAll();
                Assert.IsNotNull(contentResult);
                Assert.IsNotNull(contentResult.Content);
                Assert.AreEqual(zona, contentResult.Content);
            }

           
            [TestMethod]
            public void ModificarPatio()
            {
                //Arrange: Construimos el mock y seteamos las expectativas
                var zona = CrearPatio();
                var mockLogicaPatio = new Mock<ILogicaNegocioPatio>();
                mockLogicaPatio
                    .Setup(bl => bl.ModificarZona(zona))
                    .Returns(true);

                var controller = new ZonaController(mockLogicaPatio.Object);

                //Act: Efectuamos la llamada al controller
                IHttpActionResult obtainedResult = controller.Put(zona);

                //Assert
                var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Zona>;
                mockLogicaPatio.VerifyAll();
                Assert.IsNotNull(createdResult);
                Assert.AreEqual("DefaultApi", createdResult.RouteName);
                //Assert.AreEqual("updated", createdResult.RouteValues.ElementAt(0).Key);
                //Assert.AreEqual(true, createdResult.RouteValues.ElementAt(0).Value);

            }

           

            private Zona CrearPatio()
            {
                Zona zona = new Zona();
                zona.Nombre = "Zona Principal";
                return zona;
            }

        }
    
}
