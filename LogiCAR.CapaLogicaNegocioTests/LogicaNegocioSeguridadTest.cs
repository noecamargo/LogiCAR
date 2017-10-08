using LogiCAR.CapaLogicaNegocio;
using LogiCAR.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using LogiCAR.CapaAccesoDatos;


namespace LogiCAR.CapaLogicaNegocioTests
{
    [TestClass]
    public class LogicaNegocioSeguridadTest
    {
        [TestMethod]
        public void AltaUsuario()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            Usuario usuario = Utilidades.CrearUsuarioFalso();

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

        [TestMethod]
        public void ModificarUsuario()
        {
            Usuario usuario = Utilidades.CrearUsuarioFalso();
            var mockRepositorioSeguridad = new Mock<IRepositorioSeguridad>();


            mockRepositorioSeguridad
                .Setup(repo => repo.ModificarUsuario(usuario.Id,usuario));

            var logicaSeguridad = new LogicaNegocioSeguridad(mockRepositorioSeguridad.Object);

            logicaSeguridad.ModificarUsuario(usuario.Id,usuario);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

            //Assert
            mockRepositorioSeguridad.VerifyAll();
            Assert.AreNotEqual(null, true);
        }

     

        [TestMethod]
        public void BajaUsuario()
        {
            string  nombreUsuario = Utilidades.CrearNombreUsuarioFalso();
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
       

        [TestMethod]
        public void AltaFuncionalidad()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            Funcionalidad funcion = CrearFuncionalidadFalsa();

            var mockRepositorioSeguridad = new Mock<IRepositorioSeguridad>();


            mockRepositorioSeguridad
                .Setup(repo => repo.AltaFuncionalidad(funcion));

            var logicaSeguridad = new LogicaNegocioSeguridad(mockRepositorioSeguridad.Object);

            logicaSeguridad.AltaFuncionalidad(funcion.Nombre);
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

        [TestMethod]
        public void ModificarFuncionalidad()
        {
            Usuario usuario = Utilidades.CrearUsuarioFalso();
            var mockRepositorioSeguridad = new Mock<IRepositorioSeguridad>();


            mockRepositorioSeguridad
                .Setup(repo => repo.ModificarFuncionalidad("Agregar Rol"))
                .Returns(true); 

            var logicaSeguridad = new LogicaNegocioSeguridad(mockRepositorioSeguridad.Object);

            logicaSeguridad.ModificarUsuario(usuario.Id,usuario);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

            //Assert
            mockRepositorioSeguridad.VerifyAll();
            Assert.AreNotEqual(null, true);
        }

      
        [TestMethod]
        public void AsignarFuncionalidad()
        {
            Funcionalidad funcion = CrearFuncionalidadFalsa();
            var mockRepositorioSeguridad = new Mock<IRepositorioSeguridad>();


            mockRepositorioSeguridad
                .Setup(repo => repo.AsignarFuncionalidad("Admin", funcion))
                .Returns(true);

            var logicaSeguridad = new LogicaNegocioSeguridad(mockRepositorioSeguridad.Object);

            logicaSeguridad.AsignarFuncionalidad("Admin", funcion.Nombre);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

            //Assert
            mockRepositorioSeguridad.VerifyAll();
            Assert.AreNotEqual(null, true);
           
        }

        [TestMethod]
        public void AltaRol()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            Rol rol = CrearRolFalso();

            var mockRepositorioSeguridad = new Mock<IRepositorioSeguridad>();


            mockRepositorioSeguridad
                .Setup(repo => repo.AltaRol(rol));

            var logicaSeguridad = new LogicaNegocioSeguridad(mockRepositorioSeguridad.Object);

            logicaSeguridad.AltaRol(rol);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

            //Assert
            mockRepositorioSeguridad.VerifyAll();
            Assert.AreNotEqual(null, true);

        }

        private Rol CrearRolFalso()
        {
            Rol rol = new Rol();
            rol.Nombre = "Admin";
            rol.Permisos = new List<Funcionalidad>();
            Funcionalidad funcion = new Funcionalidad();
            funcion.Nombre = "Alta Zona";
            rol.Permisos.Add(funcion);
            return rol;

        }

        [TestMethod]
        void AsignarRol()
        {
            string nombreUsuario = "pperez";
            string nombreRol = "Admin";
            
            var mockRepositorioSeguridad = new Mock<IRepositorioSeguridad>();


            mockRepositorioSeguridad
                .Setup(repo => repo.AsignarRol(nombreUsuario, nombreRol))
                .Returns(true);

            var logicaSeguridad = new LogicaNegocioSeguridad(mockRepositorioSeguridad.Object);

            logicaSeguridad.AsignarFuncionalidad(nombreRol, nombreRol);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

            //Assert
            mockRepositorioSeguridad.VerifyAll();
            Assert.AreNotEqual(null, true);

        }
        [TestMethod]
        void ObtenerFuncionalidades()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            var funcionalidades = Utilidades.CrearFuncionalidadesDummy();
            var mockRepositorioSeguridad = new Mock<IRepositorioSeguridad>();

            mockRepositorioSeguridad
                .Setup(repo => repo.ObtenerFuncionalidades());

            var logicaSeguridad = new LogicaNegocioSeguridad(mockRepositorioSeguridad.Object);

            logicaSeguridad.ObtenerFuncionalidades();
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

