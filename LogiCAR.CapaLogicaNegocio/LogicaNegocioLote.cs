using LogiCAR.AccesoDatos;
using LogiCAR.CapaAccesoDatos;
using LogiCAR.Entidades;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace LogiCAR.CapaLogicaNegocio
{
    public class LogicaNegocioLote : ILogicaNegocioLote
    {
        private IRepositorio modelo;

        public LogicaNegocioLote(IRepositorio modelo)
        {
            this.modelo = modelo;
        }

        public long CrearLote(Lote lote)
        {
            return modelo.InsertarLote(lote);
        }

        public Lote ObtenerLote(long id)
        {
            return modelo.ObtenerLote(id);
        }

        public IEnumerable<Lote> ObtenerLotes()
        {
            return modelo.ObtenerLotes();
        }

        public bool ActualizarLote(long id, Lote lote)
        {
            return modelo.ActualizarLote(id, lote);
        }
    }
}