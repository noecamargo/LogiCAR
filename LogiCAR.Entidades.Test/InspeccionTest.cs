using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiCAR.Entidades.Test
{
    [TestClass]
    public class InspeccionTest
    {
        [TestMethod]
        public void CrearInspeccion()
        {
            Inspeccion inspeccion = new Inspeccion();
            inspeccion.Creacion = DateTime.Today;
            inspeccion.Vehiculo = new Vehiculo();
            inspeccion.Usuario = new Usuario();
            inspeccion.Danio = new Danio();

        }
    }
}
