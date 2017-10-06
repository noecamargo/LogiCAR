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

        public int InsertarInspeccion(Inspeccion inspeccion)
        {
            using (LogiCarContext ctx = new AccesoDatos.LogiCarContext(connectionString))
            {

                ctx.Inspecciones.Add(inspeccion);
                ctx.SaveChanges();
                return inspeccion.Id;
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

        public int InsertarDanio(Danio danio)
        {
            using (LogiCarContext ctx = new AccesoDatos.LogiCarContext(connectionString))
            {

                ctx.Danios.Add(danio);
                ctx.SaveChanges();
                return danio.Id;
            }
        }

        public Danio ObtenerDanio(int id)
        {
            using (LogiCarContext ctx = new AccesoDatos.LogiCarContext(connectionString))
            {
                return ctx.Danios
                    .Where(d => d.Id.Equals(id))
                    .FirstOrDefault();
            }
        }

        public IEnumerable<Danio> ObtenerDanios()
        {
            using (LogiCarContext ctx = new AccesoDatos.LogiCarContext(connectionString))
            {
                return ctx.Danios;
            }
        }

        public bool ActualizarDanio(int id, Danio danio)
        {
            using (LogiCarContext ctx = new AccesoDatos.LogiCarContext(connectionString))
            {
                Danio danioViejo = ObtenerDanio(id);
                if (danioViejo == null)
                {
                    return false;
                }
                danioViejo.Descripcion = danio.Descripcion;
                danioViejo.Foto = danio.Foto;
               
                ctx.Entry(danioViejo).State = System.Data.Entity.EntityState.Modified;
                return ctx.SaveChanges() > 0;
            }
        }

        public long InsertarLote(Lote lote)
        {
            using (LogiCarContext ctx = new AccesoDatos.LogiCarContext(connectionString))
            {

                ctx.Lotes.Add(lote);
                ctx.SaveChanges();
                return lote.Id;
            }
        }

        public Lote ObtenerLote(long id)
        {
            using (LogiCarContext ctx = new AccesoDatos.LogiCarContext(connectionString))
            {
                return ctx.Lotes
                    .Where(d => d.Id.Equals(id))
                    .FirstOrDefault();
            }
        }

        public IEnumerable<Lote> ObtenerLotes()
        {
            using (LogiCarContext ctx = new AccesoDatos.LogiCarContext(connectionString))
            {
                return ctx.Lotes;
            }
        }

        public bool ActualizarLote(long id, Lote lote)
        {
            using (LogiCarContext ctx = new AccesoDatos.LogiCarContext(connectionString))
            {
                Lote loteViejo = ObtenerLote(id);
                if (loteViejo == null)
                {
                    return false;
                }
                loteViejo.Descripcion = lote.Descripcion;
                loteViejo.Nombre = lote.Nombre;
                loteViejo.ProntoParaPartida = lote.ProntoParaPartida;
                loteViejo.Vehiculos = lote.Vehiculos;

                ctx.Entry(loteViejo).State = System.Data.Entity.EntityState.Modified;
                return ctx.SaveChanges() > 0;
            }
        }

        public long InsertarTransporteLote(TransporteLote transporte)
        {
            using (LogiCarContext ctx = new AccesoDatos.LogiCarContext(connectionString))
            {

                ctx.TransporteLotes.Add(transporte);
                ctx.SaveChanges();
                return transporte.Id;
            }
        }

        public TransporteLote ObtenerTransporteLote(long id)
        {
            using (LogiCarContext ctx = new AccesoDatos.LogiCarContext(connectionString))
            {
                return ctx.TransporteLotes
                    .Where(d => d.Id.Equals(id))
                    .FirstOrDefault();
            }
        }

        public IEnumerable<TransporteLote> ObtenerTransporteLotes()
        {
            using (LogiCarContext ctx = new AccesoDatos.LogiCarContext(connectionString))
            {
                return ctx.TransporteLotes;
            }
        }

        public bool ActualizarTransporteLote(long id, TransporteLote transporte)
        {
            using (LogiCarContext ctx = new AccesoDatos.LogiCarContext(connectionString))
            {
                TransporteLote transporteViejo = ObtenerTransporteLote(id);
                if (transporteViejo == null)
                {
                    return false;
                }
                transporteViejo.FechaInicio = transporte.FechaInicio;
                transporteViejo.FechaFin = transporte.FechaFin;
                transporteViejo.Lotes = transporte.Lotes;

                ctx.Entry(transporteViejo).State = System.Data.Entity.EntityState.Modified;
                return ctx.SaveChanges() > 0;
            }
        }
    }
}
