using System.ComponentModel.DataAnnotations;

namespace Estacionamiento.Models
{
    public class Estacionamiento
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
        public Administrador? Administrador { get; set; }

        public string? Direcion {  get; set; }
        public ICollection<Vehiculo>? Plaza { get; set; } = new List<Vehiculo>();   
        public ICollection<Cliente>? Clientes { get; set; } = new List<Cliente>();
        public ICollection<Ticket>? Tickets { get; set; } = new List<Ticket>();
        public int MaxPlaza { get; set; }

        public List<TipoVehiculo>? tipoVehiculos { get; set; } = new List<TipoVehiculo> { };
     }
}
