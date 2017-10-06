using LogiCAR.Entidades;
using System.Collections.Generic;

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