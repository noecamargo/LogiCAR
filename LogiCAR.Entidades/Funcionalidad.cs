using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.DynamicData;

namespace LogiCAR.Entidades
{
   
    public class Funcionalidad
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idFuncionalidad { get; set; }
        public string Nombre { get; set; }
    }
}