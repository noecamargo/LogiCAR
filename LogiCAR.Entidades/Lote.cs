using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LogiCAR.Entidades
{
    public class Lote
    {
        [Key]
        public long Id { get; set; }

        public Usuario Creador { get; set; }
        public string Decripcion { get; set; }
        public string Nombre { get; set; }
        public bool ProntoParaPartida { get; set; }
        public List<Vehiculo> Vehiculos { get; set; }
    }
}