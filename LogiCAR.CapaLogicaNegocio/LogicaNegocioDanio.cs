using LogiCAR.AccesoDatos;
using LogiCAR.Entidades;
using System.Collections.Generic;

namespace LogiCAR.CapaLogicaNegocio
{
    public class LogicaNegocioDanio : ILogicaNegocioDanio
    {
        private IRepositorioDanio repositorioDanio;

        public LogicaNegocioDanio(IRepositorioDanio repositorio)
        {
            repositorioDanio = repositorio;
        }

        public int CrearDanio(Danio danio)
        {
            return repositorioDanio.InsertarDanio(danio);
        }

        public Danio ObtenerDanio(int id)
        {
            return repositorioDanio.ObtenerDanio(id);
        }

        public IEnumerable<Danio> ObtenerDanios()
        {
            return repositorioDanio.ObtenerDanios();
        }

        public bool ActualizarDanio(int id, Danio danio)
        {
            return true;
        }
    }
}