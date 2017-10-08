using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiCAR.Entidades.Test
{
    [TestClass]
    public class SubZonaTest
    {
        [TestMethod]
        public void CrearSubZona()
        {
            SubZona subZona = new SubZona();
            subZona.Nombre = "Lavado";
            subZona.Capacidad = 5;
            Assert.AreNotEqual(null, subZona);
        }
    }
}
