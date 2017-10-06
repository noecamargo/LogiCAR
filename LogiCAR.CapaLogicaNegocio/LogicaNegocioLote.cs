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

        public int CrearLote(Lote lote)
        {
            return 1;
        }

        public Lote ObtenerLote(long id)
        {
            return new Lote();
        }

        public IEnumerable<Lote> ObtenerLotes()
        {
            return null;
        }

        public bool ActualizarLote(int id, Lote lote)
        {
            return true;
        }
    }
}