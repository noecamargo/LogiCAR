using LogiCAR.AccesoDatos;
using LogiCAR.CapaLogicaNegocio;
using LogiCAR.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiCAR.CapaLogicaNegocioTests
{
    [TestClass]
    public class TransporteLoteTest
    {
        [TestMethod]
        public void CrearTransporteLote()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            TransporteLote transporte = GenerarTransporteLote();
            var mockLoteAccesoDatos = new Mock<IRepositorioTransporteLote>();

            mockLoteAccesoDatos
                .Setup(ad => ad.InsertarTransporteLote(transporte))
                .Returns(1);


            var logicaTransporteLote = new LogicaNegocioTransporteLote(mockLoteAccesoDatos.Object);

            long resultado = logicaTransporteLote.CrearTransporteLote(transporte);
            Assert.AreNotEqual(resultado, 1);

        }

        [TestMethod]
        public void ObtenerTransportelote()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            TransporteLote transporte = GenerarTransporteLote();
            var mockTransporteLoteAccesoDatos = new Mock<IRepositorioTransporteLote>();

            mockTransporteLoteAccesoDatos
                .Setup(ad => ad.ObtenerTransporteLote(transporte.Id))
                .Returns(transporte);


            var logicaTransportelote = new LogicaNegocioTransporteLote(mockTransporteLoteAccesoDatos.Object);

            TransporteLote resultado = logicaTransportelote.ObtenerTransporteLote(transporte.Id);
            Assert.IsNotNull(resultado);
            Assert.AreEqual(1, transporte.Id);
        }

        [TestMethod]
        public void ObtenerTransporteLotes()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            ICollection<TransporteLote> transporte = GenerarTransporteLotes();
            var mockTransporteLotesAccesoDatos = new Mock<IRepositorioTransporteLote>();

            mockTransporteLotesAccesoDatos
                .Setup(ad => ad.ObtenerTransporteLotes())
                .Returns(transporte);


            var logicaLote= new LogicaNegocioTransporteLote(mockTransporteLotesAccesoDatos.Object);

            IEnumerable<TransporteLote> resultado = logicaLote.ObtenerTransporteLotes();
            
            //Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(resultado, transporte);
        }

        [TestMethod]
        public void ActualizarTransportelote()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            TransporteLote transporte = GenerarTransporteLote();
            var mockTransporteloteAccesoDatos = new Mock<IRepositorioTransporteLote>();

            mockTransporteloteAccesoDatos
                .Setup(ad => ad.ActualizarTransporteLote(transporte.Id, transporte))
                .Returns(true);


            var logicalote = new LogicaNegocioTransporteLote(mockTransporteloteAccesoDatos.Object);

            bool resultado = logicalote.ActualizarTransporteLote(transporte.Id, transporte);

            Assert.IsNotNull(resultado);
            Assert.AreEqual(true, resultado);
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

        private ICollection<TransporteLote> GenerarTransporteLotes()
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
