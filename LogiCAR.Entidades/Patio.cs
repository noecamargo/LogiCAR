using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogiCAR.Entidades
{
    public class Patio : Lugar
    {
        
        public virtual List<Vehiculo> vehiculos { get; set; }

        public Patio()
        {
            vehiculos = new List<Vehiculo>();
	    }
    }
}