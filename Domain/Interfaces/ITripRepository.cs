namespace Domain.Interfaces
{
    public interface ITripRepository : IRepositoryBase<Trip>
    {
        Task<Trip?> GetTripWithBillsAsync(int id);

    }
}
