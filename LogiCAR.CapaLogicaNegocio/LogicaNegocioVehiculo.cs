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

        public Guid CrearVehiculo(Vehiculo vehiculo)
        {
            vehiculo.VIN = Guid.NewGuid();

            if (modelo.InsertarVehiculo(vehiculo))
            {
                return vehiculo.VIN;
            }
            else
            {
                return new Guid();
            }
        }

        public IEnumerable<Vehiculo> ListaVehiculos()
        {
            return modelo.ObtenerVehiculos();
        }

        public Vehiculo ObtenerVehiculo(Guid VIN)
        {
            return modelo.ObtenerVehiculo(VIN);
        }

        public bool ActualizarVehiculo(Guid VIN,Vehiculo vehiculo)
        {
            return modelo.ActualizarVehiculo(VIN,vehiculo);
        }

        
    }
}