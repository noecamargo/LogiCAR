using LogiCAR.CapaLogicaNegocio;
using LogiCAR.Entidades;
using LogiCAR.WebApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace Logi.CAR.WebApi.Tests
{
    [TestClass]
    public class DanioControllerTest
    {
        [TestMethod]
        public void CrearDanio()
        {
            var danio = GenerarDanio();

            var mockdanioLogica = new Mock<ILogicaNegocioDanio>();
            mockdanioLogica
                 .Setup(il => il.CrearDanio(danio))
                 .Returns(danio.Id);

            var controller = new DanioController(mockdanioLogica.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult obtainedResult = controller.Post(danio);

            //Assert
            var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Danio>;
            mockdanioLogica.VerifyAll();
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(1, createdResult.Content.Id);


        }

        [TestMethod]
        public void Obtenerdanio()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            var danio = GenerarDanio();
            var mockdanioLogica = new Mock<ILogicaNegocioDanio>();
            mockdanioLogica
                .Setup(bl => bl.ObtenerDanio(danio.Id))
                .Returns(danio);

            var controller = new DanioController(mockdanioLogica.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult resultadoObtenido = controller.Get(danio.Id);

            //Assert
            var contentResult = resultadoObtenido as OkNegotiatedContentResult<Danio>;
            mockdanioLogica.VerifyAll();
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(danio, contentResult.Content);
        }

        [TestMethod]
        public void ObtenerDanios()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            var danios = GenerarDanios();
            var mockdanioesLogica = new Mock<ILogicaNegocioDanio>();
            mockdanioesLogica
                .Setup(bl => bl.ObtenerDanios())
                .Returns(danios);

            var controller = new DanioController(mockdanioesLogica.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult resultadoObtenido = controller.Get();

            //Assert
            var contentResult = resultadoObtenido as OkNegotiatedContentResult<IEnumerable<Danio>>;
            mockdanioesLogica.VerifyAll();
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(danios, contentResult.Content);
        }

        [TestMethod]
        public void Modificardanio()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            var danio = GenerarDanio();
            var mockdanioesLogica = new Mock<ILogicaNegocioDanio>();
            mockdanioesLogica
                .Setup(bl => bl.ActualizarDanio(danio.Id, danio))
                .Returns(true);

            var controller = new DanioController(mockdanioesLogica.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult obtainedResult = controller.Put(danio.Id, danio);

            //Assert
            var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Danio>;
            mockdanioesLogica.VerifyAll();
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual("updated", createdResult.RouteValues.ElementAt(0).Key);
            Assert.AreEqual(true, createdResult.RouteValues.ElementAt(0).Value);

        }

        private Danio GenerarDanio()
        {
            return new Danio
            {
                Id = 1,
                Descripcion = "rayon",
                Foto = new byte[0]
            };
        }

        private IEnumerable<Danio> GenerarDanios()
        {
            return new List<Danio>
            {
                new Danio
                {
                Id = 1,
                Descripcion = "rayon",
                Foto = new byte[0]
                },
                 new Danio
                {
                       Id = 1,
                    Descripcion = "luza rota",
                Foto = new byte[0]
                }
            };
        }
    }
}
