using LogiCAR.Entidades;
using System.Collections.Generic;
using System.Web.Http;
using System;

namespace LogiCAR.CapaLogicaNegocio
{
    public interface ILogicaNegocioVehiculo
    {
        IEnumerable<Vehiculo> ListaVehiculos();
        
        Vehiculo ObtenerVehiculo(Guid VIN);

        bool ActualizarVehiculo(Guid VIN, Vehiculo vehiculo);

        Guid CrearVehiculo(Vehiculo vehiculo);
        
        //void Delete(int id);
        

    }
}