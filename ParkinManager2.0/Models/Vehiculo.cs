﻿using System.ComponentModel.DataAnnotations;

namespace Estacionamiento.Models
{
    public class Vehiculo
    {
        [Key]
        public string Patente { get; set; } 

        public string Marca { get; set; }

        public string Modelo { get; set; }
        public TipoVehiculo? TipoDeVehiculo { get; set; }
        public  int ClienteID { get; set; }
        public Cliente Dueño { get; set; }  
        public int EstacionamientoId { get; set; }
        public Ticket? Ticket { get; set; }
        public Estacionamiento Estacionamiento { get; set; }
    }
}
