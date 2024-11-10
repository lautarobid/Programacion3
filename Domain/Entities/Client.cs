namespace Domain.Entities
{
    public class Client : User
    {
        public int Id { get; set; }
        public List<Bill> Bills { get; private set; } = new List<Bill>(); // Cambié "Bill" a "Bills" (plural)
        public List<Trip> Trips { get; private set; } = new List<Trip>();
    }
}