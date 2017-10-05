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
        private string connectionString = "Data Source = VPUY-ACAPECE; Initial Catalog = LogiCAR; Integrated Security = True; MultipleActiveResultSets=True";

        public bool InsertarVehiculo(Vehiculo vehiculo)
        {
            using (LogiCarContext ctx = new AccesoDatos.LogiCarContext(connectionString))
            {

                ctx.Vehiculos.Add(vehiculo);
                return ctx.SaveChanges() > 0;
            }

        }

        public Vehiculo ObtenerVehiculo(Guid VIN)
        {
            using (LogiCarContext ctx = new AccesoDatos.LogiCarContext(connectionString))
            {
                return ctx.Vehiculos
                    .Where(v => v.VIN.Equals(VIN))
                    .FirstOrDefault();
            }
        }

        public IEnumerable<Vehiculo> ObtenerVehiculos()
        {
            using (LogiCarContext ctx = new AccesoDatos.LogiCarContext(connectionString))
            {
                return ctx.Vehiculos;
            }

        }

        public bool ActualizarVehiculo(Guid VIN, Vehiculo vehiculo)
        {
            using (LogiCarContext ctx = new AccesoDatos.LogiCarContext(connectionString))
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


                ctx.Entry(vehiculoViejo).State = System.Data.Entity.EntityState.Modified;
                return ctx.SaveChanges() > 0;
            }
        }

        public bool InsertarInspeccion(Inspeccion inspeccion)
        {
            using (LogiCarContext ctx = new AccesoDatos.LogiCarContext(connectionString))
            {

                ctx.Inspecciones.Add(inspeccion);
                return ctx.SaveChanges() > 0;
            }
        }

        public Inspeccion ObtenerInspeccion(int id)
        {
            using (LogiCarContext ctx = new AccesoDatos.LogiCarContext(connectionString))
            {
                return ctx.Inspecciones
                    .Where(i => i.Id.Equals(id))
                    .FirstOrDefault();
            }
        }

        public IEnumerable<Inspeccion> ObtenerInspecciones()
        {
            using (LogiCarContext ctx = new AccesoDatos.LogiCarContext(connectionString))
            {
                return ctx.Inspecciones;
            }
        }

        public bool ActualizarInspeccion(int id, Inspeccion inspeccion)
        {
            return true;
        }
    }
}
