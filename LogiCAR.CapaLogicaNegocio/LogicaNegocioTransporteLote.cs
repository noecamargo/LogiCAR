using LogiCAR.AccesoDatos;
using LogiCAR.CapaAccesoDatos;
using LogiCAR.Entidades;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace LogiCAR.CapaLogicaNegocio
{
    public class LogicaNegocioTransporteLote : ILogicaNegocioTransporteLote
    {
        private IRepositorio modelo;

        public LogicaNegocioTransporteLote(IRepositorio modelo)
        {
            this.modelo = modelo;
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