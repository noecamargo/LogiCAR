using LogiCAR.AccesoDatos;
using LogiCAR.Entidades;
using System;
using System.Collections.Generic;

namespace LogiCAR.CapaLogicaNegocio
{
    public class LogicaNegocioVehiculo : ILogicaNegocioVehiculo
    {
        private IRepositorioVehiculo repositorioVehiculo;

        public LogicaNegocioVehiculo(IRepositorioVehiculo repositorio)
        {
            repositorioVehiculo = repositorio;
        }

        public Guid CrearVehiculo(Vehiculo vehiculo)
        {
            vehiculo.VIN = Guid.NewGuid();

            if (repositorioVehiculo.InsertarVehiculo(vehiculo))
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
            return repositorioVehiculo.ObtenerVehiculos();
        }

        public Vehiculo ObtenerVehiculo(Guid VIN)
        {
            return repositorioVehiculo.ObtenerVehiculo(VIN);
        }

        public bool ActualizarVehiculo(Guid VIN,Vehiculo vehiculo)
        {
            return repositorioVehiculo.ActualizarVehiculo(VIN,vehiculo);
        }

        
    }
}