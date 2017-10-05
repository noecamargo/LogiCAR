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
        private RepositorioSqlServer repositorio = new AccesoDatos.RepositorioSqlServer();


        [TestMethod]
        public void InsertarInspeccion()
        {
            Inspeccion Inspeccion = GenerarInspeccion();
            bool resultado = repositorio.InsertarInspeccion(Inspeccion);
            Assert.AreEqual(true, resultado);
        }

        [TestMethod]
        public void ObtenerInspeccion()
        {
            Inspeccion InspeccionInsertar = GenerarInspeccion();
            repositorio.InsertarInspeccion(InspeccionInsertar);
            Inspeccion Inspeccion = repositorio.ObtenerInspeccion(InspeccionInsertar.Id);
            Assert.AreNotEqual(null, Inspeccion);
        }

        [TestMethod]
        public void ObtenerInspeccions()
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
                Id = 1,
                Creacion = DateTime.Today,
                VIN = new Vehiculo(),
                //Usuario = new Usuario(),
                //Danio = new Danio()
            };
        }

        private IEnumerable<Inspeccion> GenerarInspecciones()
        {
            return new List<Inspeccion>
            {
                new Inspeccion
                {
                    Id = 2,
                    Creacion = DateTime.Today,
                    //Danio = new Danio(),
                    //Usuario = new Usuario(),
                   VIN = new Vehiculo()
                },
                 new Inspeccion
                {
                    Id = 3,
                    Creacion = DateTime.Today,
                    //Danio = new Danio(),
                    //Usuario = new Usuario(),
                    VIN = new Vehiculo()
                }
            };
        }
    }
}
