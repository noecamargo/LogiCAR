﻿using LogiCAR.Entidades;
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
        {}
       
        public DbSet<Vehiculo> Vehiculos { get; set; }

    }
}
