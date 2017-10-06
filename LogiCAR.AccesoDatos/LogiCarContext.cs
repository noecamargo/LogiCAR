using LogiCAR.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiCAR.AccesoDatos
{
    public class LogiCarContext : DbContext
    {
        public LogiCarContext(string connectionString)
                : base(connectionString)
        {
            Database.Connection.ConnectionString = connectionString;
        }
       
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Inspeccion> Inspecciones { get; set; }
        public DbSet<Danio> Danios { get; set; }
        public DbSet<Lote> Lotes { get; internal set; }
    }
}
