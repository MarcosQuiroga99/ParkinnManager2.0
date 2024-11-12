using System.ComponentModel.DataAnnotations;

namespace Estacionamiento.Models
{
    public class Administrador
    {
        [Key]
        public string? Legajo {  get; set; }
        public int EstacionamientoId { get; set; }
        public Estacionamiento? Estacionamiento { get; set; }
    }
}
