using System;
using System.ComponentModel.DataAnnotations;

namespace LogiCAR.Entidades
{
    public class Vehiculo
    {
        [Key]
        public Guid VIN { get; set; }
        public string Anio { get; set; }
        public string Color { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        
    }
}