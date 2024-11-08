using Domain.Entities;
using Domain.Interfaces;
using Aplication.Models.Request;
using Aplication.Models.Response;
using Aplication.Models.Mappings;
using Aplication.Interfaces;

namespace Aplication.Services
{
    public class TripService : ITripService
    {
        private readonly IRepositoryBase<Trip> _tripRepositoryBase;
        private readonly ITripRepository _tripRepository;
        private readonly TripMapping _tripMapping;
        public TripService(IRepositoryBase<Trip> tripRepositoryBase, ITripRepository tripRepository, TripMapping tripMapping)
        {
            _tripRepositoryBase = tripRepositoryBase;
            _tripRepository = tripRepository;
            _tripMapping = tripMapping;
        }

        // Método para crear un nuevo Trip
        public async Task<TripResponse> CreateTripAsync(TripRequest tripRequest)
        {
            var tripEntity = _tripMapping.MapToEntity(tripRequest);
            var createdTrip = await _tripRepositoryBase.AddAsync(tripEntity);
            return _tripMapping.MapToResponse(createdTrip);
        }

        // Método para editar un Trip existente
        public async Task<TripResponse> UpdateTripAsync(int tripId, TripRequest tripRequest)
        {
            var existingTrip = await _tripRepository.GetTripWithBillsAsync(tripId);
            if (existingTrip == null)
            {
                throw new Exception("Viaje no encontrado.");
            }

            existingTrip = _tripMapping.MapToExistingEntity(existingTrip, tripRequest);
            await _tripRepositoryBase.UpdateAsync(existingTrip);
            return _tripMapping.MapToResponse(existingTrip);
        }

        // Método para obtener un Trip por ID
        public async Task<TripResponse> GetTripByIdAsync(int tripId)
        {
            var trip = await _tripRepository.GetTripWithBillsAsync(tripId);
            if (trip == null)
            {
                throw new Exception("Viaje no encontrado.");
            }

            return _tripMapping.MapToResponse(trip);
        }

        // Método para eliminar un Trip por ID
        public async Task DeleteTripAsync(int tripId, int userId)
        {
            var trip = await _tripRepositoryBase.GetByIdAsync(tripId);

            if (trip == null)
            {
                throw new Exception("Viaje no encontrado.");
            }

            // Validar que el viaje pertenece al usuario actual
            if (trip.ClientId != userId)
            {
                throw new Exception("No tienes permiso para eliminar este viaje.");
            }

            await _tripRepositoryBase.DeleteAsync(trip);
        }

        // Implementación del nuevo método GetAllTripsAsync
        public async Task<List<TripResponse>> GetAllTripsAsync(CancellationToken cancellationToken = default)
        {
            var trips = await _tripRepository.ListAsync(cancellationToken);
            return trips.Select(trip => _tripMapping.MapToResponse(trip)).ToList();
        }
    }
}
