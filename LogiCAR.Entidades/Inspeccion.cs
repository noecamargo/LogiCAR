﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiCAR.Entidades
{
    public class Inspeccion
    {
        [Key]
        public int Id { get; set; }

        public DateTime Creacion { get; set; }
        //public Danio Danio { get; set; }
        //public Usuario Usuario { get; set; }
        public Vehiculo VIN { get; set; }
    }
}
