﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using LogiCAR.CapaLogicaNegocio.Entidades;
using LogiCAR.CapaLogicaNegocio;

namespace LogiCAR.CapaLogicaNegocioTests
{
    [TestClass]
    public class UsuarioTest
    {

        //[ClassInitialize] //se ejecuta antes de todos los test methods SOLO UNA VEZ
        //public static void BeforeAll(TestContext contexto)
        //{
        //}
        //[TestInitialize] //se ejecuta antes de todos los test methods
        //public void BeforeTest()
        //{
        //}

        //[TestCleanup] // IDEM TEST INITIALIZE
        //public void AfterTest()
        //{
        //}

        //[ClassCleanup] //se ejecuta antes de todos los test methods SOLO UNA VEZ
        //public static void DespuesMetodosDeEstaClase()
        //{
        //}


        [TestMethod]
        public void AltaAdministrador()
        {
            Administrador admin = new Administrador();
            admin.Nombre = "Pedro";
            Assert.AreNotEqual(null,admin);
            
        }

        [TestMethod]
        public void AltaOperarioPuerto()
        {
            OperarioPuerto admin = new OperarioPuerto();
            admin.Nombre = "Pedro";

        }


    }

}
