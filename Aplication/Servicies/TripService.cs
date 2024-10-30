using Aplication.Dtos;
using Domain.Interfaces;

namespace Aplication.Servicies
{
    public class TripService
    {
        private readonly ITripRepository _tripRepository;

        public TripService(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        // Obtener un viaje por ID
        public TripDto GetTripById(int idTrip)  // idTrip es de tipo int
        {
            var trip = _tripRepository.GetById(idTrip);
            if (trip == null)
                throw new KeyNotFoundException($"No se encontró un viaje con el ID {idTrip}");

            return ConvertToDto(trip);
        }

        // Obtener todos los viajes
        public List<TripDto> GetAllTrips()
        {
            var trips = _tripRepository.GetAll();
            return trips.Select(ConvertToDto).ToList();
        }

        // Agregar un nuevo viaje
        public int AddTrip(TripForCreationDto tripDto)
        {
            var trip = new Trip
            {
                Origin = tripDto.Origin,
                Destination = tripDto.Destination,
                Cost = tripDto.Cost,
                DepartureDate = tripDto.DepartureDate
            };

            return _tripRepository.AddTrip(trip);  // Retorna el ID del viaje creado
        }

        // Actualizar un viaje existente
        public bool UpdateTrip(int idTrip, TripForUpdateDto tripDto)
        {
            var existingTrip = _tripRepository.GetById(idTrip);
            if (existingTrip == null) return false;

            existingTrip.Origin = tripDto.Origin;
            existingTrip.Destination = tripDto.Destination;
            existingTrip.Cost = tripDto.Cost;
            existingTrip.DepartureDate = tripDto.DepartureDate;

            _tripRepository.UpdateTrip(existingTrip);
            return true;
        }

        // Eliminar un viaje por ID
        public bool DeleteTrip(int idTrip)
        {
            return _tripRepository.DeleteTrip(idTrip);
        }

        // Método privado para convertir un Trip a TripDto
        private TripDto ConvertToDto(Trip trip)
        {
            return new TripDto
            {
                IdTrip = trip.IdTrip,
                Origin = trip.Origin,
                Destination = trip.Destination,
                Cost = trip.Cost,
                DepartureDate = trip.DepartureDate
            };
        }
    }
}