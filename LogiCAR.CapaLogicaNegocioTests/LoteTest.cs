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
    public class LoteTest : ILoteTest
    {
        [TestMethod]
        public void CrearLote()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            Lote lote = GenerarLote();
            var mockLoteAccesoDatos = new Mock<IRepositorio>();

            mockLoteAccesoDatos
                .Setup(ad => ad.InsertarLote(lote))
                .Returns(1);


            var logicaLote = new LogicaNegocioLote(mockLoteAccesoDatos.Object);

            int resultado = logicaLote.CrearLote(lote);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Lote>;

            //Assert
            //mockLoteAccesoDatos.VerifyAll();
            Assert.AreEqual(resultado, 1);

        }



        private Lote GenerarLote()
        {
            return new Lote
            {
                Id = -1,
                Creador = new Usuario(),
                Nombre = "Lote 2",
                Decripcion = "desc Lote 2",
                ProntoParaPartida = false,
                Vehiculos = new List<Vehiculo>()
            };
        }

        private IEnumerable<Lote> GenerarLotees()
        {
            return new List<Lote>
            {
                new Lote
                {
                    Id = -1,
            Creador = new Usuario(),
            Nombre = "Lote 3",
            Decripcion = "desc Lote 3",
            ProntoParaPartida = false,
            Vehiculos = new List<Vehiculo>()
                },
                 new Lote
                {
                     Id = -1,
            Creador = new Usuario(),
            Nombre = "Lote 4",
            Decripcion = "desc Lote 4",
            ProntoParaPartida = false,
            Vehiculos = new List<Vehiculo>()
                }
            };

        }
    }
}
