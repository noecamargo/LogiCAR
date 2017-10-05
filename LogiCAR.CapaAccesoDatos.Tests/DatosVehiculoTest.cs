using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogiCAR.Entidades;
using LogiCAR.AccesoDatos;
using System.Collections.Generic;

namespace LogiCAR.CapaAccesoDatos.Tests
{
    [TestClass]
    public class DatosVehiculoTest
    {
        private RepositorioSqlServer repositorio = new AccesoDatos.RepositorioSqlServer();
       

        [TestMethod]
        public void InsertarVehiculo()
        {
            Vehiculo vehiculo = GenerarVehiculo();
            bool resultado = repositorio.InsertarVehiculo(vehiculo);
            Assert.AreEqual(true, resultado);
        }

        [TestMethod]
        public void ObtenerVehiculo()
        {
            Vehiculo vehiculoInsertar = new Vehiculo { VIN = new Guid("11223344-5566-7788-99AA-BBCCDDEEFF50"), Marca = "Ford", Modelo = "Fiesta", Color = "Gris", Anio = "2012" };
            repositorio.InsertarVehiculo(vehiculoInsertar);
            Vehiculo vehiculo = repositorio.ObtenerVehiculo(vehiculoInsertar.VIN);
            Assert.AreNotEqual(null, vehiculo);
        }

        [TestMethod]
        public void ObtenerVehiculos()
        {
            IEnumerable<Vehiculo> vehiculos = GenerarVehiculos();

            foreach (Vehiculo vehiculo in vehiculos)
            {
                repositorio.InsertarVehiculo(vehiculo);
            }

            IEnumerable<Vehiculo> listaVehiculos = repositorio.ObtenerVehiculos();
            Assert.AreNotEqual(null, listaVehiculos);

            int contidadVehiculos = 0;
            foreach (var vehiculo in vehiculos)
            {
                contidadVehiculos++;
            }
            Assert.AreEqual(2, contidadVehiculos);
        }

        [TestMethod]
        public void ModificarVehiculo()
        {
            Vehiculo vehiculoInsertar = new Vehiculo { VIN = new Guid("11223344-5566-7788-99AA-BBCCDDEEFF40"), Marca = "Renault", Modelo = "Clio", Color = "Gris", Anio = "2012" };
            bool resultadoInsercion = repositorio.InsertarVehiculo(vehiculoInsertar);
            Assert.AreEqual(true, resultadoInsercion);
            
            Vehiculo vehiculoObtenido = repositorio.ObtenerVehiculo(vehiculoInsertar.VIN);
            Assert.AreEqual(vehiculoObtenido.Color, "Gris");

            vehiculoObtenido.Color = "Rojo";
            bool resultadoActualizacion = repositorio.ActualizarVehiculo(vehiculoObtenido.VIN, vehiculoObtenido);
            Assert.AreEqual(true, resultadoActualizacion);
            Assert.AreEqual(repositorio.ObtenerVehiculo(vehiculoInsertar.VIN).Color, "Rojo");
        }

        private IEnumerable<Vehiculo> GenerarVehiculos()
        {
            return new List<Vehiculo>
            {
                new Vehiculo
                {
                    VIN = new Guid("11223344-5566-7788-99AA-BBCCDDEEFF20"),
                    Marca = "Peugeot",
                    Modelo = "208",
                    Color = "azul",
                    Anio = "2014"
                },
                 new Vehiculo
                {
                    VIN =new Guid("11223344-5566-7788-99AA-BBCCDDEEFF30"),
                    Marca = "Renault",
                    Modelo = "Clio",
                    Color = "gris",
                    Anio = "2012"
                }
            };

        }

        private Vehiculo GenerarVehiculo()
        {
            return new Vehiculo
            {
                VIN = new Guid("11223344-5566-7788-99AA-BBCCDDEEFF10"),
                Marca = "Renault",
                Modelo = "Clio",
                Color = "gris",
                Anio = "2012"
            };

        }
    }
}
