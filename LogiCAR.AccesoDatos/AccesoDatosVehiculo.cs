using LogiCAR.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiCAR.CapaAccesoDatos
{
    public class AccesoDatosVehiculo : IAccesoDatosVehiculo
    {
        private static List<Vehiculo> list = new List<Vehiculo>();

        public AccesoDatosVehiculo()
        {
        }

        public IEnumerable<Vehiculo> Get()
        {
            return list;
        }
    }
}
