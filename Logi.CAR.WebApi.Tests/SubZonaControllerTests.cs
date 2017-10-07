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
    public class SubZonaControllerTests
    {
        [TestMethod]
        public void AltaSubZona()
        {
            //Arrange
            var subZona = CrearSubZona();

            var mockLogicaPatio = new Mock<ILogicaNegocioPatio>();
            mockLogicaPatio
                .Setup(bl => bl.AltaSubZona(subZona))
                    .Returns(true);

            var controller = new SubZonaController(mockLogicaPatio.Object);

            //Act
            IHttpActionResult obtainedResult = controller.Post(subZona);
            var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<SubZona>;

            //Assert
            mockLogicaPatio.VerifyAll();
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(subZona, createdResult.Content);
        }
        [TestMethod]
        public void ObtenerSubZona(int id)
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            var subZona = CrearSubZona();
            var mockLogicaPatio = new Mock<ILogicaNegocioPatio>();
            mockLogicaPatio
                .Setup(bl => bl.ObtenerSubZona(1))
                .Returns(subZona);

            var controller = new SubZonaController(mockLogicaPatio.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult obtainedResult = controller.Get();

            //Assert
            var contentResult = obtainedResult as OkNegotiatedContentResult<SubZona>;
            mockLogicaPatio.VerifyAll();
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(subZona, contentResult.Content);
        }
        [TestMethod]
        public void ObtenerSubZona()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            var subZonas = CrearSubZonas();
            var mockLogicaPatio = new Mock<ILogicaNegocioPatio>();
            mockLogicaPatio
                .Setup(bl => bl.ObtenerSubZonas())
                .Returns(subZonas);

            var controller = new SubZonaController(mockLogicaPatio.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult obtainedResult = controller.Get();

            //Assert
            var contentResult = obtainedResult as OkNegotiatedContentResult<SubZona>;
            mockLogicaPatio.VerifyAll();
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(subZonas, contentResult.Content);
        }

       
        [TestMethod]
        public void ModificarSubZona(Zona zona)
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            var subZona = CrearSubZona();
            var mockLogicaPatio = new Mock<ILogicaNegocioPatio>();
            mockLogicaPatio
                .Setup(bl => bl.ModificarSubZona(subZona))
                .Returns(true);

            var controller = new SubZonaController(mockLogicaPatio.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult obtainedResult = controller.Put(subZona);

            //Assert
            var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<SubZona>;
            mockLogicaPatio.VerifyAll();
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
        

        }


        //[TestMethod]
        //public void BorrarSubZona()
        //{
        //    //Arrange
        //    var mockLogicaPatio = new Mock<ILogicaNegocioPatio>();
        //    mockLogicaPatio
        //        .Setup(bl => bl.BajaSubZona(1,1))
        //        .Returns(true);

        //    var controller = new SubZonaController(mockBreedsBusinessLogic.Object);
        //    // Configuramos la Request (dado que estamos utilziando HttpResponseMessage)
        //    // Y usando el objeto Request adentro.
        //    ConfigureHttpRequest(controller);

        //    //Act
        //    HttpResponseMessage obtainedResult = controller.Delete(fakeGuid);

        //    //Assert
        //    mockLogicaPatio.VerifyAll();
        //    Assert.IsNotNull(obtainedResult);
        //}

        private SubZona CrearSubZona()
        {
            SubZona subZona = new SubZona();
            subZona.Nombre = "Lavado";
            subZona.Capacidad = 5;
            return subZona;
        }

        private IEnumerable<SubZona> CrearSubZonas()
        {
            return new List<SubZona>
            {
                new SubZona
                {
                    Nombre = "Lavado",
                    Capacidad = 5
                },
                 new SubZona
                {
                    Nombre = "Pintura",
                    Capacidad = 10
                }
            };

        }

    }
}
