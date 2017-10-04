using LogiCAR.Entidades;
using System.Collections.Generic;
using System.Web.Http;
using System;

namespace LogiCAR.CapaLogicaNegocio
{
    public interface ILogicaNegocioInspeccion
    {
        int CrearInspeccion(Inspeccion inspeccion);
        Inspeccion ObtenerInspeccion(int id);
        IEnumerable<Inspeccion> ObtenerInspecciones();
        bool ActualizarInspeccion(int id, Inspeccion inspeccion);
    }
}