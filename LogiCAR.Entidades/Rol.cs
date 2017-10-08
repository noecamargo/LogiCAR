﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogiCAR.Entidades
{
  
    public class Rol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public virtual List<Funcionalidad> Permisos { get; set; }

        public Rol()
        {
           Permisos = new List<Funcionalidad>();
        }
        public Rol(string nombre)
        {
            Nombre = nombre;
            Permisos = new List<Funcionalidad>();
        }
       
       
    }
}