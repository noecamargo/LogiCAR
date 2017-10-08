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
    public class PatioControllerTests
    {
        [TestMethod]
        public void AltaPatio()
        {
            //Arrange
            var patio = CrearPatio();

            var mockLogicaPatio = new Mock<ILogicaNegocioPatio>();
            mockLogicaPatio
                .Setup(bl => bl.AltaPatio(patio))
                    .Returns(true);

            var controller = new PatioController(mockLogicaPatio.Object);

            //Act
            IHttpActionResult obtainedResult = controller.Post(patio);
            var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Patio>;

            //Assert
            mockLogicaPatio.VerifyAll();
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(patio, createdResult.Content);
        }

        [TestMethod]
        public void ObtenerPatio()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            var patio = CrearPatio();
            var mockLogicaPatio = new Mock<ILogicaNegocioPatio>();
            mockLogicaPatio
                .Setup(bl => bl.ObtenerPatio())
                .Returns(patio);

            var controller = new PatioController(mockLogicaPatio.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult obtainedResult = controller.Get();

            //Assert
            var contentResult = obtainedResult as OkNegotiatedContentResult<Patio>;
            mockLogicaPatio.VerifyAll();
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(patio, contentResult.Content);
        }


        [TestMethod]
        public void ModificarPatio()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            var patio = CrearPatio();
            var mockLogicaPatio = new Mock<ILogicaNegocioPatio>();
            mockLogicaPatio
                .Setup(bl => bl.ModificarPatio(patio))
                .Returns(true);

            var controller = new PatioController(mockLogicaPatio.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult obtainedResult = controller.Put(patio);

            //Assert
            var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Patio>;
            mockLogicaPatio.VerifyAll();
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
          

        }



        private Patio CrearPatio()
        {
            Patio patio = new Patio();
            patio.Nombre = "Patio Principal";
            patio.Id = 1;
            return patio;
        }


    }
}
