using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogiCAR.Entidades;
using LogiCAR.AccesoDatos;

namespace LogiCAR.CapaAccesoDatos.Tests
{
    [TestClass]
    public class DatosVehiculoTest
    {
        private string connectionString = "Data Source = VPUY - ACAPECE; Initial Catalog = LogiCAR; Integrated Security = True; MultipleActiveResultSets=True";

        [TestMethod]
        public void InsertarVehiculo()
        {
            RepositorioSqlServer repositorio = new AccesoDatos.RepositorioSqlServer();
            
                Vehiculo vehiculo = GenerarVehiculo();
            Guid VIN = repositorio.CrearVehiculo(vehiculo);
                Assert.IsNotNull(VIN);
            
        }

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
