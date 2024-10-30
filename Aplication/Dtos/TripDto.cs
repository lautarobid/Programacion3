using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Dtos
{
    public class TripDto
    {
        public int IdTrip { get; set; }
        public required string Origin { get; set; }  // Marcado como required
        public required string Destination { get; set; }  // Marcado como required
        public float Cost { get; set; }
        public DateTime DepartureDate { get; set; }
    }

    public class TripForCreationDto
    {
        public required string Origin { get; set; }
        public required string Destination { get; set; }
        public required float Cost { get; set; }
        public required DateTime DepartureDate { get; set; }
    }

    public class TripForUpdateDto
    {
        public required string Origin { get; set; }
        public required string Destination { get; set; }
        public required float Cost { get; set; }
        public required DateTime DepartureDate { get; set; }
    }
}