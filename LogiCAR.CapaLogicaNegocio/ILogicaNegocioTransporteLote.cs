using LogiCAR.Entidades;
using System.Collections.Generic;
using System.Web.Http;
using System;

namespace LogiCAR.CapaLogicaNegocio
{
    public interface ILogicaNegocioTransporteLote
    {
        long CrearTransporteLote(TransporteLote transporte);
        TransporteLote ObtenerTransporteLote(long id);
        IEnumerable<TransporteLote> ObtenerTransporteLotes();
        bool ActualizarTransporteLote(long id, TransporteLote transporte);
    }
}