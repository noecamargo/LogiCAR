using System;
using System.ComponentModel.DataAnnotations;

namespace LogiCAR.Entidades
{
    public class Vehiculo
    {
        public string Anio { get; set; }
        public string Color { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        [Key]
        public Guid VIN { get; set; }
    }
}