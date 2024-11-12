using ParkinManager2._0.Models;
using System.ComponentModel.DataAnnotations;

namespace Estacionamiento.Models
{
    public class Administrador : Usuario
    {
       
        public string? Legajo {  get; set; }
        public int EstacionamientoId { get; set; }
        public Estacionamiento? Estacionamiento { get; set; }
    }
}
