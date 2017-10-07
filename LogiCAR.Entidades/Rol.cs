using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogiCAR.Entidades
{
    [Table("Rol")]
    public class Rol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRol { get; set; }

        //[Key]
        public string Nombre { get; set; }

        public virtual List<Funcionalidad> Permisos { get; set; }

        public Rol()
        {
           Permisos = new List<Funcionalidad>();
        }
        public Rol(string nombre)
        {
            Nombre = nombre;
            Permisos = new List<Funcionalidad>();
        }
       
       
    }
}