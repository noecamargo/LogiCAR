using System;
using System.Collections.Generic;
using LogiCAR.Entidades;

namespace LogiCAR.AccesoDatos
{
    public interface IRepositorioVehiculo
    {
        bool ActualizarVehiculo(Guid VIN, Vehiculo vehiculo);
        bool InsertarVehiculo(Vehiculo vehiculo);
        Vehiculo ObtenerVehiculo(Guid VIN);
        ICollection<Vehiculo> ObtenerVehiculos();
    }
}