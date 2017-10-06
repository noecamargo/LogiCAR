using LogiCAR.Entidades;
using System.Collections.Generic;

namespace LogiCAR.CapaLogicaNegocio
{
    public interface ILogicaNegocioDanio
    {
        int CrearDanio(Danio danio);
        Danio ObtenerDanio(int id);
        IEnumerable<Danio> ObtenerDanios();
        bool ActualizarDanio(int id, Danio danio);
    }
}