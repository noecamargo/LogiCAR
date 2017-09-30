using LogiCAR.CapaLogicaNegocio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiCAR.CapaLogicaNegocioTests
{
    [TestClass]
    public class PatioTest
    {
       
        [TestMethod]
        public void CrearZona()
        {
            Zona zona = new Zona();
            zona.Nombre = "Zona1";
            zona.Capacidad = 20;
            Assert.AreNotEqual(null, zona);
        }
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
