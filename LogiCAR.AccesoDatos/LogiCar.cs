using LogiCAR.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiCAR.AccesoDatos
{
    public class LogiCar
    {

        private IRepositorio repositorio;

        public LogiCar()
        {
            this.repositorio = new RepositorioSqlServer();
        }

        public LogiCar(IRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public bool AgregarVehiculo(Vehiculo vehiculo)
        {

            return repositorio.AgregarVehiculo(vehiculo);

        }

        public IEnumerable<Vehiculo> GetVehiculos()
        {
            return repositorio.ListaVehiculos();
        }
    }
}
