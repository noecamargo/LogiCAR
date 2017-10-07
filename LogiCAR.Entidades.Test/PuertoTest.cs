using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogiCAR.Entidades.Test
{
    [TestClass]
    public class PuertoTest
    {

        [TestMethod]
        public void CrearPuerto()
        {
            Puerto puerto = new Puerto();
            puerto.Nombre = "PuertoMontevideo";
        }
    }
}
