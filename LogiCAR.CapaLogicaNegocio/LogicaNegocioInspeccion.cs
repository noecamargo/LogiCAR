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
            return modelo.InsertarInspeccion(inspeccion);
        }

        public Inspeccion ObtenerInspeccion(int id)
        {
            return modelo.ObtenerInspeccion(id);
        }

        public IEnumerable<Inspeccion> ObtenerInspecciones()
        {
            return modelo.ObtenerInspecciones();
        }

        public bool ActualizarInspeccion(int id, Inspeccion inspeccion)
        {
            return true;
        }
    }
}