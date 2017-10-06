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
    public class TransporteLoteControllerTest
    {
        [TestMethod]
        public void CrearTransporteLote()
        {
            var transporte = GenerarTransporteLote();
            var mockTransporteLogica = new Mock<ILogicaNegocioTransporteLote>();
            mockTransporteLogica
                 .Setup(il => il.CrearTransporteLote(transporte))
                 .Returns(transporte.Id);

            var controller = new TransporteLoteController(mockTransporteLogica.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult obtainedResult = controller.Post(transporte);

            //Assert
            var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<TransporteLote>;
            mockTransporteLogica.VerifyAll();
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(1, createdResult.Content.Id);
        }

        [TestMethod]
        public void ObtenerTransporteLote()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            var transporte = GenerarTransporteLote();
            var mockTransporteLoteLogica = new Mock<ILogicaNegocioTransporteLote>();
            mockTransporteLoteLogica
                .Setup(bl => bl.ObtenerTransporteLote(transporte.Id))
                .Returns(transporte);

            var controller = new TransporteLoteController(mockTransporteLoteLogica.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult resultadoObtenido = controller.Get(transporte.Id);

            //Assert
            var contentResult = resultadoObtenido as OkNegotiatedContentResult<TransporteLote>;
            mockTransporteLoteLogica.VerifyAll();
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(transporte, contentResult.Content);
        }

        [TestMethod]
        public void ObtenerTransporteLotes()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            var transportes = GenerarTransporteLotes();
            var mockTransporteLotesLogica = new Mock<ILogicaNegocioTransporteLote>();
            mockTransporteLotesLogica
                .Setup(bl => bl.ObtenerTransporteLotes())
                .Returns(transportes);

            var controller = new TransporteLoteController(mockTransporteLotesLogica.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult resultadoObtenido = controller.Get();

            //Assert
            var contentResult = resultadoObtenido as OkNegotiatedContentResult<IEnumerable<TransporteLote>>;
            mockTransporteLotesLogica.VerifyAll();
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(transportes, contentResult.Content);
        }

        [TestMethod]
        public void ModificarLote()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            var transporte = GenerarTransporteLote();
            var mockTransporteLotesLogica = new Mock<ILogicaNegocioTransporteLote>();
            mockTransporteLotesLogica
                .Setup(bl => bl.ActualizarTransporteLote(transporte.Id, transporte))
                .Returns(true);

            var controller = new TransporteLoteController(mockTransporteLotesLogica.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult obtainedResult = controller.Put(transporte.Id, transporte);

            //Assert
            var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<TransporteLote>;
            mockTransporteLotesLogica.VerifyAll();
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual("updated", createdResult.RouteValues.ElementAt(0).Key);
            Assert.AreEqual(true, createdResult.RouteValues.ElementAt(0).Value);

        }

        private TransporteLote GenerarTransporteLote()
        {
            return new TransporteLote
            {
                Id = 1,
                Creador = new Usuario(),
                FechaInicio = DateTime.Today,
                FechaFin = DateTime.Today,
                Lotes = new List<Lote>()
            };
        }

        private IEnumerable<TransporteLote> GenerarTransporteLotes()
        {
            return new List<TransporteLote>
            {
            new TransporteLote
            {
                Id = 2,
                Creador = new Usuario(),
                FechaInicio = DateTime.Today,
                FechaFin = DateTime.Today,
                Lotes = new List<Lote>()
            },
             new TransporteLote
            {
                Id = 3,
                Creador = new Usuario(),
                FechaInicio = DateTime.Today,
                FechaFin = DateTime.Today,
                Lotes = new List<Lote>()
            }
            };
        }
    }
}

