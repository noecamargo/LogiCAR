using LogiCAR.AccesoDatos;
using LogiCAR.Entidades;
using System.Collections.Generic;


namespace LogiCAR.CapaLogicaNegocio
{
    public class LogicaNegocioTransporteLote : ILogicaNegocioTransporteLote
    {
        private IRepositorioTransporteLote repositorioTransporteLote;

        public LogicaNegocioTransporteLote(IRepositorioTransporteLote repositorio)
        {
            this.repositorioTransporteLote = repositorio;
        }

        public long CrearTransporteLote(TransporteLote transporte)
        {
            return repositorioTransporteLote.InsertarTransporteLote(transporte);
        }

        public TransporteLote ObtenerTransporteLote(long id)
        {
            return repositorioTransporteLote.ObtenerTransporteLote(id);
        }

        public IEnumerable<TransporteLote> ObtenerTransporteLotes()
        {
            return repositorioTransporteLote.ObtenerTransporteLotes();
        }

        public bool ActualizarTransporteLote(long id, TransporteLote transporte)
        {
            return repositorioTransporteLote.ActualizarTransporteLote(id,transporte);
        }
    }
}