using LogiCAR.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiCAR.AccesoDatos
{
    public interface IRepositorio
    {
        Guid CrearVehiculo(Vehiculo vehiculo);

        Vehiculo ObtenerVehiculo(Guid vIN);

        IEnumerable<Vehiculo> ListaVehiculos();
       
    }
}
