using LogiCAR.Entidades;
using System.Collections.Generic;
using System.Web.Http;
using System;

namespace LogiCAR.CapaLogicaNegocio
{
    public interface ILogicaNegocioLote
    {
        int CrearLote(Lote lote);
        Lote ObtenerLote(long id);
        IEnumerable<Lote> ObtenerLotes();
        bool ActualizarLote(int id, Lote lote);
    }
}