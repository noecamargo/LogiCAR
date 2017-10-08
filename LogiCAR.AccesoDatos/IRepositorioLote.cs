using System.Collections.Generic;
using LogiCAR.Entidades;

namespace LogiCAR.AccesoDatos
{
    public interface IRepositorioLote
    {
        bool ActualizarLote(long id, Lote lote);
        long InsertarLote(Lote lote);
        Lote ObtenerLote(long id);
        ICollection<Lote> ObtenerLotes();
    }
}