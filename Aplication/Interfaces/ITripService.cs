using Aplication.Models.Request;
using Aplication.Models.Response;

namespace Aplication.Interfaces
{
    public interface ITripService
    {
        Task<TripResponse> CreateTripAsync(TripRequest tripRequest);
        Task<TripResponse> UpdateTripAsync(int tripId, TripRequest tripRequest);
        Task<TripResponse> GetTripByIdAsync(int tripId);
        Task DeleteTripAsync(int tripId, int userId);
        Task<List<TripResponse>> GetAllTripsAsync(CancellationToken cancellationToken = default);
    }
}
