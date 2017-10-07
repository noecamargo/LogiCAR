using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogiCAR.Entidades
{
    public class SubZona
    {
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdSubZona { get; set; }
        public int Capacidad { get; set; }
        public int Disponible { get; set; }
        public string Nombre { get; set; }
        public virtual List<Vehiculo> Vehiculos { get; set; }

        public SubZona()
        {
            Vehiculos = new List<Vehiculo>();
            Capacidad = Disponible;
        }

       
    }
}