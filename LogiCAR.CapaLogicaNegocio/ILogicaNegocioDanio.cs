using LogiCAR.Entidades;
using System.Collections.Generic;
using System.Web.Http;
using System;

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