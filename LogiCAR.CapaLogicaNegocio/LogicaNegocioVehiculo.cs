using LogiCAR.AccesoDatos;
using LogiCAR.Entidades;
using System;
using System.Collections.Generic;

namespace LogiCAR.CapaLogicaNegocio
{
    public class LogicaNegocioVehiculo : ILogicaNegocioVehiculo
    {
        private IRepositorioVehiculo repositorioVehiculo;

        public LogicaNegocioVehiculo()
        {
            repositorioVehiculo = new RepositorioVehiculo();
        }

        public LogicaNegocioVehiculo(IRepositorioVehiculo repositorio)
        {
            repositorioVehiculo = repositorio;
        }

        public bool CrearVehiculo(Vehiculo vehiculo)
        {
            validacionInsertarVehiculo(vehiculo);

            if (repositorioVehiculo.InsertarVehiculo(vehiculo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void validacionInsertarVehiculo(Vehiculo vehiculo)
        {
            if(vehiculo == null)
                throw new ArgumentNullException("Vehiculo vacio");
            if (vehiculo.VIN != null && vehiculo.VIN == Guid.Empty)
                throw new ArgumentNullException("El vehiculo debe tener un VIN");
            if (ExisteVechiculo(vehiculo.VIN))
                throw new  Exception("El vehiculo ya existe en el sistema");
        }

        private bool ExisteVechiculo(Guid VIN)
        {
            return repositorioVehiculo.ObtenerVehiculo(VIN) != null;
        }

        public IEnumerable<Vehiculo> ListaVehiculos()
        {
            //IEnumerable<Vehiculo> retorno = new IEnumerable<Vehiculo>();
            return repositorioVehiculo.ObtenerVehiculos();
        }

        public Vehiculo ObtenerVehiculo(Guid VIN)
        {
            return repositorioVehiculo.ObtenerVehiculo(VIN);
        }

        public bool ActualizarVehiculo(Guid VIN, Vehiculo vehiculo)
        {
            return repositorioVehiculo.ActualizarVehiculo(VIN, vehiculo);
        }
    }
}