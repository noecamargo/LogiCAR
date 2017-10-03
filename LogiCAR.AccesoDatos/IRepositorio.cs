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
        bool AgregarVehiculo(Vehiculo vehiculos);
        IEnumerable<Vehiculo> ListaVehiculos();
    }
}
