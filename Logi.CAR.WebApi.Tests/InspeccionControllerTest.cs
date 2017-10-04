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
    public class InspeccionControllerTest
    {
        [TestMethod]
        public void CrearInspeccionController()
        {
            var inspeccion = GenerarInspeccion();

            var mockInspeccionLogica = new Mock<ILogicaNegocioInspeccion>();
            mockInspeccionLogica
                 .Setup(il => il.CrearInspeccion(inspeccion))
                 .Returns(inspeccion.Id);

            var controller = new InspeccionController(mockInspeccionLogica.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult obtainedResult = controller.Post(inspeccion);

            //Assert
            var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Inspeccion>;
            mockInspeccionLogica.VerifyAll();
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(1, createdResult.Content.Id);


        }

        [TestMethod]
        public void ObtenerInspeccion()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            var inspeccion = GenerarInspeccion();
            var mockInspeccionLogica = new Mock<ILogicaNegocioInspeccion>();
            mockInspeccionLogica
                .Setup(bl => bl.ObtenerInspeccion(inspeccion.Id))
                .Returns(inspeccion);

            var controller = new InspeccionController(mockInspeccionLogica.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult resultadoObtenido = controller.Get(inspeccion.Id);

            //Assert
            var contentResult = resultadoObtenido as OkNegotiatedContentResult<Inspeccion>;
            mockInspeccionLogica.VerifyAll();
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(inspeccion, contentResult.Content);
        }

        private Inspeccion GenerarInspeccion()
        {
            return new Inspeccion
            {
                Id = 1,
                Creacion = DateTime.Today,
                Vehiculo = new Vehiculo(),
                Usuario = new Usuario(),
                Danio = new Danio()
            };
        }
    }
}
