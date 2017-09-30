using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogiCAR.CapaLogicaNegocio;

namespace LogiCAR.CapaLogicaNegocioTests
{
    [TestClass]
    public class Inicializacion
    {

        static Patio patioPrincipal = null;
        static Puerto puertoPrincipal = null;

        [AssemblyInitialize]
        public static void BeforeAssembly(TestContext tc)
        {
         
            patioPrincipal = new Patio();
            Assert.AreNotEqual(null, patioPrincipal);

            puertoPrincipal = new Puerto();
            Assert.AreNotEqual(null, puertoPrincipal);

        }

        [AssemblyCleanup]
        public static void BeforeAssembly()
        {
            //Limpiar los datos al final de la prueba.
        }
    }
}
