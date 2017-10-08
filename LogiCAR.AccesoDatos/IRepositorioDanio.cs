using System.Collections.Generic;
using LogiCAR.Entidades;

namespace LogiCAR.AccesoDatos
{
    public interface IRepositorioDanio
    {
        bool ActualizarDanio(int id, Danio danio);
        int InsertarDanio(Danio danio);
        Danio ObtenerDanio(int id);
        ICollection<Danio> ObtenerDanios();
    }
}