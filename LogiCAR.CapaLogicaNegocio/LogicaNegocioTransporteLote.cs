using LogiCAR.AccesoDatos;
using LogiCAR.Entidades;
using System.Collections.Generic;


namespace LogiCAR.CapaLogicaNegocio
{
    public class LogicaNegocioTransporteLote : ILogicaNegocioTransporteLote
    {
        private IRepositorioTransporteLote repositorioLote;

        public LogicaNegocioTransporteLote(IRepositorioTransporteLote repositorio)
        {
            this.repositorioLote = repositorio;
        }

        public long CrearTransporteLote(TransporteLote lote)
        {
            return 1;
        }

        public TransporteLote ObtenerTransporteLote(long id)
        {
            return new TransporteLote();
        }

        public IEnumerable<TransporteLote> ObtenerTransporteLotes()
        {
            return null;
        }

        public bool ActualizarTransporteLote(long id, TransporteLote lote)
        {
            return true;
        }
    }
}