            //Assert
            mockRepositorioSeguridad.VerifyAll();
            Assert.AreNotEqual(null, true);
        }

        
        [TestMethod]
        void ObtenerRoles()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            var roles = Utilidades.CrearRolesDummy();
            var mockRepositorioSeguridad = new Mock<IRepositorioSeguridad>();

            mockRepositorioSeguridad
                .Setup(repo => repo.ObtenerRoles());

            var logicaSeguridad = new LogicaNegocioSeguridad(mockRepositorioSeguridad.Object);

            logicaSeguridad.ObtenerRoles();
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

            //Assert
            mockRepositorioSeguridad.VerifyAll();
            Assert.AreNotEqual(null, true);
        }

     
        [TestMethod]
        void ObtenerUsuarios()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            var usuarios = Utilidades.CrearUsuariosDummy();
            var mockRepositorioSeguridad = new Mock<IRepositorioSeguridad>();

            mockRepositorioSeguridad
                .Setup(repo => repo.ObtenerUsuarios());

            var logicaSeguridad = new LogicaNegocioSeguridad(mockRepositorioSeguridad.Object);

            logicaSeguridad.ObtenerUsuarios();
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

            //Assert
            mockRepositorioSeguridad.VerifyAll();
            Assert.AreNotEqual(null, true);
        }

      
        [TestMethod]
        void ObtenerFuncionalidad()
        {

            //Arrange: Construimos el mock y seteamos las expectativas
            Funcionalidad funcion = new Funcionalidad();
            string nombreFuncionalidad = "Agregar Vehiculo";
            var mockRepositorioSeguridad = new Mock<IRepositorioSeguridad>();

            mockRepositorioSeguridad
                .Setup(repo => repo.ObtenerFuncionalidad(nombreFuncionalidad));

            var logicaSeguridad = new LogicaNegocioSeguridad(mockRepositorioSeguridad.Object);

            logicaSeguridad.ObtenerFuncionalidad(nombreFuncionalidad);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

            //Assert
            mockRepositorioSeguridad.VerifyAll();
            Assert.AreNotEqual(null, true);

        }
        [TestMethod]
        void ObtenerRol()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            string nombreRol = "Admin";
            var mockRepositorioSeguridad = new Mock<IRepositorioSeguridad>();

            mockRepositorioSeguridad
                .Setup(repo => repo.ObtenerRol(nombreRol));

            var logicaSeguridad = new LogicaNegocioSeguridad(mockRepositorioSeguridad.Object);

            Rol rol = logicaSeguridad.ObtenerRol(nombreRol);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

            //Assert
            mockRepositorioSeguridad.VerifyAll();
            Assert.AreEqual(rol.Nombre, "Admin");
        }
        [TestMethod]
        void ObtenerUsuario()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            string nombreUsuario = "pperez";
            var mockRepositorioSeguridad = new Mock<IRepositorioSeguridad>();

            mockRepositorioSeguridad
                .Setup(repo => repo.ObtenerUsuario(nombreUsuario));

            var logicaSeguridad = new LogicaNegocioSeguridad(mockRepositorioSeguridad.Object);

            Usuario usuarioRetorno = logicaSeguridad.ObtenerUsuario(nombreUsuario);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

            //Assert
            mockRepositorioSeguridad.VerifyAll();
            Assert.AreEqual(nombreUsuario, usuarioRetorno.NombreUsuario);
        }

        [TestMethod]
        void ModificarRol()
        {

            //Arrange: Construimos el mock y seteamos las expectativas
            Rol rol = CrearRolFalso();
            var mockRepositorioSeguridad = new Mock<IRepositorioSeguridad>();

            mockRepositorioSeguridad
                .Setup(repo => repo.ModificarRol(1,rol));

            var logicaSeguridad = new LogicaNegocioSeguridad(mockRepositorioSeguridad.Object);

            bool retorno = logicaSeguridad.ModificarRol(1,rol);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

            //Assert
            mockRepositorioSeguridad.VerifyAll();
            Assert.AreEqual(true, retorno);

        }


        //void BajaRol()
        //{
        //    //Arrange: Construimos el mock y seteamos las expectativas
        //    string nombre = "Operario Puerto";
        //    var mockRepositorioSeguridad = new Mock<IRepositorioSeguridad>();

        //    mockRepositorioSeguridad
        //        .Setup(repo => repo.BajaRol(nombre));

        //    var logicaSeguridad = new LogicaNegocioSeguridad(mockRepositorioSeguridad.Object);

        //    bool retorno = logicaSeguridad.BajaRol(nombre);
        //    //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

        //    //Assert
        //    mockRepositorioSeguridad.VerifyAll();
        //    Assert.AreEqual(true, retorno);
        //}

        [TestMethod]
        void BajaFuncionalidad()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            string nombreFuncionalidad = "Operario Puerto";
            var mockRepositorioSeguridad = new Mock<IRepositorioSeguridad>();

            mockRepositorioSeguridad
                .Setup(repo => repo.BajaFuncionalidad(nombreFuncionalidad));

            var logicaSeguridad = new LogicaNegocioSeguridad(mockRepositorioSeguridad.Object);

            bool retorno = logicaSeguridad.BajaFuncionalidad(nombreFuncionalidad);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

            //Assert
            mockRepositorioSeguridad.VerifyAll();
            Assert.AreEqual(true, retorno);
        }
       

    }
}
