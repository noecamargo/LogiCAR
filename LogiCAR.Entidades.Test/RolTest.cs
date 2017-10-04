using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogiCAR.Entidades.Test
{
    [TestClass]
    public class RolTest
    {
        [TestMethod]
        public void AltaRol()
        {
            Rol rol = new Rol("Admin");
            Assert.AreNotEqual(null, rol);
        }
    }
}
