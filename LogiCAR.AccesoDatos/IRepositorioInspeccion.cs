using System.Collections.Generic;
using LogiCAR.Entidades;

namespace LogiCAR.AccesoDatos
{
    public interface IRepositorioInspeccion
    {
        bool ActualizarInspeccion(int id, Inspeccion inspeccion);
        int InsertarInspeccion(Inspeccion inspeccion);
        Inspeccion ObtenerInspeccion(int id);
        IEnumerable<Inspeccion> ObtenerInspecciones();
    }
}