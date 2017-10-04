using System.ComponentModel.DataAnnotations;

namespace LogiCAR.Entidades
{
    public class Usuario
    {

        [Key]
        public string NombreUsuario { get; set; }
        public string Apellido { get; set; }
        public string Contrasenia { get; set; }
        public string Nombre { get; set; }
        public Rol Rol { get; set; }
        public string Telefono { get; set; }
    }
}