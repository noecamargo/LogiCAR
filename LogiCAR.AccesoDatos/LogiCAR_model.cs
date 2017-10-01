namespace LogiCAR.AccesoDatos
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Entidades;

    public partial class LogiCAR_model : DbContext
   {
        public DbSet<Vehiculo> Vehiculos { get; set; }

        public LogiCAR_model()
            : base("name=LogiCAR_Conn")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
