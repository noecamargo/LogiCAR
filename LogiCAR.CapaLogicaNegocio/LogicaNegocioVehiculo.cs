using LogiCAR.CapaAccesoDatos;
using LogiCAR.Entidades;
using System.Collections.Generic;
using System.Web.Http;

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
            
        public void Put(int id, [FromBody] string value)
        {
            Vehiculo vehiculo = new Vehiculo();
            vehiculo.VIN = new System.Guid();
            vehiculo.Anio = "2017";
            repositorioVehiculo.Put(vehiculo);
        }
    }
}