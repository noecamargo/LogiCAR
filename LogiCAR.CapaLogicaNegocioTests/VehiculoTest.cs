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
        //[TestMethod]
        //public void CrearVehiculo()
        //{
        //    //Arrange: Construimos el mock y seteamos las expectativas
        //    string vehiculo = GenerarJsonVehiculo();
        //    var mockVehiculosLogica = new Mock<ILogicaNegocioVehiculo>();
            
        //    mockVehiculosLogica
        //        .Setup(bl => bl.CrearVehiculo(vehiculo))
        //        .Returns(true);


        //    var logicaVehiculo = new LogicaNegocioVehiculo(new AccesoDatos.LogiCar());

        //    //Act: Efectuamos la llamada al controller
        //    bool obtainedResult = logicaVehiculo.Put(1,vehiculo);

        //    //Assert
        //    mockVehiculosLogica.VerifyAll();
        //    Assert.AreEqual(obtainedResult, true);

        //}

        private string GenerarJsonVehiculo()
        {

            Vehiculo vehiculo = new Vehiculo
            {
                VIN = Guid.NewGuid(),
                Marca = "Peugeot",
                Modelo = "208",
                Color = "azul",
                Anio = "2014"
            };

            return new JavaScriptSerializer().Serialize(vehiculo);
            
        }

    }
}
