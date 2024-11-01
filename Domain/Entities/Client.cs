namespace Domain.Entities
{
    public class Client : User
    {
        public List<Bill> Bill { get; set; } = new List<Bill>();
        // Lista de viajes asociados al cliente
        public List<Trip> Trips { get; set; } = new List<Trip>();
    }
}