using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TripRepository : ITripRepository
    {
        private readonly ApplicationDBContext _context;

        public TripRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public Trip? GetById(int idTrip) // Asegúrate de que el tipo de retorno permita nulos
        {
            return _context.Trips.FirstOrDefault(t => t.IdTrip == idTrip);
        }

        public List<Trip> GetAll()
        {
            return _context.Trips.ToList();
        }

        public int AddTrip(Trip trip)
        {
            _context.Trips.Add(trip);
            _context.SaveChanges();
            return trip.IdTrip; // Retorna el ID del viaje creado
        }

        public void UpdateTrip(Trip trip)
        {
            _context.Trips.Update(trip);
            _context.SaveChanges();
        }

        public bool DeleteTrip(int idTrip) // Cambiado de string a int
        {
            var trip = GetById(idTrip);
            if (trip != null)
            {
                _context.Trips.Remove(trip);
                _context.SaveChanges();
                return true; // Devuelve true si se eliminó exitosamente
            }
            return false; // Devuelve false si no se encontró el viaje
        }
    }
}