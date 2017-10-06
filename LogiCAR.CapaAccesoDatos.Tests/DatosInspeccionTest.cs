using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogiCAR.Entidades;
using LogiCAR.AccesoDatos;
using System.Collections.Generic;

namespace LogiCAR.CapaAccesoDatos.Tests
{
    [TestClass]
    public class DatosInspeccionTest
    {
        private RepositorioInspeccion repositorio = new RepositorioInspeccion();


        [TestMethod]
        public void InsertarInspeccion()
        {
            Inspeccion Inspeccion = GenerarInspeccion();
            int resultado = repositorio.InsertarInspeccion(Inspeccion);
            Assert.AreEqual(1, resultado);
        }

        [TestMethod]
        public void ObtenerInspeccion()
        {
            Inspeccion InspeccionInsertar = GenerarInspeccion();
            int inspeccionID = repositorio.InsertarInspeccion(InspeccionInsertar);
            Inspeccion Inspeccion = repositorio.ObtenerInspeccion(inspeccionID);
            Assert.AreNotEqual(null, Inspeccion);
        }

        [TestMethod]
        public void ObtenerInspecciones()
        {
            IEnumerable<Inspeccion> Inspeccions = GenerarInspecciones();

            foreach (Inspeccion Inspeccion in Inspeccions)
            {
                repositorio.InsertarInspeccion(Inspeccion);
            }

            IEnumerable<Inspeccion> listaInspeccions = repositorio.ObtenerInspecciones();
            Assert.AreNotEqual(null, listaInspeccions);

            int contidadInspeccions = 0;
            foreach (var Inspeccion in Inspeccions)
            {
                contidadInspeccions++;
            }
            Assert.AreEqual(2, contidadInspeccions);
        }

        //[TestMethod]
        //public void ModificarInspeccion()
        //{
        //    Inspeccion InspeccionInsertar = GenerarInspeccion();
        //    bool resultadoInsercion = repositorio.InsertarInspeccion(InspeccionInsertar);
        //    Assert.AreEqual(true, resultadoInsercion);

        //    Inspeccion InspeccionObtenido = repositorio.ObtenerInspeccion(InspeccionInsertar.Id);
        //    Assert.AreEqual(InspeccionObtenido., "Gris");

        //    InspeccionObtenido.Color = "Rojo";
        //    bool resultadoActualizacion = repositorio.ActualizarInspeccion(InspeccionObtenido.VIN, InspeccionObtenido);
        //    Assert.AreEqual(true, resultadoActualizacion);
        //    Assert.AreEqual(repositorio.ObtenerInspeccion(InspeccionInsertar.VIN).Color, "Rojo");
        //}

        private Inspeccion GenerarInspeccion()
        {
            return new Inspeccion
            {
                Id = -1,
                Creacion = DateTime.Today,
                VIN = GenerarVehiculo(),
                //Usuario = new Usuario(),
                Danios = GenerarDanios()
            };
        }

        private ICollection<Danio> GenerarDanios()
        {
            return new List<Danio>
            {
                new Danio
                {
                Id = 1,
                Descripcion = "rayon",
                Foto = new byte[0]
                },
                 new Danio
                {
                       Id = 1,
                    Descripcion = "luza rota",
                Foto = new byte[0]
                }
            };
        }

        private IEnumerable<Inspeccion> GenerarInspecciones()
        {
            return new List<Inspeccion>
            {
                new Inspeccion
                {
                    Id = -1,
                    Creacion = DateTime.Today,
                    //Danio = new Danio(),
                    //Usuario = new Usuario(),
                   VIN = GenerarVehiculo()
                },
                 new Inspeccion
                {
                    Id = -1,
                    Creacion = DateTime.Today,
                    //Danio = new Danio(),
                    //Usuario = new Usuario(),
                    VIN = GenerarVehiculo()
                }
            };
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
                    VIN =new Guid("11223344-5566-7788-99AA-BBCCDDEEFF00"),
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
                VIN = new Guid("11223344-5566-7788-99AA-BBCCDDEEFF00"),
                Marca = "Renault",
                Modelo = "Clio",
                Color = "gris",
                Anio = "2012"
            };

        }
    }
}
