using LogiCAR.CapaLogicaNegocio;
using LogiCAR.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logi.CAR.WebApi.Tests
{
    [TestClass]
    public class InspeccionControllerTest
    {
        [TestMethod]
        public void CrearInspeccionController()
        {
            var inspeccion = GenerarInspeccion();

            var mockInspeccionLogica = new Mock<ILogicaNegocioInspeccion>();
           
        }

        private Inspeccion GenerarInspeccion()
        {
            return new Inspeccion
            {
                Creacion = DateTime.Today,
                Vehiculo = new Vehiculo(),
                Usuario = new Usuario(),
                Danio = new Danio()
            };
        }
    }
}
