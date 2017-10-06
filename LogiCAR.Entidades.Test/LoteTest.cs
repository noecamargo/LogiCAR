using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiCAR.Entidades.Test
{
    [TestClass]
    public class LoteTest
    {
        [TestMethod]
        public void CrearLote()
        {
            Lote lote = new Lote();
            lote.Creador = new Usuario();
            lote.Nombre = "Lote 1";
            lote.Decripcion = "Lote urgente";
            lote.ProntoParaPartida = false;
            lote.Vehiculos = new List<Vehiculo>();
            Assert.IsNotNull(lote);

        }
    }
}
