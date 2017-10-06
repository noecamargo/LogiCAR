using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogiCAR.Entidades;
using System.Drawing;

namespace LogiCAR.Entidades.Test
{
    [TestClass]
    public class DanioTest
    {
        [TestMethod]
        public void CrearDanio()
        {
            Danio danio = new Danio();
            danio.Id = 1;
            danio.Descripcion = "Parabrisas roto";
            danio.Foto = new byte[0];

            Assert.IsNotNull(danio);
            Assert.IsNotNull(danio.Id);
            Assert.IsNotNull(danio.Descripcion);
            Assert.IsNotNull(danio.Foto);
        }
    }
}
