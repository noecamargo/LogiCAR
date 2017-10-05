using System.ComponentModel.DataAnnotations;

namespace LogiCAR.Entidades
{
    public class Funcionalidad
    {
        public Funcionalidad(string nombre)
        {
            Nombre = nombre;
        }
        [Key]
        public string Nombre { get; set; }
    }
}