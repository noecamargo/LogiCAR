using LogiCAR.AccesoDatos;
using LogiCAR.CapaAccesoDatos;
using LogiCAR.Entidades;
using System.Collections.Generic;
using System.Web.Http;

namespace LogiCAR.CapaLogicaNegocio
{
    public class LogicaNegocioVehiculo : ILogicaNegocioVehiculo
    {
        private LogiCar modelo;
                
        public LogicaNegocioVehiculo(LogiCar modelo)
        {
            this.modelo = modelo;
        }

        public IEnumerable<Vehiculo> ListaVehiculos()
        {
            return modelo.GetVehiculos();
        }

        public bool Put(int id, [FromBody] string value)
        {
            Vehiculo vehiculo = new Vehiculo();
            vehiculo.VIN = new System.Guid();
            vehiculo.Anio = "2017";
            return modelo.AgregarVehiculo(vehiculo);
        }
    }
}