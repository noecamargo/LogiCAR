using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogiCAR.WebApi.Models;

namespace LogiCAR.WebApi.Tests
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
        }
    }
}
