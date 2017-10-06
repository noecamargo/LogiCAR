using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;
using Moq;
using System.Collections.Generic;
using System.Web.Http.Results;
using System.Net.Http;
using LogiCAR.Entidades;
using LogiCAR.CapaLogicaNegocio;
using LogiCAR.WebApi.Controllers;

namespace LogiCAR.WebApi.Test
{
    [TestClass]
    public class FuncionalidadControllerTests
    {
        [TestMethod]
        public void ObtenerFuncionalidadesOkTest()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            var funcionalidades = ObtenerFuncionalidadesDummy();
            var mockLogicaNegocioSeguridad = new Mock<ILogicaNegocioSeguridad>();
            mockLogicaNegocioSeguridad
                .Setup(bl => bl.ObtenerFuncionalidades())
                .Returns(funcionalidades);

            var controller = new FuncionalidadController(mockLogicaNegocioSeguridad.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult obtainedResult = controller.Get();

            //Assert
            var contentResult = obtainedResult as OkNegotiatedContentResult<IEnumerable<Funcionalidad>>;
            mockLogicaNegocioSeguridad.VerifyAll();
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(funcionalidades, contentResult.Content);
        }

        [TestMethod]
        public void ObtenerFuncionalidadesErrorNotFoundTest()
        {
            //Arrange
            List<Funcionalidad> funcionalidades = null;

            var mockLogicaNegocioSeguridad = new Mock<ILogicaNegocioSeguridad>();
            mockLogicaNegocioSeguridad
                .Setup(bl => bl.ObtenerFuncionalidades())
                .Returns(funcionalidades);

            var controller = new FuncionalidadController(mockLogicaNegocioSeguridad.Object);

            //Act
            IHttpActionResult obtainedResult = controller.Get();

            //Assert
            mockLogicaNegocioSeguridad.VerifyAll();
            Assert.IsInstanceOfType(obtainedResult, typeof(NotFoundResult));
        }

        //Función auxiliar
        private IEnumerable<Funcionalidad> ObtenerFuncionalidadesDummy()
        {
            return new List<Funcionalidad>
            {
                new Funcionalidad
                {
                   Nombre= "Alta Usuario"
                },
                new Funcionalidad
                {
                   Nombre = "Alta Rol"
                }
            };
        }


        [TestMethod]
        public void CreateNewFuncionalidadTest()
        {
            //Arrange
            var funcionalidadFalsa = ObtenerFuncionalidadDummy();

            var mockLogicaNegocioSeguridad = new Mock<ILogicaNegocioSeguridad>();
            mockLogicaNegocioSeguridad
                .Setup(bl => bl.AltaFuncionalidad(funcionalidadFalsa))
                .Returns(true);

            var controller = new FuncionalidadController(mockLogicaNegocioSeguridad.Object);

            //Act
            IHttpActionResult obtainedResult = controller.Post(funcionalidadFalsa);
            var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Funcionalidad>;

            //Assert
            mockLogicaNegocioSeguridad.VerifyAll();
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(funcionalidadFalsa, createdResult);
            Assert.AreEqual(funcionalidadFalsa, createdResult.Content);
        }

        //Función auxiliar
        private string ObtenerFuncionalidadDummy()
        {
            return "Agregar Vehiculo";
        }


        [TestMethod]
        public void CrearNullFuncionalidadFuncionalidadErrorTest()
        {
            //Arrange
            string funcionalidad = string.Empty;

            var mockLogicaNegocioSeguridad = new Mock<ILogicaNegocioSeguridad>();
            mockLogicaNegocioSeguridad
                .Setup(bl => bl.AltaFuncionalidad(funcionalidad))
                .Throws(new ArgumentNullException());

            var controller = new FuncionalidadController(mockLogicaNegocioSeguridad.Object);

            //Act
            IHttpActionResult obtainedResult = controller.Post(funcionalidad);

            //Assert
            mockLogicaNegocioSeguridad.VerifyAll();
            Assert.IsInstanceOfType(obtainedResult, typeof(BadRequestErrorMessageResult));
        }


        [TestMethod]
        public void AltaFuncionalidad()
        {
            //Arrange
            string nombreFuncionalidad = "Alta Usuario";

            var mockLogicaNegocioSeguridad = new Mock<ILogicaNegocioSeguridad>();
            mockLogicaNegocioSeguridad
                .Setup(bl => bl.AltaFuncionalidad(nombreFuncionalidad))
                    .Returns(true);

            var controller = new FuncionalidadController(mockLogicaNegocioSeguridad.Object);

            //Act
            IHttpActionResult obtainedResult = controller.Post(nombreFuncionalidad);
            var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Funcionalidad>;

            //Assert
            mockLogicaNegocioSeguridad.VerifyAll();
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(nombreFuncionalidad, createdResult.Content.Nombre);
        }

