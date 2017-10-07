using LogiCAR.CapaAccesoDatos;
using LogiCAR.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LogiCAR.AccesoDatos
{
    public class RepositorioLote : IRepositorioLote
    {
        public long InsertarLote(Lote lote)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                
                contexto.Lotes.Add(lote);
                contexto.SaveChanges();
                return lote.Id;
            }
        }

        public Lote ObtenerLote(long id)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                return contexto.Lotes.Include("Vehiculos")
                    .Where(d => d.Id.Equals(id))
                    .FirstOrDefault();
            }
        }

        public IEnumerable<Lote> ObtenerLotes()
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                return contexto.Lotes.Include("Vehiculos");
            }
        }

        public bool ActualizarLote(long id, Lote lote)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                Lote loteViejo = ObtenerLote(id);
                if (loteViejo == null)
                {
                    return false;
                }
                loteViejo.Descripcion = lote.Descripcion;
                loteViejo.Nombre = lote.Nombre;
                loteViejo.ProntoParaPartida = lote.ProntoParaPartida;
                loteViejo.Vehiculos = lote.Vehiculos;

                contexto.Entry(loteViejo).State = System.Data.Entity.EntityState.Modified;
                return contexto.SaveChanges() > 0;
            }
        }

    }
}
