using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogiCAR.Entidades;
using LogiCAR.AccesoDatos;
using System.Collections.Generic;

namespace LogiCAR.CapaAccesoDatos.Tests
{
    [TestClass]
    public class DatosLoteTest
    {
        private RepositorioSqlServer repositorio = new AccesoDatos.RepositorioSqlServer();


        [TestMethod]
        public void InsertarLote()
        {
            Lote Lote = GenerarLote();
            long resultado = repositorio.InsertarLote(Lote);
            Assert.AreEqual(1, resultado);
        }

        [TestMethod]
        public void ObtenerLote()
        {
            Lote LoteInsertar = GenerarLote();
            long loteID = repositorio.InsertarLote(LoteInsertar);
            Lote Lote = repositorio.ObtenerLote(loteID);
            Assert.AreNotEqual(null, Lote);
        }

        [TestMethod]
        public void ObtenerLotes()
        {
            IEnumerable<Lote> Lotes = GenerarLotes();

            foreach (Lote Lote in Lotes)
            {
                repositorio.InsertarLote(Lote);
            }

            IEnumerable<Lote> listaLotes = repositorio.ObtenerLotes();
            Assert.AreNotEqual(null, listaLotes);

            int contidadLotes = 0;
            foreach (var Lote in Lotes)
            {
                contidadLotes++;
            }
            Assert.AreEqual(2, contidadLotes);
        }

        [TestMethod]
        public void ModificarLote()
        {
            Lote LoteInsertar = GenerarLote();
            long resultadoInsercion = repositorio.InsertarLote(LoteInsertar);
            Assert.AreNotEqual(-1, resultadoInsercion);

            Lote LoteObtenido = repositorio.ObtenerLote(LoteInsertar.Id);
            Assert.AreEqual(LoteObtenido.Descripcion, "desc Lote 2");

            LoteObtenido.Descripcion = "desc corregida Lote 2";
            bool resultadoActualizacion = repositorio.ActualizarLote(LoteObtenido.Id, LoteObtenido);
            Assert.AreEqual(true, resultadoActualizacion);
            Assert.AreEqual(repositorio.ObtenerLote(LoteInsertar.Id).Descripcion, "desc corregida Lote 2");
        }

        private Lote GenerarLote()
        {
            return new Lote
            {
                Id = -1,
                Creador = new Usuario(),
                Nombre = "Lote 2",
                Descripcion = "desc Lote 2",
                ProntoParaPartida = false,
                Vehiculos = new List<Vehiculo>()
            };
        }

        private IEnumerable<Lote> GenerarLotes()
        {
            return new List<Lote>
            {
                new Lote
                {
                    Id = -1,
            Creador = new Usuario(),
            Nombre = "Lote 3",
            Descripcion = "desc Lote 3",
            ProntoParaPartida = false,
            Vehiculos = new List<Vehiculo>()
                },
                 new Lote
                {
                     Id = -1,
            Creador = new Usuario(),
            Nombre = "Lote 4",
            Descripcion = "desc Lote 4",
            ProntoParaPartida = false,
            Vehiculos = new List<Vehiculo>()
                }
            };

        }

    }
}
