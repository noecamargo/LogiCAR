using LogiCAR.AccesoDatos;
using LogiCAR.CapaAccesoDatos;
using LogiCAR.Entidades;
using System;
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

        public Vehiculo ObtenerVehiculo(Guid VIN)
        {
            return modelo.ObtenerVehiculo(VIN);
        }

        public bool ModificarVehiculo(Guid VIN,Vehiculo vehiculo)
        {
            return true;
        }

        public Guid CrearVehiculo(Vehiculo vehiculo)
        {
            return Guid.NewGuid();
        }
    }
}