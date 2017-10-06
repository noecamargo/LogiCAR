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
    }
}
