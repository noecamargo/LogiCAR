using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogiCAR.Entidades
{
    public class Puerto : Lugar
    {
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPuerto { get; set; }
        public virtual List<Vehiculo> Vehiculos { get; set; }
        public Puerto()
        {
            Vehiculos = new List<Vehiculo>();
	    }
    }
}