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
    public class PuertoTest
    {

        [TestMethod]
        public void CrearPuerto()
        {
            Puerto puertoPrincipal = new Puerto();
            puertoPrincipal.Nombre = "PuertoMontevideo";
        }
    }
}
