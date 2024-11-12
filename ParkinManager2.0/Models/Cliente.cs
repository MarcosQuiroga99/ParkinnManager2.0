using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace Estacionamiento.Models
{
    public class Cliente 
    {
        [Key]
        public int Dni { get; set; }

        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }

        public DateTime? FehcaNacimiento { get; set; }

        public DateTime? FechaAlta { get; set; }
        public Ticket? Ticket { get; set; }

        public Version? Vehiculo { get; set; }
        public int EstacionamientoId { get; set; }

        public Estacionamiento? Estacionamiento { get; set; }



    }
}
