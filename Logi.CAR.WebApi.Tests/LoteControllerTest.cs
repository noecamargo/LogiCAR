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
    public class LoteControllerTest
    {
        [TestMethod]
        public void CrearLoteController()
        {
            var lote = GenerarLote();

            var mockLoteLogica = new Mock<ILogicaNegocioLote>();
            mockLoteLogica
                 .Setup(il => il.CrearLote(lote))
                 .Returns(lote.Id);

            var controller = new LoteController(mockLoteLogica.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult obtainedResult = controller.Post(lote);

            //Assert
            var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Lote>;
            mockLoteLogica.VerifyAll();
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(1, createdResult.Content.Id);

        }

        [TestMethod]
        public void ObtenerLote()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            var lote = GenerarLote();
            var mockLoteLogica = new Mock<ILogicaNegocioLote>();
            mockLoteLogica
                .Setup(bl => bl.ObtenerLote(lote.Id))
                .Returns(lote);

            var controller = new LoteController(mockLoteLogica.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult resultadoObtenido = controller.Get(lote.Id);

            //Assert
            var contentResult = resultadoObtenido as OkNegotiatedContentResult<Lote>;
            mockLoteLogica.VerifyAll();
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(lote, contentResult.Content);
        }

        [TestMethod]
        public void ObtenerLotees()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            var lotees = GenerarLotees();
            var mockLoteesLogica = new Mock<ILogicaNegocioLote>();
            mockLoteesLogica
                .Setup(bl => bl.ObtenerLotees())
                .Returns(lotees);

            var controller = new LoteController(mockLoteesLogica.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult resultadoObtenido = controller.Get();

            //Assert
            var contentResult = resultadoObtenido as OkNegotiatedContentResult<IEnumerable<Lote>>;
            mockLoteesLogica.VerifyAll();
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(lotees, contentResult.Content);
        }

        [TestMethod]
        public void ModificarLote()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            var lote = GenerarLote();
            var mockLoteesLogica = new Mock<ILogicaNegocioLote>();
            mockLoteesLogica
                .Setup(bl => bl.ActualizarLote(lote.Id, lote))
                .Returns(true);

            var controller = new LoteController(mockLoteesLogica.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult obtainedResult = controller.Put(lote.Id, lote);

            //Assert
            var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Lote>;
            mockLoteesLogica.VerifyAll();
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual("updated", createdResult.RouteValues.ElementAt(0).Key);
            Assert.AreEqual(true, createdResult.RouteValues.ElementAt(0).Value);

        }

        private Lote GenerarLote()
        {
            return new Lote
            {
                Id = -1,
                Creador = new Usuario(),
                Nombre = "Lote 2",
                Decripcion = "desc Lote 2",
                ProntoParaPartida = false,
                Vehiculos = new List<Vehiculo>()
            };
        }

        private IEnumerable<Lote> GenerarLotees()
        {
            return new List<Lote>
            {
                new Lote
                {
                    Id = -1,
            Creador = new Usuario(),
            Nombre = "Lote 3",
            Decripcion = "desc Lote 3",
            ProntoParaPartida = false,
            Vehiculos = new List<Vehiculo>()
                },
                 new Lote
                {
                     Id = -1,
            Creador = new Usuario(),
            Nombre = "Lote 4",
            Decripcion = "desc Lote 4",
            ProntoParaPartida = false,
            Vehiculos = new List<Vehiculo>()
                }
            };

        }
    }
}
