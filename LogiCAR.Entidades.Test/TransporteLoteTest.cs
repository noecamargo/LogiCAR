using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiCAR.Entidades.Test
{
    [TestClass]
    public class TransporteLoteTest
    {
        [TestMethod]
        public void CrearTransporteLote()
        {
            TransporteLote transporte = new TransporteLote();
            transporte.Creador = new Usuario();
            transporte.FechaInicio = DateTime.Today;
            transporte.FechaFin = DateTime.Today;
            transporte.Lotes = new List<Lote>();
            Assert.IsNotNull(transporte);

        }
    }
}
