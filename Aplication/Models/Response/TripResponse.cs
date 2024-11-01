namespace Aplication.Models.Response
{
    public class TripResponse
    {
        public int Id { get; set; }
        public string? StartingPoint { get; set; }
        public string? Destination { get; set; }
        public DateTime? DepartureDate { get; set; }
        public BillResponse Bill { get; set; }
    }
}
