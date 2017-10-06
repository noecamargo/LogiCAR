using LogiCAR.CapaLogicaNegocio;
using LogiCAR.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using LogiCAR.CapaAccesoDatos;
using System.Web.Http;
using System.Web.Http.Results;

namespace LogiCAR.CapaLogicaNegocioTests
{
    [TestClass]
    public class LogicaNegocioSeguridadTest
    {
        [TestMethod]
        public void AltaUsuario()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            Usuario usuario = CrearUsuarioFalso();

            var mockRepositorioSeguridad = new Mock<IRepositorioSeguridad>();


            mockRepositorioSeguridad
                .Setup(repo => repo.AltaUsuario(usuario));

           var logicaSeguridad = new LogicaNegocioSeguridad(mockRepositorioSeguridad.Object);

            logicaSeguridad.AltaUsuario(usuario);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

            //Assert
            mockRepositorioSeguridad.VerifyAll();
            Assert.AreNotEqual(null, true);

        }

        private Usuario CrearUsuarioFalso()
        {
            Usuario usuario = new Usuario();
            usuario.Nombre = "Pedro";
            usuario.Apellido = "Perez";
            usuario.NombreUsuario = "pperez";
            usuario.Contrasenia = "peperez2015";
            usuario.Telefono = "27120515";
            usuario.Habilitado = true;
            return usuario;
        }

        [TestMethod]
        public void ModificarUsuario()
        {
            Usuario usuario = CrearUsuarioFalso();
            var mockRepositorioSeguridad = new Mock<IRepositorioSeguridad>();


            mockRepositorioSeguridad
                .Setup(repo => repo.ModificarUsuario(usuario));

            var logicaSeguridad = new LogicaNegocioSeguridad(mockRepositorioSeguridad.Object);

            logicaSeguridad.ModificarUsuario(usuario);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

            //Assert
            mockRepositorioSeguridad.VerifyAll();
            Assert.AreNotEqual(null, true);
        }

        [TestMethod]
        public void BajaUsuario()
        {
            string  nombreUsuario = CrearNombreUsuarioFalso();
            var mockRepositorioSeguridad = new Mock<IRepositorioSeguridad>();
            
            mockRepositorioSeguridad
                .Setup(repo => repo.BajaUsuario(nombreUsuario));

            var logicaSeguridad = new LogicaNegocioSeguridad(mockRepositorioSeguridad.Object);

            logicaSeguridad.BajaUsuario(nombreUsuario);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

            //Assert
            mockRepositorioSeguridad.VerifyAll();
            Assert.AreNotEqual(null, true);
        }

        private string CrearNombreUsuarioFalso()
        {
            return "vrodriguez";
        }

        public void AltaFuncionalidad()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            Funcionalidad funcion = CrearFuncionalidadFalsa();

            var mockRepositorioSeguridad = new Mock<IRepositorioSeguridad>();


            mockRepositorioSeguridad
                .Setup(repo => repo.AltaUsuario(usuario));

            var logicaSeguridad = new LogicaNegocioSeguridad(mockRepositorioSeguridad.Object);

            logicaSeguridad.AltaUsuario(usuario);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

            //Assert
            mockRepositorioSeguridad.VerifyAll();
            Assert.AreNotEqual(null, true);

        }

        private Funcionalidad CrearFuncionalidadFalsa()
        {
            Funcionalidad retorno = new Funcionalidad();
            retorno.Nombre = "Agregar Rol";
            return retorno;
             
        }

        private Usuario CrearUsuarioFalso()
        {
            Usuario usuario = new Usuario();
            usuario.Nombre = "Pedro";
            usuario.Apellido = "Perez";
            usuario.NombreUsuario = "pperez";
            usuario.Contrasenia = "peperez2015";
            usuario.Telefono = "27120515";
            usuario.Habilitado = true;
            return usuario;
        }

        [TestMethod]
        public void ModificarUsuario()
        {
            Usuario usuario = CrearUsuarioFalso();
            var mockRepositorioSeguridad = new Mock<IRepositorioSeguridad>();


            mockRepositorioSeguridad
                .Setup(repo => repo.ModificarUsuario(usuario));

            var logicaSeguridad = new LogicaNegocioSeguridad(mockRepositorioSeguridad.Object);

            logicaSeguridad.ModificarUsuario(usuario);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

            //Assert
            mockRepositorioSeguridad.VerifyAll();
            Assert.AreNotEqual(null, true);
        }

        [TestMethod]
        public void BajaUsuario()
        {
            string nombreUsuario = CrearNombreUsuarioFalso();
            var mockRepositorioSeguridad = new Mock<IRepositorioSeguridad>();

            mockRepositorioSeguridad
                .Setup(repo => repo.BajaUsuario(nombreUsuario));

            var logicaSeguridad = new LogicaNegocioSeguridad(mockRepositorioSeguridad.Object);

            logicaSeguridad.BajaUsuario(nombreUsuario);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

            //Assert
            mockRepositorioSeguridad.VerifyAll();
            Assert.AreNotEqual(null, true);
        }

        private string CrearNombreUsuarioFalso()
        {
            return "vrodriguez";
        }
        [TestMethod]
        public void AsignarFuncionalidad()
        {
            Rol rol = new Rol("OperarioPatio");
            Funcionalidad funcion = new Funcionalidad();
            funcion.Nombre = "Mover Vehiculo";
            rol.Permisos.Add(funcion);
            Assert.AreEqual(rol.Permisos.First<Funcionalidad>(), funcion);
        }
    }
}
