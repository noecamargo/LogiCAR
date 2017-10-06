using LogiCAR.CapaLogicaNegocio;
using LogiCAR.Entidades;
using LogiCAR.WebApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace Logi.CAR.WebApi.Tests
{
    [TestClass]
    public class TransporteLoteControllerTest
    {
        [TestMethod]
        public void CrearLoteController()
        {
            var lote = GenerarTransporteLote();

           
        }

        private object GenerarTransporteLote()
        {
            TransporteLote transporte = new TransporteLote();
        }
    }
}
