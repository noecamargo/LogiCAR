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

        [TestMethod]
        public void ObtenerInspecciones()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            var inspecciones = GenerarInspecciones();
            var mockInspeccionesLogica = new Mock<ILogicaNegocioInspeccion>();
            mockInspeccionesLogica
                .Setup(bl => bl.ObtenerInspecciones())
                .Returns(inspecciones);

            var controller = new InspeccionController(mockInspeccionesLogica.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult resultadoObtenido = controller.Get();

            //Assert
            var contentResult = resultadoObtenido as OkNegotiatedContentResult<IEnumerable<Inspeccion>>;
            mockInspeccionesLogica.VerifyAll();
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(inspecciones, contentResult.Content);
        }

        [TestMethod]
        public void ModificarInspeccion()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            var inspeccion = GenerarInspeccion();
            var mockInspeccionesLogica = new Mock<ILogicaNegocioInspeccion>();
            mockInspeccionesLogica
                .Setup(bl => bl.ActualizarInspeccion(inspeccion.Id, inspeccion))
                .Returns(true);

            var controller = new InspeccionController(mockInspeccionesLogica.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult obtainedResult = controller.Put(inspeccion.Id, inspeccion);

            //Assert
            var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Inspeccion>;
            mockInspeccionesLogica.VerifyAll();
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual("updated", createdResult.RouteValues.ElementAt(0).Key);
            Assert.AreEqual(true, createdResult.RouteValues.ElementAt(0).Value);

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

        private IEnumerable<Inspeccion> GenerarInspecciones()
        {
            return new List<Inspeccion>
            {
                new Inspeccion
                {
                    Id = 2,
                    Creacion = DateTime.Today,
                    Danio = new Danio(),
                    Usuario = new Usuario(),
                    Vehiculo = new Vehiculo()
                },
                 new Inspeccion
                {
                    Id = 3,
                    Creacion = DateTime.Today,
                    Danio = new Danio(),
                    Usuario = new Usuario(),
                    Vehiculo = new Vehiculo()
                }
            };

        }
    }
}
