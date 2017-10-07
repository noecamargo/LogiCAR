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
    public class UsuarioControllerTests
    {
        [TestMethod]
        public void AltaUsuario()
        {
            //Arrange
            Usuario usuario = GenerarUsuarioFalso();

            var mockLogicaNegocioSeguridad = new Mock<ILogicaNegocioSeguridad>();
            mockLogicaNegocioSeguridad
                .Setup(bl => bl.AltaUsuario(usuario))
                    .Returns(1);

            var controller = new UsuarioController(mockLogicaNegocioSeguridad.Object);

            //Act
            IHttpActionResult obtainedResult = controller.Post(usuario);
            var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Rol>;

            //Assert
            mockLogicaNegocioSeguridad.VerifyAll();
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(usuario, createdResult.Content);
        }

        [TestMethod]
        public void ObtenerUsuario()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            string nombreUsuario = "pperez";
            Usuario usuario = GenerarUsuarioFalso();
           
            var mockLogicaNegocioSeguridad = new Mock<ILogicaNegocioSeguridad>();
            mockLogicaNegocioSeguridad
                .Setup(bl => bl.ObtenerUsuario(nombreUsuario))
                .Returns(usuario);

            var controller = new UsuarioController(mockLogicaNegocioSeguridad.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult obtainedResult = controller.Get(nombreUsuario);

            //Assert
            var contentResult = obtainedResult as OkNegotiatedContentResult<Rol>;
            mockLogicaNegocioSeguridad.VerifyAll();
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(usuario, contentResult.Content);
        }

        [TestMethod]
        public void ObtenerUsuarios()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            var usuarios = GenerarUsuariosFalsos();
            var mockLogicaNegocioSeguridad = new Mock<ILogicaNegocioSeguridad>();
            mockLogicaNegocioSeguridad
                .Setup(bl => bl.ObtenerUsuarios())
                .Returns(usuarios);

            var controller = new UsuarioController(mockLogicaNegocioSeguridad.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult obtainedResult = controller.Get();

            //Assert
            var contentResult = obtainedResult as OkNegotiatedContentResult<IEnumerable<Usuario>>;
            mockLogicaNegocioSeguridad.VerifyAll();
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(usuarios, contentResult.Content);
        }

        [TestMethod]
        public void ModificarUsuario()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            var usuario = GenerarUsuarioFalso();

            var mockLogicaNegocioSeguridad = new Mock<ILogicaNegocioSeguridad>();
            mockLogicaNegocioSeguridad
                .Setup(bl => bl.ModificarUsuario(usuario.Id,usuario))
                .Returns(true);

            var controller = new UsuarioController(mockLogicaNegocioSeguridad.Object);

            //Act: Efectuamos la llamada al controller
            IHttpActionResult obtainedResult = controller.Put(usuario.Id,usuario);

            //Assert
            var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Usuario>;
            mockLogicaNegocioSeguridad.VerifyAll();
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(usuario, createdResult.Content);
            //Assert.AreEqual("updated", createdResult.RouteValues.ElementAt(0).Key);
            //Assert.AreEqual(true, createdResult.RouteValues.ElementAt(0).Value);

        }

        private IEnumerable<Usuario> GenerarUsuariosFalsos()
        {
            return new List<Usuario>
            {
                new Usuario
                {
                    Id = 2,
                   Nombre = "Alejandro",
                   Apellido = "Perez",
                   NombreUsuario = "aperez",
                   Contrasenia = "alperez2017",
                   Telefono = "27121515",
                   Habilitado = true
                },
                 new Usuario
                {
                   Id = 3,
                   Nombre = "Juan Pedro",
                   Apellido = "Perez",
                   NombreUsuario = "jpperez",
                   Contrasenia = "jpperez2014",
                   Telefono = "27121414",
                   Habilitado = true
                }
            };

        }

        private Usuario GenerarUsuarioFalso()
        {
            Usuario usuario = new Usuario();
            usuario.Id = 1;
            usuario.Nombre = "Pedro";
            usuario.Apellido = "Perez";
            usuario.NombreUsuario = "pperez";
            usuario.Contrasenia = "peperez2015";
            usuario.Telefono = "27120515";
            usuario.Habilitado = true;
            return usuario;

        }
    }
}
