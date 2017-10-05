using LogiCAR.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiCAR.CapaLogicaNegocioTests
{
    [TestClass]
    public class LogicaNegocioSeguridadTest
    {
       
        private Usuario CrearUsuario()
        {
            Usuario usuario = new Usuario();
            usuario.Nombre = "Pedro";
            usuario.Apellido = "Perez";
            usuario.NombreUsuario = "pperez";
            usuario.Contrasenia = "peperez2015";
            usuario.Telefono = "27120515";
            return usuario;
        }

        [TestMethod]
        public void AsignarRol()
        {
            Usuario usuario = CrearUsuario();
            Rol rol = new Rol("Admin");
            usuario.Rol = rol;
            Assert.AreEqual("Admin", usuario.Rol);
        }

        [TestMethod]
        public void AsignarFuncionalidad()
        {
            Rol rol = new Rol("OperarioPatio");
            Funcionalidad funcion = new Funcionalidad("Mover Vehiculo");
            rol.Permisos.Add(funcion);
            Assert.AreEqual(rol.Permisos.First<Funcionalidad>(), funcion);
        }
    }
}
