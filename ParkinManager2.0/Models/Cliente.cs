using ParkinManager2._0.Models;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;

namespace Estacionamiento.Models
{
    public class Cliente : Usuario  
    {

        public ICollection<Ticket>? Tickets { get; set; }
        public int VehiculoID { get; set;}
        public virtual ICollection<Vehiculo>? Vehiculos { get; set; } 

        public int EstacionamientoId { get; set; }

        public Estacionamiento? Estacionamiento { get; set; }
         


    }
}
