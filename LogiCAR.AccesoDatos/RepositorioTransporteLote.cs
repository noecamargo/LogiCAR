using LogiCAR.CapaAccesoDatos;
using LogiCAR.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LogiCAR.AccesoDatos
{
    public class RepositorioTransporteLote : IRepositorioTransporteLote
    {
        public long InsertarTransporteLote(TransporteLote transporte)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {

                contexto.TransporteLotes.Add(transporte);
                contexto.SaveChanges();
                return transporte.Id;
            }
        }

        public TransporteLote ObtenerTransporteLote(long id)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                return contexto.TransporteLotes
                    .Where(d => d.Id.Equals(id))
                    .FirstOrDefault();
            }
        }

        public IEnumerable<TransporteLote> ObtenerTransporteLotes()
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                return contexto.TransporteLotes;
            }
        }

        public bool ActualizarTransporteLote(long id, TransporteLote transporte)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                TransporteLote transporteViejo = ObtenerTransporteLote(id);
                if (transporteViejo == null)
                {
                    return false;
                }
                transporteViejo.FechaInicio = transporte.FechaInicio;
                transporteViejo.FechaFin = transporte.FechaFin;
                transporteViejo.Lotes = transporte.Lotes;

                contexto.Entry(transporteViejo).State = System.Data.Entity.EntityState.Modified;
                return contexto.SaveChanges() > 0;
            }
        }
    }
}
