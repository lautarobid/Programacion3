using Domain.Entities;

namespace Aplication.Models.Request
{
    public class TripRequest
    {
        public string? StartingPoint { get; set; }
        public string? Destination { get; set; }
        public DateTime? DepartureDate { get; set; }
        public int? TruckDriverId { get; set; }
        public int? ClientId { get; set; }
        public BillRequest? Bill { get; set; }
    }
}
