using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogiCAR.Entidades
{
    [Table("Lote")]
    public class Lote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public Usuario Creador { get; set; }
        public string Descripcion { get; set; }
        public string Nombre { get; set; }
        public bool ProntoParaPartida { get; set; }
        public List<Vehiculo> Vehiculos { get; set; }
    }
}