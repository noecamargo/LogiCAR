using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LogiCAR.Entidades
{
    public class TransporteLote
    {
        [Key]
        public long Id { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Usuario Creador  { get; set; }
        public ICollection<Lote> Lotes { get; set; }
    }
}