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
    public class InspeccionTest
    {
        [TestMethod]
        public void CrearInspeccion()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            Inspeccion inspeccion = GenerarInspeccion();
            var mockInspeccionAccesoDatos = new Mock<IRepositorioInspeccion>();

            mockInspeccionAccesoDatos
                .Setup(ad => ad.InsertarInspeccion(inspeccion))
                .Returns(1);


            var logicaInspeccion = new LogicaNegocioInspeccion(mockInspeccionAccesoDatos.Object);

            int resultado = logicaInspeccion.CrearInspeccion(inspeccion);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Inspeccion>;

            //Assert
            //mockInspeccionAccesoDatos.VerifyAll();
            Assert.AreEqual(resultado, 1);

        }

        [TestMethod]
        public void Obtenerinspeccion()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            Inspeccion inspeccion = GenerarInspeccion();
            var mockinspeccionAccesoDatos = new Mock<IRepositorioInspeccion>();

            mockinspeccionAccesoDatos
                .Setup(ad => ad.ObtenerInspeccion(inspeccion.Id))
                .Returns(inspeccion);


            var logicainspeccion = new LogicaNegocioInspeccion(mockinspeccionAccesoDatos.Object);

            Inspeccion resultado = logicainspeccion.ObtenerInspeccion(inspeccion.Id);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<inspeccion>;

            //Assert
            //mockinspeccionAccesoDatos.VerifyAll();
            Assert.IsNotNull(resultado);
            Assert.AreEqual(resultado, inspeccion);
        }

        [TestMethod]
        public void Obtenerinspeccions()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            ICollection<Inspeccion> inspecciones = GenerarInspecciones();
            var mockinspeccionAccesoDatos = new Mock<IRepositorioInspeccion>();

            mockinspeccionAccesoDatos
                .Setup(ad => ad.ObtenerInspecciones())
                .Returns(inspecciones);


            var logicainspeccion = new LogicaNegocioInspeccion(mockinspeccionAccesoDatos.Object);

            IEnumerable<Inspeccion> resultado = logicainspeccion.ObtenerInspecciones();
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<inspeccion>;

            //Assert
            //mockinspeccionAccesoDatos.VerifyAll();
            Assert.IsNotNull(resultado);
            Assert.AreEqual(resultado, inspecciones);
        }

        [TestMethod]
        public void Actualizarinspeccion()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            Inspeccion inspeccion = GenerarInspeccion();
            var mockinspeccionAccesoDatos = new Mock<IRepositorioInspeccion>();

            mockinspeccionAccesoDatos
                .Setup(ad => ad.ActualizarInspeccion(inspeccion.Id, inspeccion))
                .Returns(true);


            var logicainspeccion = new LogicaNegocioInspeccion(mockinspeccionAccesoDatos.Object);

            bool resultado = logicainspeccion.ActualizarInspeccion(inspeccion.Id, inspeccion);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<inspeccion>;

            //Assert
            //mockinspeccionAccesoDatos.VerifyAll();
            Assert.IsNotNull(resultado);
            Assert.AreEqual(true, resultado);
        }

        private Inspeccion GenerarInspeccion()
        {
            return new Inspeccion
            {
                Id = 1,
                Creacion = DateTime.Today,
                //VIN = Guid.NewGuid(),
                //Usuario = new Usuario(),
                //Danio = new Danio()
            };
        }

        private ICollection<Inspeccion> GenerarInspecciones()
        {
            return new List<Inspeccion>
            {
                new Inspeccion
                {
                    Id = 2,
                    Creacion = DateTime.Today,
                    //Danio = new Danio(),
                    //Usuario = new Usuario(),
                    //VIN = Guid.NewGuid()
                },
                 new Inspeccion
                {
                    Id = 3,
                    Creacion = DateTime.Today,
                    //Danio = new Danio(),
                    //Usuario = new Usuario(),
                    //VIN = Guid.NewGuid()
                }
            };

        }
    }
}
