using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogiCAR.WebApi.Models
{
    public class Vehiculo
    {
        public enum TipoVehiculo {auto=1,camion,suv,van,minivan}
        public Guid VIN { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public int Anio { get; set; }

        public TipoVehiculo Tipo { get; set; }
    }
}