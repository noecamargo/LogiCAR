namespace LogiCAR.CapaAccesoDatos
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Entidades;

    public class RepositorioContext : DbContext
    {   
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Inspeccion> Inspecciones { get; set; }
        public DbSet<Danio> Danios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Funcionalidad> Funcionalidades { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<TransporteLote> TransporteLotes { get; set; }
    }
}
