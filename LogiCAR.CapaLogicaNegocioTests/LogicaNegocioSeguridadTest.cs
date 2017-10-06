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
            Usuario usuario = CrearUsuarioFalso();
            var mockRepositorioSeguridad = new Mock<IRepositorioSeguridad>();


            mockRepositorioSeguridad
                .Setup(repo => repo.ModificarFuncionalidad("Agregar Rol"))
                .Returns(true); 

            var logicaSeguridad = new LogicaNegocioSeguridad(mockRepositorioSeguridad.Object);

            logicaSeguridad.ModificarUsuario(usuario);
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

            logicaSeguridad.AltaRol(rol.Nombre);
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
            var funcionalidades = CrearFuncionalidadesDummy();
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

        private IEnumerable<Funcionalidad> CrearFuncionalidadesDummy()
        {
            return new List<Funcionalidad>
            {
                new Funcionalidad
                {
                    Nombre = "Alta Zona"
                },
                new Funcionalidad
                {
                   Nombre = "Alta SubZona"
                }
            };
        }
        [TestMethod]
        void ObtenerRoles()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            var roles = CrearRolesDummy();
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

        private IEnumerable<Rol> CrearRolesDummy()
        {
            return new List<Rol>
            {
                new Rol
                {
                    Nombre = "Admin"
                },
                new Rol
                {
                   Nombre = "Operario Patio"
                }
            };
        }
        [TestMethod]
        void ObtenerUsuarios()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            var usuarios = CrearUsuariosDummy();
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

       private IEnumerable<Usuario> CrearUsuariosDummy()
        {
            List<Usuario> retorno = new List<Usuario>();
            retorno.Add(CrearUsuarioFalso());
            Usuario usuario = new Usuario();
            usuario.Nombre = "Pablo";
            usuario.Apellido = "Jeres";
            usuario.NombreUsuario = "jj2017";
            usuario.Contrasenia = "jj2017";
            usuario.Telefono = "27120000";
            usuario.Habilitado = true;
            retorno.Add(usuario);
            return retorno;
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
        void ModificarRol()
        {

            //Arrange: Construimos el mock y seteamos las expectativas
            Rol rol = CrearRolFalso();
            var mockRepositorioSeguridad = new Mock<IRepositorioSeguridad>();

            mockRepositorioSeguridad
                .Setup(repo => repo.ModificarRol(rol));

            var logicaSeguridad = new LogicaNegocioSeguridad(mockRepositorioSeguridad.Object);

            bool retorno = logicaSeguridad.ModificarRol(rol);
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
