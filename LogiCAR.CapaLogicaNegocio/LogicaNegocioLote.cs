using LogiCAR.AccesoDatos;
using LogiCAR.Entidades;

using System.Collections.Generic;


namespace LogiCAR.CapaLogicaNegocio
{
    public class LogicaNegocioLote : ILogicaNegocioLote
    {
        private IRepositorioLote respositorioLote;

        public LogicaNegocioLote(IRepositorioLote respositorio)
        {
            this.respositorioLote = respositorio;
        }

        public long CrearLote(Lote lote)
        {
            return respositorioLote.InsertarLote(lote);
        }

        public Lote ObtenerLote(long id)
        {
            return respositorioLote.ObtenerLote(id);
        }

        public IEnumerable<Lote> ObtenerLotes()
        {
            return respositorioLote.ObtenerLotes();
        }

        public bool ActualizarLote(long id, Lote lote)
        {
            return respositorioLote.ActualizarLote(id, lote);
        }
    }
}