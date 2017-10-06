using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogiCAR.Entidades;
using LogiCAR.CapaAccesoDatos;
using System.Collections.Generic;
using LogiCAR.AccesoDatos;

namespace LogiCAR.CapaAccesoDatos.Tests
{
    [TestClass]
    public class DatosDanioTest
    {
        private RepositorioDanio repositorio = new RepositorioDanio();


        [TestMethod]
        public void InsertarDanio()
        {
            Danio Danio = GenerarDanio();
            int resultado = repositorio.InsertarDanio(Danio);
            Assert.AreEqual(1, resultado);
        }

        [TestMethod]
        public void ObtenerDanio()
        {
            Danio DanioInsertar = GenerarDanio();
            int DanioID = repositorio.InsertarDanio(DanioInsertar);
            Danio Danio = repositorio.ObtenerDanio(DanioID);
            Assert.AreNotEqual(null, Danio);
        }

        [TestMethod]
        public void ObtenerDanios()
        {
            IEnumerable<Danio> Danios = GenerarDanios();

            foreach (Danio Danio in Danios)
            {
                repositorio.InsertarDanio(Danio);
            }

            IEnumerable<Danio> listaDanios = repositorio.ObtenerDanios();
            Assert.AreNotEqual(null, listaDanios);

            int contidadDanios = 0;
            foreach (var Danio in Danios)
            {
                contidadDanios++;
            }
            Assert.AreEqual(2, contidadDanios);
        }

        //[TestMethod]
        //public void ModificarDanio()
        //{
        //    Danio DanioInsertar = GenerarDanio();
        //    bool resultadoInsercion = repositorio.InsertarDanio(DanioInsertar);
        //    Assert.AreEqual(true, resultadoInsercion);

        //    Danio DanioObtenido = repositorio.ObtenerDanio(DanioInsertar.Id);
        //    Assert.AreEqual(DanioObtenido., "Gris");

        //    DanioObtenido.Color = "Rojo";
        //    bool resultadoActualizacion = repositorio.ActualizarDanio(DanioObtenido.VIN, DanioObtenido);
        //    Assert.AreEqual(true, resultadoActualizacion);
        //    Assert.AreEqual(repositorio.ObtenerDanio(DanioInsertar.VIN).Color, "Rojo");
        //}

        private Danio GenerarDanio()
        {
            return new Danio
            {
                Id = 1,
                Descripcion = "rayon",
                Foto = new byte[0]
            };
        }

        private IEnumerable<Danio> GenerarDanios()
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
    }
}
