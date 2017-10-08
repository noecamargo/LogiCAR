using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogiCAR.Entidades;
using System.Collections.Generic;
using LogiCAR.CapaAccesoDatos;

namespace LogiCAR.CapaAccesoDatos.Tests
{
    [TestClass]
    public class RepositorioSeguridadTest
    {
        private IRepositorioSeguridad repositorio = new RepositorioSeguridad();

        [TestMethod]
        public void LogIn()
        {            
            Guid guid = repositorio.LogIn("pperez","password");
            Assert.AreNotEqual(Guid.Empty, guid);
        }

        [TestMethod]
        public void LogOff()
        {
            string nombreUsuario = "pperez";
            bool retorno = repositorio.LogOff(nombreUsuario);
            Assert.AreEqual(true, retorno);
        }


        [TestMethod]
        public void AltaFuncionalidad()
        {
            Funcionalidad funcion = new Funcionalidad();
            funcion.Nombre = "Listar Vehiculos";
            bool retorno = repositorio.AltaFuncionalidad(funcion);
            Assert.AreEqual(true, retorno);
        }

        [TestMethod]
        public void AltaRol()
        {
            Rol rol = new Rol("OperarioPatio");
            bool retorno = repositorio.AltaRol(rol);
            Assert.AreEqual(true, retorno);
        }
        [TestMethod]
        public void AltaUsuario()
        {
            Usuario usuario = CrearFalsoUsuario();
            bool retorno = repositorio.AltaUsuario(usuario);
            Assert.AreEqual(true, retorno);
        }

        private Usuario CrearFalsoUsuario()
        {
            Usuario usuario = new Usuario();
            usuario.Nombre = "Pedro";
            usuario.Apellido = "Perez";
            usuario.NombreUsuario = "pperez";
            usuario.Contrasenia = "peperez2015";
            usuario.Telefono = "27120515";
            usuario.Rol = new Rol("Admin");
            return usuario;
        }

        [TestMethod]
        public void AsignarFuncionalidad(Rol rol, Funcionalidad funcionalidad)
        {
            bool retorno = repositorio.AsignarFuncionalidad(rol.Nombre, funcionalidad);
            Assert.AreEqual(true, retorno);
        }
        [TestMethod]
        public void AsignarRol(string nombreUsuario, Rol rol)
        {
            bool retorno = repositorio.AsignarRol(nombreUsuario, rol.Nombre);
            Assert.AreEqual(true, retorno);
        }
        [TestMethod]
        public void ObtenerFuncionalidades()
        {
            Funcionalidad funcion = new Funcionalidad();
            funcion.Nombre = "Agregar Rol";
            repositorio.AltaFuncionalidad(funcion);
            ICollection<Funcionalidad> retorno = repositorio.ObtenerFuncionalidades();
            Assert.AreNotEqual(0, retorno.Count);

        }
        [TestMethod]
        public void ObtenerRoles()
        {
            Rol rol = new Rol("Admin");
            repositorio.AltaRol(rol);
            ICollection<Rol> retorno = repositorio.ObtenerRoles();
            Assert.AreNotEqual(0, retorno.Count);
        }
        
        [TestMethod]
        public void ObtenerUsuarios()
        {
            Usuario usuario = CrearFalsoUsuario();
            repositorio.AltaUsuario(usuario);
            ICollection<Usuario> retorno = repositorio.ObtenerUsuarios();
            Assert.AreNotEqual(0, retorno.Count);
        }

        [TestMethod]
        void ObtenerFuncionalidad()
        {
            Funcionalidad funcion = repositorio.ObtenerFuncionalidad("Agregar Rol");
            Assert.AreEqual(funcion.Nombre, "Agregar Rol");
        }

        [TestMethod]
        void ObtenerRol()
        {
            Rol rolRetornado = repositorio.ObtenerRol("Admin");
            Assert.AreEqual(rolRetornado.Nombre,"Admin");
        }
        [TestMethod]
        void  ObtenerUsuario()
        {
            AltaUsuario();
            Usuario usuario = repositorio.ObtenerUsuario("pperez");
            Assert.AreEqual(usuario.NombreUsuario, "pperez");
        }
        //void BajaRol(string nombre);
        [TestMethod]
        void BajaUsuario(string nombreUsuario)
        {
           bool retorno = repositorio.BajaUsuario(nombreUsuario);
            Assert.AreEqual(true, retorno);
        }
        //void BajaFuncionalidad(string nombreFuncionalidad) { }

        [TestMethod]

        public void ModificarRol()
        {
            bool retorno = repositorio.ModificarRol(CrearFalsoRol());
            Assert.AreEqual("true", retorno);
        }
        
        private Rol CrearFalsoRol()
        {
            Rol rol = new Rol();
            rol.Nombre = "Admin";
            rol.Permisos = new List<Funcionalidad>();
            Funcionalidad funcion = new Funcionalidad();
            funcion.Nombre = "Crear Lote";
            rol.Permisos.Add(funcion);
            return rol;
        }

        [TestMethod]
        void ModificarUsuario()
        {
            Usuario usuario = CrearFalsoUsuario();
            bool retorno = repositorio.ModificarUsuario(usuario);
            Assert.AreEqual("true", retorno);
        }
        [TestMethod]
        void ModificarFuncionalidad(string nombreFuncionalidad)
        {
            Funcionalidad usuario = CrearFalsaFuncionalidad();
            repositorio.ModificarFuncionalidad("Agregar Zona");
            Assert.AreEqual("true", true);
        }

        private Funcionalidad CrearFalsaFuncionalidad()
        {
            Funcionalidad funcion = new Funcionalidad();
            funcion.Nombre = "Agregar Zona";
            return funcion;
        }
    }
}
