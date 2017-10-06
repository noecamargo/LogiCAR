using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogiCAR.Entidades.Test
{
    [TestClass]
    public class FuncionalidadTest
    {
        [TestMethod]
        public void AltaFuncionalidad()
        {
            Funcionalidad funcion = new Funcionalidad();
            funcion.Nombre = "Agregar Vehiculo";
            Assert.AreNotEqual(null, funcion);
        }
    }
}
