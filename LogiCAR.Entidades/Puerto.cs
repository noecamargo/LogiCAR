using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogiCAR.Entidades
{
    public class Puerto : Lugar
    {
        public virtual List<Vehiculo> Vehiculos { get; set; }
        public Puerto()
        {
            Vehiculos = new List<Vehiculo>();
	    }
    }
}