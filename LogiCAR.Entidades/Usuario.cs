using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogiCAR.Entidades
{
    public class Usuario
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
                
        //TODO Que sea unica
        public string NombreUsuario { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string Contrasenia { get; set; }

        [Required]
        public string Nombre { get; set; }

                
        public virtual Rol Rol { get; set; }

        public string Telefono { get; set; }
        public bool Habilitado { get; set; }
    }
}

