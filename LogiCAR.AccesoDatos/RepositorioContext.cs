namespace LogiCAR.CapaAccesoDatos
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Entidades;

    public class RepositorioContext : DbContext
    {
        //private string connectionString = @"data source=localhost\SQLEXPRESS;initial catalog=LogiCAR;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
        //public RepositorioContext()
        //    : base()
        //{
        //    Database.Connection.ConnectionString = connectionString;
        //}
           
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Funcionalidad> Funcionalidades { get; set; }

       
    }
}
