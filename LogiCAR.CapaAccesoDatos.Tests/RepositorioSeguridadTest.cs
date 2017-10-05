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
        
        private Usuario CrearUsuario()
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
        public void AltaFuncionalidad()
        {
            Funcionalidad funcion = new Funcionalidad("Listar Vehiculos");
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
            Usuario usuario = CrearUsuario();
            bool retorno = repositorio.AltaUsuario(usuario);
            Assert.AreEqual(true, retorno);
        }
        [TestMethod]
        public void AsignarFuncionalidad(Rol rol, Funcionalidad funcionalidad)
        {
            bool retorno = repositorio.AsignarFuncionalidad(rol, funcionalidad);
            Assert.AreEqual(true, retorno);
        }
        [TestMethod]
        public void AsignarRol(string nombreUsuario, Rol rol)
        {
            bool retorno = repositorio.AsignarRol(nombreUsuario, rol);
            Assert.AreEqual(true, retorno);
        }
        [TestMethod]
        public void ObtenerFuncionalidades()
        {
            Funcionalidad funcion = new Funcionalidad("Agregar Rol");
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
            Usuario usuario = CrearUsuario();
            repositorio.AltaUsuario(usuario);
            ICollection<Usuario> retorno = repositorio.ObtenerUsuarios();
            Assert.AreNotEqual(0, retorno.Count);
        }
    }
}
