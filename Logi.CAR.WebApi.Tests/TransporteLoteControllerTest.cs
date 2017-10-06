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
        public void CrearLoteController()
        {
            var transporte = GenerarTransporteLote();
            var mockTransporteLogica = new Mock<ILogicaNegocioTransporteLote>();
            mockTransporteLogica
                 .Setup(il => il.CrearLote(transporte))
                 .Returns(transporte.id);

            var controller = new LoteController(mockTransporteLogica.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult obtainedResult = controller.Post(lote);

            //Assert
            var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Lote>;
            mockTransporteLogica.VerifyAll();
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(1, createdResult.Content.Id);

        }

        private object GenerarTransporteLote()
        {
            return new TransporteLote
            {
                Id = -1,
                Creador = new Usuario(),
                FechaInicio = DateTime.Today,
                FechaFin = DateTime.Today,
                Lotes = new List<Lote>()
            };
        }
    }
}

