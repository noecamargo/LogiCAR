using LogiCAR.CapaAccesoDatos;
using LogiCAR.Entidades;
using System.Collections.Generic;

namespace LogiCAR.CapaLogicaNegocio
{
    public class LogicaNegocioVehiculo : ILogicaNegocioVehiculo
    {
        private IAccesoDatosVehiculo repositorioVehiculo;

        public LogicaNegocioVehiculo(IAccesoDatosVehiculo repositorio)
        {
            repositorioVehiculo = repositorio;
        }

        public IEnumerable<Vehiculo> Get()
        {
            return repositorioVehiculo.Get();
        }
    }
}