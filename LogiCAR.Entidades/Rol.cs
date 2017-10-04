using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LogiCAR.Entidades
{
    public class Rol
    {
        public Rol(string nombreTipoUsuario)
        {
            Nombre = nombreTipoUsuario;
            Permisos = new List<Funcionalidad>();
        }
        [Key]
        public string Nombre { get; set; }
        public List<Funcionalidad> Permisos { get; set; }
    }
}