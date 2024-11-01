using Domain.Entities;

public class Trip
{
    public int Id { get; set; }
    public string? StartingPoint { get; set; }
    public string? Destination { get; set; }
    public DateTime? DepartureDate { get; set; }
    public int? TruckDriverId { get; set; }
    public TruckDriver? TruckDriver { get; set; }
    public int? ClientId { get; set; }
    public Client? Client { get; set; }
    public Bill? Bill { get; set; }
}