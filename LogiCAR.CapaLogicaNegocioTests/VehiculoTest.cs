using LogiCAR.AccesoDatos;
using LogiCAR.CapaAccesoDatos;
using LogiCAR.CapaLogicaNegocio;
using LogiCAR.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;
using System.Web.Script.Serialization;

namespace LogiCAR.CapaLogicaNegocioTests
{
    [TestClass]
    public class VehiculoTest
    {
        [TestMethod]
        public void CrearVehiculo()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            Vehiculo vehiculo = GenerarVehiculo();
            var mockVehiculoAccesoDatos = new Mock<IRepositorio>();

            mockVehiculoAccesoDatos
                .Setup(ad => ad.CrearVehiculo(vehiculo))
                .Returns(vehiculo.VIN);


            var logicaVehiculo = new LogicaNegocioVehiculo(mockVehiculoAccesoDatos.Object);

            Guid resultado = logicaVehiculo.CrearVehiculo(vehiculo);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

            //Assert
            mockVehiculoAccesoDatos.VerifyAll();
            Assert.AreEqual(resultado, vehiculo.VIN);

        }

        //private string GenerarJsonVehiculo()
        //{

        //    Vehiculo vehiculo = new Vehiculo
        //    {
        //        VIN = Guid.NewGuid(),
        //        Marca = "Peugeot",
        //        Modelo = "208",
        //        Color = "azul",
        //        Anio = "2014"
        //    };

        //    return new JavaScriptSerializer().Serialize(vehiculo);

        //}

        private Vehiculo GenerarVehiculo()
        {
            return new Vehiculo
            {
                VIN = Guid.NewGuid(),
                Marca = "Renault",
                Modelo = "Clio",
                Color = "gris",
                Anio = "2012"
            };

        }
    }
}
