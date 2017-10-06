using LogiCAR.AccesoDatos;
using LogiCAR.CapaAccesoDatos;
using LogiCAR.Entidades;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace LogiCAR.CapaLogicaNegocio
{
    public class LogicaNegocioDanio : ILogicaNegocioDanio
    {
        private IRepositorio modelo;

        public LogicaNegocioDanio(IRepositorio modelo)
        {
            this.modelo = modelo;
        }

        public int CrearDanio(Danio danio)
        {
            return modelo.InsertarDanio(danio);
        }

        public Danio ObtenerDanio(int id)
        {
            return modelo.ObtenerDanio(id);
        }

        public IEnumerable<Danio> ObtenerDanios()
        {
            return modelo.ObtenerDanios();
        }

        public bool ActualizarDanio(int id, Danio danio)
        {
            return true;
        }
    }
}