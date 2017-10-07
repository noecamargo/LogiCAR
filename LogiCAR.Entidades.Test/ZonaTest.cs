using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiCAR.Entidades.Test
{
    [TestClass]
    public class ZonaTest
    {
        [TestMethod]
        public void AltaZona()
        {
            ZonaTest zona = new ZonaTest();
            zona.Nombre = "Zona1";
            zona.Capacidad = 20;
            Assert.AreNotEqual(null, zona);
        }
    }
}
