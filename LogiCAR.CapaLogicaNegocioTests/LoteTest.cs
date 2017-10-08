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
    public class LoteTest
    {
        [TestMethod]
        public void CrearLote()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            Lote lote = GenerarLote();
            var mockLoteAccesoDatos = new Mock<IRepositorioLote>();

            mockLoteAccesoDatos
                .Setup(ad => ad.InsertarLote(lote))
                .Returns(1);


            var logicaLote = new LogicaNegocioLote(mockLoteAccesoDatos.Object);

            long resultado = logicaLote.CrearLote(lote);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Lote>;

            //Assert
            //mockLoteAccesoDatos.VerifyAll();
            Assert.AreNotEqual(resultado, -1);

        }

        [TestMethod]
        public void Obtenerlote()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            Lote lote = GenerarLote();
            var mockloteAccesoDatos = new Mock<IRepositorioLote>();

            mockloteAccesoDatos
                .Setup(ad => ad.ObtenerLote(lote.Id))
                .Returns(lote);


            var logicalote = new LogicaNegocioLote(mockloteAccesoDatos.Object);

            Lote resultado = logicalote.ObtenerLote(lote.Id);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<lote>;

            //Assert
            //mockloteAccesoDatos.VerifyAll();
            Assert.IsNotNull(resultado);
            Assert.AreEqual(1, lote.Id);
        }

        [TestMethod]
        public void ObtenerLotes()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            ICollection<Lote> lotes = GenerarLotes();
            var mockLotesAccesoDatos = new Mock<IRepositorioLote>();

            mockLotesAccesoDatos
                .Setup(ad => ad.ObtenerLotes())
                .Returns(lotes);


            var logicaLote= new LogicaNegocioLote(mockLotesAccesoDatos.Object);

            IEnumerable<Lote> resultado = logicaLote.ObtenerLotes();
            
            //Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(resultado, lotes);
        }

        [TestMethod]
        public void Actualizarlote()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            Lote lote = GenerarLote();
            var mockloteAccesoDatos = new Mock<IRepositorioLote>();

            mockloteAccesoDatos
                .Setup(ad => ad.ActualizarLote(lote.Id, lote))
                .Returns(true);


            var logicalote = new LogicaNegocioLote(mockloteAccesoDatos.Object);

            bool resultado = logicalote.ActualizarLote(lote.Id, lote);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<lote>;

            //Assert
            //mockloteAccesoDatos.VerifyAll();
            Assert.IsNotNull(resultado);
            Assert.AreEqual(true, resultado);
        }

        private Lote GenerarLote()
        {
            return new Lote
            {
                Id = 1,
                Creador = new Usuario(),
                Nombre = "Lote 2",
                Descripcion = "desc Lote 2",
                ProntoParaPartida = false,
                Vehiculos = new List<Vehiculo>()
            };
        }

        private ICollection<Lote> GenerarLotes()
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
