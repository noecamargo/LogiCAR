using System;

namespace Logi.CAR.WebApi
{
    public class Vehiculo
    {
        public string Anio { get; set; }
        public string Color { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public Guid VIN { get; set; }
    }
}