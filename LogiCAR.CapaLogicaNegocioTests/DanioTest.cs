using LogiCAR.AccesoDatos;
using LogiCAR.CapaAccesoDatos;
using LogiCAR.CapaLogicaNegocio;
using LogiCAR.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Script.Serialization;

namespace LogiCAR.CapaLogicaNegocioTests
{
    [TestClass]
    public class DanioTest
    {
        [TestMethod]
        public void CrearDanio()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            Danio danio = GenerarDanio();
            var mockDanioAccesoDatos = new Mock<IRepositorio>();

            mockDanioAccesoDatos
                .Setup(ad => ad.InsertarDanio(danio))
                .Returns(1);


            var logicaDanio = new LogicaNegocioDanio(mockDanioAccesoDatos.Object);

            int resultado = logicaDanio.CrearDanio(danio);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Danio>;

            //Assert
            mockDanioAccesoDatos.VerifyAll();
            Assert.AreEqual(resultado, danio.Id);

        }

        [TestMethod]
        public void ObtenerDanio()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            Danio Danio = GenerarDanio();
            var mockDanioAccesoDatos = new Mock<IRepositorio>();

            mockDanioAccesoDatos
                .Setup(ad => ad.ObtenerDanio(Danio.Id))
                .Returns(Danio);


            var logicaDanio = new LogicaNegocioDanio(mockDanioAccesoDatos.Object);

            Danio resultado = logicaDanio.ObtenerDanio(Danio.Id);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Danio>;

            //Assert
            mockDanioAccesoDatos.VerifyAll();
            Assert.IsNotNull(resultado);
            Assert.AreEqual(resultado, Danio);
        }

        [TestMethod]
        public void ObtenerDanios()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            IEnumerable<Danio> Danios = GenerarDanios();
            var mockDanioAccesoDatos = new Mock<IRepositorio>();

            mockDanioAccesoDatos
                .Setup(ad => ad.ObtenerDanios())
                .Returns(Danios);


            var logicaDanio = new LogicaNegocioDanio(mockDanioAccesoDatos.Object);

            IEnumerable <Danio> resultado = logicaDanio.ObtenerDanios();
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Danio>;

            //Assert
            mockDanioAccesoDatos.VerifyAll();
            Assert.IsNotNull(resultado);
            Assert.AreEqual(resultado, Danios);
        }

        [TestMethod]
        public void ActualizarDanio()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            Danio Danio = GenerarDanio();
            var mockDanioAccesoDatos = new Mock<IRepositorio>();

            mockDanioAccesoDatos
                .Setup(ad => ad.ActualizarDanio(Danio.Id,Danio))
                .Returns(true);


            var logicaDanio = new LogicaNegocioDanio(mockDanioAccesoDatos.Object);

            bool resultado = logicaDanio.ActualizarDanio(Danio.Id,Danio);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Danio>;

            //Assert
            mockDanioAccesoDatos.VerifyAll();
            Assert.IsNotNull(resultado);
            Assert.AreEqual(true, resultado);
        }

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
