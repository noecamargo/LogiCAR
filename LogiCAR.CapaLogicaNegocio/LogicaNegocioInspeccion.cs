using LogiCAR.AccesoDatos;
using LogiCAR.Entidades;
using System;
using System.Collections.Generic;

namespace LogiCAR.CapaLogicaNegocio
{
    public class LogicaNegocioInspeccion : ILogicaNegocioInspeccion
    {
        private IRepositorioInspeccion repositorioInspeccion;

        public LogicaNegocioInspeccion(IRepositorioInspeccion repositorio)
        {
            repositorioInspeccion = repositorio;
        }

        public int CrearInspeccion(Inspeccion inspeccion)
        {
            inspeccion.Creacion = DateTime.Today;
            
            return repositorioInspeccion.InsertarInspeccion(inspeccion);
        }

        public Inspeccion ObtenerInspeccion(int id)
        {
            return repositorioInspeccion.ObtenerInspeccion(id);
        }

        public IEnumerable<Inspeccion> ObtenerInspecciones()
        {
            return repositorioInspeccion.ObtenerInspecciones();
        }

        public bool ActualizarInspeccion(int id, Inspeccion inspeccion)
        {
            return true;
        }
    }
}