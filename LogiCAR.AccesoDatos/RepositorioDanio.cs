using LogiCAR.CapaAccesoDatos;
using LogiCAR.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace LogiCAR.AccesoDatos
{
    public class RepositorioDanio : IRepositorioDanio
    {
        public int InsertarDanio(Danio danio)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {

                contexto.Danios.Add(danio);
                contexto.SaveChanges();
                return danio.Id;
            }
        }

        public Danio ObtenerDanio(int id)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                return contexto.Danios
                    .Where(d => d.Id.Equals(id))
                    .FirstOrDefault();
            }
        }

        public IEnumerable<Danio> ObtenerDanios()
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                return contexto.Danios;
            }
        }

        public bool ActualizarDanio(int id, Danio danio)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                Danio danioViejo = ObtenerDanio(id);
                if (danioViejo == null)
                {
                    return false;
                }
                danioViejo.Descripcion = danio.Descripcion;
                danioViejo.Foto = danio.Foto;

                contexto.Entry(danioViejo).State = System.Data.Entity.EntityState.Modified;
                return contexto.SaveChanges() > 0;
            }
        }

    }
}
