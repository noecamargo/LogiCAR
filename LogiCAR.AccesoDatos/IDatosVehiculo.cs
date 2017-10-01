using System.Collections.Generic;
using LogiCAR.Entidades;

namespace LogiCAR.CapaAccesoDatos
{
    public interface IAccesoDatosVehiculo
    {
        IEnumerable<Vehiculo> Get();
    }
}