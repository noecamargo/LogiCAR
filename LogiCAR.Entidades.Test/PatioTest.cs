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
        public void CrearPatio()
        {
            Patio patio = new Patio();
            patio.Nombre = "Patio Principal";
            Assert.AreNotEqual(null, patio);
        }



    }
}
