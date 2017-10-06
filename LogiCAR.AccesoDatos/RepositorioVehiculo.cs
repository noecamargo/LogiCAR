using LogiCAR.CapaAccesoDatos;
using LogiCAR.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LogiCAR.AccesoDatos
{
    public class RepositorioVehiculo : IRepositorioVehiculo
    {
        public bool InsertarVehiculo(Vehiculo vehiculo)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {

                contexto.Vehiculos.Add(vehiculo);
                return contexto.SaveChanges() > 0;
            }

        }

        public Vehiculo ObtenerVehiculo(Guid VIN)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                return contexto.Vehiculos
                    .Where(v => v.VIN.Equals(VIN))
                    .FirstOrDefault();
            }
        }

        public IEnumerable<Vehiculo> ObtenerVehiculos()
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                return contexto.Vehiculos;
            }

        }

        public bool ActualizarVehiculo(Guid VIN, Vehiculo vehiculo)
        {
            using (RepositorioContext contexto = new RepositorioContext())
            {
                Vehiculo vehiculoViejo = ObtenerVehiculo(VIN);
                if (vehiculo == null)
                {
                    return false;
                }
                vehiculoViejo.Anio = vehiculo.Anio;
                vehiculoViejo.Color = vehiculo.Color;
                vehiculoViejo.Marca = vehiculo.Marca;
                vehiculoViejo.Modelo = vehiculo.Modelo;


                contexto.Entry(vehiculoViejo).State = System.Data.Entity.EntityState.Modified;
                return contexto.SaveChanges() > 0;
            }
        }
    }
}
