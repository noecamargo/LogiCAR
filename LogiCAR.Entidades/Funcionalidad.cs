using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogiCAR.Entidades
{
    public class Funcionalidad
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? idFuncionalidad { get; set; }
        [Key]
        [Column(Order = 1)]
        public string Nombre { get; set; }
    }
}