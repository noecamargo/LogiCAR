using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogiCAR.Entidades
{
    [Table("Rol")]
    public class Rol
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? idRol { get; set; }
        [Key]
        [Column(Order = 1)]
        public string Nombre { get; set; }
        public virtual List<Funcionalidad> Permisos { get; set; }

        public Rol()
        {
           Permisos = new List<Funcionalidad>();
        }
        public Rol(string nombreTipoUsuario)
        {
            Nombre = nombreTipoUsuario;
            Permisos = new List<Funcionalidad>();
        }
       
       
    }
}