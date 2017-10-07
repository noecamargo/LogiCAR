using LogiCAR.CapaAccesoDatos;
using LogiCAR.CapaLogicaNegocio;
using LogiCAR.Entidades;
using LogiCAR.Utilidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace LogiCAR.CapaLogicaNegocioTests
{
    [TestClass]
    public class LogicaNegocioPatioTest
    {
        void AltaPatio()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            Patio patrio = CrearPatioFalso();

            var mockRepositorioPatio = new Mock<IRepositorioPatio>();


            mockRepositorioPatio
                .Setup(repo => repo.AltaPatio(patrio));

            var logicaPatio = new LogicaNegocioPatio(mockRepositorioPatio.Object);

            logicaPatio.AltaPatio(patrio);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

            //Assert
            mockRepositorioPatio.VerifyAll();
            Assert.AreNotEqual(null, true);
        }

        private Patio CrearPatioFalso()
        {
            Patio patio = new Patio();
            patio.Nombre = "Patio1";
            return patio;
        }

        void AltaPuerto()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            Puerto puerto = CrearPuertoFalso();

            var mockRepositorioPatio = new Mock<IRepositorioPatio>();


            mockRepositorioPatio
                .Setup(repo => repo.AltaPuerto(puerto));

            var logicaPatio = new LogicaNegocioPatio(mockRepositorioPatio.Object);

            logicaPatio.AltaPuerto(puerto);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

            //Assert
            mockRepositorioPatio.VerifyAll();
            Assert.AreNotEqual(null, true);
        }

        private Puerto CrearPuertoFalso()
        {
            Puerto puerto = new Puerto();
            puerto.Nombre = "PuertoMontevideo";
            return puerto;
        }

        void AltaSubZona()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            SubZona subZona = CrearSubZonaFalso();

            var mockRepositorioPatio = new Mock<IRepositorioPatio>();


            mockRepositorioPatio
                .Setup(repo => repo.AltaSubZona(subZona));

            var logicaPatio = new LogicaNegocioPatio(mockRepositorioPatio.Object);

            logicaPatio.AltaSubZona(subZona);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

            //Assert
            mockRepositorioPatio.VerifyAll();
            Assert.AreNotEqual(null, true);
        }

        private SubZona CrearSubZonaFalso()
        {
            SubZona subZona = new SubZona();
            subZona.Nombre = "Lavado";
            subZona.Capacidad = 5;
            return subZona;
        }

        void AltaZona()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            Zona zona = CrearZonaFalsa();

            var mockRepositorioPatio = new Mock<IRepositorioPatio>();


            mockRepositorioPatio
                .Setup(repo => repo.AltaZona(zona));

            var logicaPatio = new LogicaNegocioPatio(mockRepositorioPatio.Object);

            logicaPatio.AltaZona(zona);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

            //Assert
            mockRepositorioPatio.VerifyAll();
            Assert.AreNotEqual(null, true);
        }

        private Zona CrearZonaFalsa()
        {
            Zona zona = new Zona();
            zona.Nombre = "Zona1";
            zona.Capacidad = 10;
            return zona;
        }

        void BajaSubZona()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            //se espera que devuelva true
                    
            var mockRepositorioPatio = new Mock<IRepositorioPatio>();


            mockRepositorioPatio
                .Setup(repo => repo.BajaSubZona(1,1));

            var logicaPatio = new LogicaNegocioPatio(mockRepositorioPatio.Object);

            logicaPatio.BajaSubZona(1,1);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<SubZona>;

            //Assert
            mockRepositorioPatio.VerifyAll();
            Assert.AreEqual(true, true);
        }

        private SubZona CrearSubZonaFalsa()
        {
            SubZona subZona = new SubZona();
            subZona.Nombre = "Lavado";
            subZona.Capacidad = 12;
            return subZona;
        }
        void BajaZona()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            //se espera que devuelva true

            var mockRepositorioPatio = new Mock<IRepositorioPatio>();

            mockRepositorioPatio
                .Setup(repo => repo.BajaZona(1));

            var logicaPatio = new LogicaNegocioPatio(mockRepositorioPatio.Object);

            logicaPatio.BajaZona(1);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

            //Assert
            mockRepositorioPatio.VerifyAll();
            Assert.AreNotEqual(null, true);
        }
        void ConsultarSubZona()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            //se espera que devuelva true

            var mockRepositorioPatio = new Mock<IRepositorioPatio>();


            mockRepositorioPatio
                .Setup(repo => repo.ConsultarSubZona(1));

            var logicaPatio = new LogicaNegocioPatio(mockRepositorioPatio.Object);

            logicaPatio.ConsultarSubZona(1);
            //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

            //Assert
            mockRepositorioPatio.VerifyAll();
            Assert.AreEqual(true, true);
        }
        void ConsultarZona()
        {
            //Arrange: Construimos el mock y seteamos las expectativas
            Zona zona = CrearZonaFalsa();
            Dictionary<int, int> resultadoEsperado = CrearResultadoEsperado();

            var mockRepositorioPatio = new Mock<IRepositorioPatio>();


            mockRepositorioPatio
                .Setup(repo => repo.ConsultarZona(zona));

            var logicaPatio = new LogicaNegocioPatio(mockRepositorioPatio.Object);

           var resultadoObtenido =  logicaPatio.ConsultarZona(zona);
           //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Zona>;

            //Assert
            mockRepositorioPatio.VerifyAll();
            Assert.AreEqual(resultadoEsperado, resultadoObtenido);
        }

        private Dictionary<int, int> CrearResultadoEsperado()
        {
            Dictionary<int, int> resultado = new Dictionary<int, int>();
            resultado.Add(1, 5);
            resultado.Add(2,0);
            return resultado;
        }

        //void ModificarPatio()
        //{
        //    //Arrange: Construimos el mock y seteamos las expectativas
        //   //

        //    var mockRepositorioPatio = new Mock<IRepositorioPatio>();


        //    mockRepositorioPatio
        //        .Setup(repo => repo.ModificarPatio(usuario));

        //    var logicaPatio = new LogicaNegocioPatio(mockRepositorioPatio.Object);

        //    logicaPatio.ModificarPatio(usuario);
        //    //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

        //    //Assert
        //    mockRepositorioPatio.VerifyAll();
        //    Assert.AreNotEqual(null, true);
        //}
        //void ModificarSubZona()
        //{
        //    //Arrange: Construimos el mock y seteamos las expectativas
        //   //

        //    var mockRepositorioPatio = new Mock<IRepositorioPatio>();


        //    mockRepositorioPatio
        //        .Setup(repo => repo.ModificarSubZona(usuario));

        //    var logicaPatio = new LogicaNegocioPatio(mockRepositorioPatio.Object);

        //    logicaPatio.ModificarSubZona(usuario);
        //    //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

        //    //Assert
        //    mockRepositorioPatio.VerifyAll();
        //    Assert.AreNotEqual(null, true);
        //}
        //void ModificarZona()
        //{
        //    //Arrange: Construimos el mock y seteamos las expectativas
        //   //

        //    var mockRepositorioPatio = new Mock<IRepositorioPatio>();


        //    mockRepositorioPatio
        //        .Setup(repo => repo.ModificarZona(usuario));

        //    var logicaPatio = new LogicaNegocioPatio(mockRepositorioPatio.Object);

        //    logicaPatio.ModificarZona(usuario);
        //    //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

        //    //Assert
        //    mockRepositorioPatio.VerifyAll();
        //    Assert.AreNotEqual(null, true);
        //}
        //void ObtenerSubZona()
        //{
        //    //Arrange: Construimos el mock y seteamos las expectativas
        //   //

        //    var mockRepositorioPatio = new Mock<IRepositorioPatio>();


        //    mockRepositorioPatio
        //        .Setup(repo => repo.ObtenerSubZona(usuario));

        //    var logicaPatio = new LogicaNegocioPatio(mockRepositorioPatio.Object);

        //    logicaPatio.ObtenerSubZona(usuario);
        //    //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

        //    //Assert
        //    mockRepositorioPatio.VerifyAll();
        //    Assert.AreNotEqual(null, true);
        //}
        //void ObtenerZona()
        //{
        //    //Arrange: Construimos el mock y seteamos las expectativas
        //   //

        //    var mockRepositorioPatio = new Mock<IRepositorioPatio>();


        //    mockRepositorioPatio
        //        .Setup(repo => repo.ObtenerZona(usuario));

        //    var logicaPatio = new LogicaNegocioPatio(mockRepositorioPatio.Object);

        //    logicaPatio.ObtenerZona(usuario);
        //    //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

        //    //Assert
        //    mockRepositorioPatio.VerifyAll();
        //    Assert.AreNotEqual(null, true);
        //}
        //void QuitarVehiculoPatio()
        //{
        //    //Arrange: Construimos el mock y seteamos las expectativas
        //   //

        //    var mockRepositorioPatio = new Mock<IRepositorioPatio>();


        //    mockRepositorioPatio
        //        .Setup(repo => repo.QuitarVehiculoPatio(usuario));

        //    var logicaPatio = new LogicaNegocioPatio(mockRepositorioPatio.Object);

        //    logicaPatio.QuitarVehiculoPatio(usuario);
        //    //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

        //    //Assert
        //    mockRepositorioPatio.VerifyAll();
        //    Assert.AreNotEqual(null, true);
        //}
        //void QuitarVehiculoSubZona()
        //{
        //    //Arrange: Construimos el mock y seteamos las expectativas
        //   //

        //    var mockRepositorioPatio = new Mock<IRepositorioPatio>();


        //    mockRepositorioPatio
        //        .Setup(repo => repo.QuitarVehiculoSubZona(usuario));

        //    var logicaPatio = new LogicaNegocioPatio(mockRepositorioPatio.Object);

        //    logicaPatio.QuitarVehiculoSubZona(usuario);
        //    //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

        //    //Assert
        //    mockRepositorioPatio.VerifyAll();
        //    Assert.AreNotEqual(null, true);
        //}
        //void SetearCapacidadSubZona()
        //{
        //    //Arrange: Construimos el mock y seteamos las expectativas
        //   //

        //    var mockRepositorioPatio = new Mock<IRepositorioPatio>();


        //    mockRepositorioPatio
        //        .Setup(repo => repo.SetearCapacidadSubZona(usuario));

        //    var logicaPatio = new LogicaNegocioPatio(mockRepositorioPatio.Object);

        //    logicaPatio.SetearCapacidadSubZona(usuario);
        //    //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

        //    //Assert
        //    mockRepositorioPatio.VerifyAll();
        //    Assert.AreNotEqual(null, true);
        //}
        //void QuitarVehiculoPuerto()
        //{
        //    //Arrange: Construimos el mock y seteamos las expectativas
        //   //

        //    var mockRepositorioPatio = new Mock<IRepositorioPatio>();


        //    mockRepositorioPatio
        //        .Setup(repo => repo.QuitarVehiculoPuerto(usuario));

        //    var logicaPatio = new LogicaNegocioPatio(mockRepositorioPatio.Object);

        //    logicaPatio.QuitarVehiculoPuerto(usuario);
        //    //var createdResult = obtainedResult as CreatedAtRouteNegotiatedContentResult<Vehiculo>;

        //    //Assert
        //    mockRepositorioPatio.VerifyAll();
        //    Assert.AreNotEqual(null, true);
        //}
    }
}
