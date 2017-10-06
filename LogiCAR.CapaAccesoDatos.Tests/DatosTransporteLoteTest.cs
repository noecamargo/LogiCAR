using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogiCAR.Entidades;
using LogiCAR.AccesoDatos;
using System.Collections.Generic;

namespace LogiCAR.CapaAccesoDatos.Tests
{
    [TestClass]
    public class DatosTransporteLoteTest
    {
        private RepositorioSqlServer repositorio = new AccesoDatos.RepositorioSqlServer();


        [TestMethod]
        public void InsertarTransporteLote()
        {
            TransporteLote transporte = GenerarTransporteLote();
            long resultado = repositorio.InsertarTransporteLote(transporte);
            Assert.AreEqual(1, resultado);
        }

        [TestMethod]
        public void ObtenerTransporteLote()
        {
            TransporteLote transporte = GenerarTransporteLote();
            long transporteId = repositorio.InsertarTransporteLote(transporte);
            TransporteLote Lote = repositorio.ObtenerTransporteLote(transporteId);
            Assert.AreNotEqual(null, transporte);
        }

        [TestMethod]
        public void ObtenerTransporteLotes()
        {
            IEnumerable<TransporteLote> transportes = GenerarTransporteLotes();
            int insertados = 0;

            foreach (TransporteLote transporte in transportes)
            {
                insertados++;
                repositorio.InsertarTransporteLote(transporte);
            }

            IEnumerable<TransporteLote> listaTransportes = repositorio.ObtenerTransporteLotes();

            Assert.AreNotEqual(null, listaTransportes);
            Assert.AreEqual(2, insertados);
        }

        [TestMethod]
        public void ModificarTransporteLote()
        {
            TransporteLote transporte = GenerarTransporteLote();
            long resultadoInsercion = repositorio.InsertarTransporteLote(transporte);
            Assert.AreNotEqual(-1, resultadoInsercion);

            TransporteLote transporteObtenido = repositorio.ObtenerTransporteLote(transporte.Id);
            Assert.AreEqual(transporteObtenido.FechaInicio, DateTime.Today);

            DateTime fechaNueva = new DateTime(2015, 01, 01);

            transporteObtenido.FechaInicio = fechaNueva;
            bool resultadoActualizacion = repositorio.ActualizarTransporteLote(transporteObtenido.Id, transporteObtenido);
            Assert.AreEqual(true, resultadoActualizacion);
            Assert.AreEqual(repositorio.ObtenerTransporteLote(transporte.Id).FechaInicio, fechaNueva);
        }

        private TransporteLote GenerarTransporteLote()
        {
            return new TransporteLote
            {
                Id = 1,
                Creador = new Usuario(),
                FechaInicio = DateTime.Today,
                FechaFin = DateTime.Today,
                Lotes = new List<Lote>()
            };
        }

        private IEnumerable<TransporteLote> GenerarTransporteLotes()
        {
            return new List<TransporteLote>
            {
            new TransporteLote
            {
                Id = 2,
                Creador = new Usuario(),
                FechaInicio = DateTime.Today,
                FechaFin = DateTime.Today,
                Lotes = new List<Lote>()
            },
             new TransporteLote
            {
                Id = 3,
                Creador = new Usuario(),
                FechaInicio = DateTime.Today,
                FechaFin = DateTime.Today,
                Lotes = new List<Lote>()
            }
            };
        }

    }
}
