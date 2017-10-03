using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogiCAR.Entidades;

namespace LogiCAR.Entidades.Test
{
    [TestClass]
    public class VehiculoTest
    {
        [TestMethod]
        public void CrearVehiculo()
        {
            Vehiculo vehiculo = new Vehiculo();
            vehiculo.VIN = Guid.NewGuid();
            vehiculo.Marca = "Peugeot";
            vehiculo.Modelo = "208";
            vehiculo.Color = "azul";
            vehiculo.Anio = "2014";

            Assert.IsNotNull(vehiculo);
            Assert.IsNotNull(vehiculo.VIN);
            Assert.IsNotNull(vehiculo.Marca);
            Assert.IsNotNull(vehiculo.Modelo);
            Assert.IsNotNull(vehiculo.Color);
            Assert.IsNotNull(vehiculo.Anio);
        }
    }
}
