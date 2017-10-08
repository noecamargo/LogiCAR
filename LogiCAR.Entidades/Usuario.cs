using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogiCAR.Entidades
{
    public class Usuario
    {

        public Usuario()
        {
            Habilitado = true;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
                
        
        public string NombreUsuario { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public string Contrasenia { get; set; }

        [Required]
        public string Nombre { get; set; }

                
        public virtual Rol Rol { get; set; }

        public string Telefono { get; set; }
        [Required]
        public bool Habilitado { get; set; }
        public Guid Token { get; set; }
    }
}

