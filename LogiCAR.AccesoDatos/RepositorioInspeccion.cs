using LogiCAR.CapaAccesoDatos;
using LogiCAR.Entidades;
using System.Collections.Generic;
using System.Linq;


namespace LogiCAR.AccesoDatos
{
    public class RepositorioInspeccion : IRepositorioInspeccion
    {
        public int InsertarInspeccion(Inspeccion inspeccion)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {

                contexto.Inspecciones.Add(inspeccion);
                contexto.SaveChanges();
                return inspeccion.Id;
            }
        }

        public Inspeccion ObtenerInspeccion(int id)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                return contexto.Inspecciones
                    .Where(i => i.Id.Equals(id))
                    .FirstOrDefault();
            }
        }

        public IEnumerable<Inspeccion> ObtenerInspecciones()
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                return contexto.Inspecciones;
            }
        }

        public bool ActualizarInspeccion(int id, Inspeccion inspeccion)
        {
            return true;
        }
    }
}
