using System.Collections.Generic;
using LogiCAR.Entidades;

namespace LogiCAR.AccesoDatos
{
    public interface IRepositorioTransporteLote
    {
        bool ActualizarTransporteLote(long id, TransporteLote transporte);
        long InsertarTransporteLote(TransporteLote transporte);
        TransporteLote ObtenerTransporteLote(long id);
        ICollection<TransporteLote> ObtenerTransporteLotes();
    }
}