using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiCAR.Entidades.Test
{
    [TestClass]
    public abstract class LugarTest
    {

        [TestMethod]
        public void CrearPatio()
        {
            Lugar lugar = new Patio();
            lugar.Nombre = "PatioPrincipal";
            Assert.AreNotEqual(null, lugar);
        }

        public void CrearPuerto()
        {
            Lugar lugar = new Puerto();
            lugar.Nombre = "PatioPrincipal";
            Assert.AreNotEqual(null, lugar);
        }
    }
}
