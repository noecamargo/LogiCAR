using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LogiCAR.Entidades.Test
{
    [TestClass]
    public class RolTest
    {
        [TestMethod]
        public void AltaRol()
        {
            Rol rol = new Rol("Admin");
            rol.Permisos = new List<Funcionalidad>();
            Assert.AreNotEqual(null, rol);
        }
    }
}
