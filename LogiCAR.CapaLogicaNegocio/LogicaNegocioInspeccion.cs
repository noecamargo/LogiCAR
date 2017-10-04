using LogiCAR.AccesoDatos;
using LogiCAR.CapaAccesoDatos;
using LogiCAR.Entidades;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace LogiCAR.CapaLogicaNegocio
{
    public class LogicaNegocioInspeccion : ILogicaNegocioInspeccion
    {
        public int CrearInspeccion(Inspeccion inspeccion)
        {
            return 1;
        }

        public Inspeccion ObtenerInspeccion(int id)
        {
            return new Inspeccion();
        }
    }
}