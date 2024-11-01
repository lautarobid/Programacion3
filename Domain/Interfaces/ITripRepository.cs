namespace Domain.Interfaces
{
    public interface ITripRepository
    {
        Task<Trip?> GetTripWithBillsAsync(int id);

    }
}
