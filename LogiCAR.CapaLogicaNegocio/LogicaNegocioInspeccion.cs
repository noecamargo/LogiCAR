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
        private IRepositorio modelo;

        public LogicaNegocioInspeccion(IRepositorio modelo)
        {
            this.modelo = modelo;
        }

        public int CrearInspeccion(Inspeccion inspeccion)
        {
            return 1;
        }

        public Inspeccion ObtenerInspeccion(int id)
        {
            return new Inspeccion();
        }

        public IEnumerable<Inspeccion> ObtenerInspecciones()
        {
            return null;
        }

        public bool ActualizarInspeccion(int id, Inspeccion inspeccion)
        {
            return true;
        }
    }
}