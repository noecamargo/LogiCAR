using LogiCAR.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiCAR.AccesoDatos
{
    public class RepositorioSqlServer : IRepositorio
    {
        public bool AgregarVehiculo(Vehiculo vehiculo)
        {
            using (LogiCarContext ctx = new AccesoDatos.LogiCarContext())
            {

                ctx.Vehiculos.Add(vehiculo);
                return ctx.SaveChanges() > 0;
            }
        }

        public IEnumerable<Vehiculo> ListaVehiculos()
        {
            using (LogiCarContext ctx = new AccesoDatos.LogiCarContext())
            {
                return ctx.Vehiculos;
            }

        }
    }
}