        [TestMethod]
        public void ObtenerFuncionalidad()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            string  nombreFuncionalidad = "Modificar Usuario";
            var funcionalidad = GenerarFuncionalidad();
            var mockLogicaNegocioSeguridad = new Mock<ILogicaNegocioSeguridad>();
            mockLogicaNegocioSeguridad
                .Setup(bl => bl.ObtenerFuncionalidad(nombreFuncionalidad))
                .Returns(funcionalidad);

            var controller = new FuncionalidadController(mockLogicaNegocioSeguridad.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult obtainedResult = controller.Get(nombreFuncionalidad);

            //Assert
            var contentResult = obtainedResult as OkNegotiatedContentResult<Funcionalidad>;
            mockLogicaNegocioSeguridad.VerifyAll();
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(funcionalidad, contentResult.Content.Nombre);
        }

        [TestMethod]
        public void ObtenerFuncionalidades()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            var funcionalidades = GenerarFuncionalidades();
            var mockLogicaNegocioSeguridad = new Mock<ILogicaNegocioSeguridad>();
            mockLogicaNegocioSeguridad
                .Setup(bl => bl.ObtenerFuncionalidades())
                .Returns(funcionalidades);

            var controller = new FuncionalidadController(mockLogicaNegocioSeguridad.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult obtainedResult = controller.Get();

            //Assert
            var contentResult = obtainedResult as OkNegotiatedContentResult<IEnumerable<Funcionalidad>>;
            mockLogicaNegocioSeguridad.VerifyAll();
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(funcionalidades, contentResult.Content);
        }

        [TestMethod]
        public void ModificarFuncionalidad()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            var funcionalidad = GenerarFuncionalidad();
            var mockLogicaNegocioSeguridad = new Mock<ILogicaNegocioSeguridad>();
            mockLogicaNegocioSeguridad
                .Setup(bl => bl.ModificarFuncionalidad(funcionalidad.Nombre))
                .Returns(true);

            var controller = new FuncionalidadController(mockLogicaNegocioSeguridad.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult obtainedResult = controller.Put(funcionalidad.Nombre);

            //Assert
            var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Funcionalidad>;
            mockLogicaNegocioSeguridad.VerifyAll();
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
          //  Assert.AreEqual("updated", createdResult.RouteValues.ElementAt(0).Key);
          // Assert.AreEqual(true, createdResult.RouteValues.ElementAt(0).Value);

        }

        private IEnumerable<Funcionalidad> GenerarFuncionalidades()
        {
            return new List<Funcionalidad>
            {
                new Funcionalidad
                {
                   Nombre = "Alta Usuario"
                },
                 new Funcionalidad
                {
                    Nombre = "Modificar Usuario"
                }
            };

        }

        private Funcionalidad GenerarFuncionalidad()
        {
            return new Funcionalidad
            {
                Nombre = "Modificar Usuario"
            };

        }
    

        //[TestMethod]
        //public void DeleteFuncionalidadOkTest(string nombreFuncionalidad)
        //{
        //    //Arrange

    //    int idFuncionalidad = 1;

    //    var mockLogicaNegocioSeguridad = new Mock<ILogicaNegocioSeguridad>();
    //    mockLogicaNegocioSeguridad
    //        .Setup(logicaNegocio => logicaNegocio.BajaFuncionalidad(nombreFuncionalidad))
    //        .Returns(true);

    //    var controller = new FuncionalidadController(mockLogicaNegocioSeguridad.Object);
    //    // Configuramos la Request (dado que estamos utilziando HttpResponseMessage)
    //    // Y usando el objeto Request adentro.
    //    ConfigureHttpRequest(controller);

    //    //Act
    //    HttpResponseMessage obtainedResult = controller.Delete(idFuncionalidad);

    //    //Assert
    //    mockLogicaNegocioSeguridad.VerifyAll();
    //    Assert.IsNotNull(obtainedResult);
    //}

    //private void ConfigureHttpRequest(FuncionalidadController controller)
    //{
    //    controller.Request = new HttpRequestMessage();
    //    controller.Configuration = new HttpConfiguration();
    //    controller.Configuration.Routes.MapHttpRoute(
    //        name: "DefaultApi",
    //        routeTemplate: "api/{controller}/{id}",
    //        defaults: new { id = RouteParameter.Optional });
    //}
}
}
