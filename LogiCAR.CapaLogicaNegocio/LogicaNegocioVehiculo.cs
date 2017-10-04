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
        private IRepositorio modelo;
                
        public LogicaNegocioVehiculo(IRepositorio modelo)
        {
            this.modelo = modelo;
        }

        public IEnumerable<Vehiculo> ListaVehiculos()
        {
            return modelo.ListaVehiculos();
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
            return modelo.CrearVehiculo(vehiculo);
        }
    }
}