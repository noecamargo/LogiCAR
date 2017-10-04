using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogiCAR.Entidades.Test
{
    [TestClass]
    public class UsuarioTest
    {
        [TestMethod]
        public void AltaUsuario()
        {
            Usuario usuario = new Usuario();
            usuario.Nombre = "Pedro";
            usuario.Apellido = "Perez";
            usuario.NombreUsuario = "pperez";
            usuario.Contrasenia = "peperez2015";
            usuario.Telefono = "27120515";
            Assert.AreNotEqual(null, usuario);
        }
    }
}
