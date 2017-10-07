using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogiCAR.Entidades
{
    public class Zona
    {
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdZona { get; set; }
        public int Capacidad { get; set; }
        public int Disponible { get; set; }
        public string Nombre { get; set; }

        public List<SubZona> SubZonas { get; set; }
        public Zona()
        {
            SubZonas = new List<SubZona>();
        }
    }
}