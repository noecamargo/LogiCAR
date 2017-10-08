using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiCAR.Entidades
{
    public class Historico
    {
        public enum Estado { en_puerto, para_salir,en_transito,en_patio, subzona };

        [Key]
        public int Id { get; set; }
        public Estado estado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        [ForeignKey("NombreUsuario")]
        public string NombreUsuario { get; set; }
        public string Sitio { get; set; }
    }
    
}
