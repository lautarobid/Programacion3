using Domain.Entities;
using Aplication.Models.Request;
using Aplication.Models.Response;


namespace Domain.Interfaces
{
    public interface ITruckDriverService
{
    Task<List<TruckDriver>> GetAvailableDriversAsync(CancellationToken cancellationToken = default);
    Task<TruckDriver> AddTruckDriverAsync(TruckDriver driver, CancellationToken cancellationToken = default);
    Task UpdateTruckDriverAsync(TruckDriver driver, CancellationToken cancellationToken = default);
    Task DeleteTruckDriverAsync(int id, CancellationToken cancellationToken = default);
    Task<TruckDriver?> GetTruckDriverByIdAsync(int id, CancellationToken cancellationToken = default);
}
}