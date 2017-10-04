using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiCAR.Entidades
{
    public class Inspeccion
    {
        public DateTime Creacion { get; set; }
        public Danio Danio { get; set; }
        public Usuario Usuario { get; set; }
        public Vehiculo Vehiculo { get; set; }
    }
}
