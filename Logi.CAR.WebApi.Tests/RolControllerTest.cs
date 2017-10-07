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
    public class RolControllerTests
    {
        [TestMethod]
        public void AltaRol()
        {
            //Arrange
            Rol rol = GenerarRol();

            var mockLogicaNegocioSeguridad = new Mock<ILogicaNegocioSeguridad>();
            mockLogicaNegocioSeguridad
                .Setup(bl => bl.AltaRol(rol))
                    .Returns(true);

            var controller = new RolController(mockLogicaNegocioSeguridad.Object);

            //Act
            IHttpActionResult obtainedResult = controller.Post(rol);
            var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Rol>;

            //Assert
            mockLogicaNegocioSeguridad.VerifyAll();
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(rol, createdResult.Content.Nombre);
        }

        [TestMethod]
        public void ObtenerRol()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            string nombreRol = "Operario Puerto";
            Rol rol = GenerarRol();
            var mockLogicaNegocioSeguridad = new Mock<ILogicaNegocioSeguridad>();
            mockLogicaNegocioSeguridad
                .Setup(bl => bl.ObtenerRol((nombreRol)));
             
            var controller = new RolController(mockLogicaNegocioSeguridad.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult obtainedResult = controller.Get(nombreRol);

            //Assert
            var contentResult = obtainedResult as OkNegotiatedContentResult<Rol>;
            mockLogicaNegocioSeguridad.VerifyAll();
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(nombreRol, contentResult.Content.Nombre);
        }

        [TestMethod]
        public void ObtenerRoles()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            var roles = GenerarRoles();
            var mockLogicaNegocioSeguridad = new Mock<ILogicaNegocioSeguridad>();
            mockLogicaNegocioSeguridad
                .Setup(bl => bl.ObtenerRoles())
                .Returns(roles);

            var controller = new FuncionalidadController(mockLogicaNegocioSeguridad.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult obtainedResult = controller.Get();

            //Assert
            var contentResult = obtainedResult as OkNegotiatedContentResult<IEnumerable<Rol>>;
            mockLogicaNegocioSeguridad.VerifyAll();
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(roles, contentResult.Content);
        }

        [TestMethod]
        public void ModificarRol()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            var rol = GenerarRol();
            var mockLogicaNegocioSeguridad = new Mock<ILogicaNegocioSeguridad>();
            mockLogicaNegocioSeguridad
                .Setup(bl => bl.ModificarRol(rol.Id,rol))
                .Returns(true);

            var controller = new RolController(mockLogicaNegocioSeguridad.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult obtainedResult = controller.Put(rol.Id,rol);

            //Assert
            var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Rol>;
            mockLogicaNegocioSeguridad.VerifyAll();
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            //Assert.AreEqual("updated", createdResult.RouteValues.ElementAt(0).Key);
            // Assert.AreEqual(true, createdResult.RouteValues.ElementAt(0).Value);

        }

        private IEnumerable<Rol> GenerarRoles()
        {
            return new List<Rol>
            {
                new Rol
                {
                   Nombre = "Alta Usuario"
                },
                 new Rol
                {
                    Nombre = "Modificar Usuario"
                }
            };

        }

        private Rol GenerarRol()
        {
            return new Rol
            {
                Id = 1,
                Nombre = "Modificar Usuario"
            };

        }
    }
}
