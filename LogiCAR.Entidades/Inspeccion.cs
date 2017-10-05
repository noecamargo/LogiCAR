﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogiCAR.Entidades
{
    public class Inspeccion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime Creacion { get; set; }
        //public Danio Danio { get; set; }
        //public Usuario Usuario { get; set; }
        
        public virtual Vehiculo VIN { get; set; }
    }
}
