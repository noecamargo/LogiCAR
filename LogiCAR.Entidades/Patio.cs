using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogiCAR.Entidades
{
    public class Patio : Lugar
    {
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPatio { get; set; }
        public List<Vehiculo> vehiculos { get; set; }

        public Patio()
        {
            vehiculos = new List<Vehiculo>();
	    }
    }
}