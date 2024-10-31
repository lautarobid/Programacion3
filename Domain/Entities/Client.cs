using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Client : User
    {
        public required string IdClient { get; set; }
        public required Bill Bill { get; set; }
        // Lista de viajes asociados al cliente
        public List<Trip> Trips { get; set; } = new List<Trip>();

        // Método para listar los viajes
        public void TravelList()
        {
            if (Trips.Count == 0)
            {
                Console.WriteLine("No hay viajes asociados a este cliente.");
            }
            else
            {
                Console.WriteLine($"Lista de viajes para el cliente {Name} {LastName}:");
                foreach (var trip in Trips)
                {
                    Console.WriteLine($"- Viaje ID: {trip.IdTrip}, Origen: {trip.Origin}, Destino: {trip.Destination}, Costo: {trip.Cost}");
                }
            }
        }
    }
}