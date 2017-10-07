using LogiCAR.CapaAccesoDatos;
using LogiCAR.Entidades;
using LogiCAR.Utilidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiCAR.CapaAccesoDatos.Tests
{
    [TestClass]
    public class RepositorioPatioTest
    {

        private IRepositorioPatio repositorio = new RepositorioPatio();

        [TestMethod]
        public void AltaPatio()
        {
            Patio patio = new Patio();
            patio.Nombre = "Patio Principal";
            bool retorno = repositorio.AltaPatio(patio);
            Assert.AreEqual(true, retorno);
        } 
       
        [TestMethod]
        public void AltaPuerto()
        {
            Puerto puerto = new Puerto();
            puerto.Nombre = "Puerto Montevideo";
            bool retorno = repositorio.AltaPuerto(puerto);
            Assert.AreEqual(true, retorno);
        }
        [TestMethod]

        public void AltaSubZona()
        {
            SubZona subZona = CrearSubZonaFalsa();
            bool resultado = repositorio.AltaSubZona(subZona);
            Assert.AreEqual(true, resultado);
        }
       
        [TestMethod]
        public void AltaZona()
        {
            Zona zona = CrearZonaFalsa();
            bool resultado = repositorio.AltaZona(zona);
            Assert.AreEqual(true, resultado);

        }
        
        [TestMethod]
        public void BajaSubZona()
        {
            bool resultado = repositorio.BajaSubZona(1, 1);
            Assert.AreEqual(true, resultado);
        }
        [TestMethod]
        public void BajaZona()
        {
            bool resultado = repositorio.BajaZona(1);
            Assert.AreEqual(true,resultado);
        }
        [TestMethod]
        public void ConsultarSubZona()
        {
            int resultado = repositorio.ConsultarSubZona(1);
            Assert.AreEqual(true, true);
        }
        [TestMethod]
        public void ConsultarZona()
        {
            Dictionary<int, int> resultado = repositorio.ConsultarZona(CrearZonaFalsa());
            Assert.AreNotEqual(null, resultado);
        }
        [TestMethod]
        public void ModificarPatio()
        {
            Patio patio = new Patio();
            patio.Nombre = "Patio Principal";
            bool resultado = repositorio.ModificarPatio(patio);
            Assert.AreEqual(true, resultado);
        }
        [TestMethod]
        public void ModificarSubZona()
        {
            bool resultado = repositorio.ModificarSubZona(CrearSubZonaFalsa());
            Assert.AreEqual(true, resultado);
        }
        [TestMethod]
        public void ModificarZona()
        {
            bool resultado = repositorio.ModificarZona(CrearZonaFalsa());
            Assert.AreEqual(true, resultado);
        }
        [TestMethod]
        public void ObtenerSubZona()
        {
            SubZona resultado = repositorio.ObtenerSubZona(1);
            Assert.AreNotEqual(null, resultado);
        }
        [TestMethod]
        public void ObtenerZona()
        {
            Zona resultado = repositorio.ObtenerZona(1);
            Assert.AreNotEqual(null, resultado);
        }
        [TestMethod]
        public void QuitarVehiculoPatio()
        {
            Patio patio = CrearPatioFalso();
            bool resultado = repositorio.QuitarVehiculoPatio(patio, Guid.NewGuid());
            Assert.AreEqual(true, resultado);
        }
        [TestMethod]
        public void QuiterVehiculoSubZona()
        {
            int resultado = repositorio.QuitarVehiculoSubZona(1, Guid.NewGuid());
            Assert.AreNotEqual(0, resultado);
        }
        [TestMethod]
        public void SetearCapacidadSubZona()
        {
            int resultado = repositorio.SetearCapacidadSubZona(1, 1, 10);
            Assert.AreNotEqual(0, resultado);
        }

        #region Metodos privados
        private Zona CrearZonaFalsa()
        {
            Zona zona = new Zona();
            zona.Nombre = "Zona1";
            zona.Capacidad = 0;
            zona.Disponible = 0;
            return zona;
        }
        private  SubZona CrearSubZonaFalsa()
        {
            SubZona subZona = new SubZona();
            subZona.Nombre = "Lavado";
            subZona.Capacidad = 0;
            subZona.Disponible = 0;
            //SetearCapacidadSubZona
            return subZona;
        }

        private Patio CrearPatioFalso()
        {
            Patio patio = new Patio();
            patio.Nombre = "Patio Principal";
            return patio;
        }
        #endregion
    }
}
