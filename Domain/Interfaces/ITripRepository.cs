using Domain.Entities; // Asegúrate de usar el espacio de nombres correcto para la entidad Trip

namespace Domain.Interfaces
{
    public interface ITripRepository
    {
        Trip? GetById(int idTrip);   // Cambiado a int
        List<Trip> GetAll();
        int AddTrip(Trip trip);
        void UpdateTrip(Trip trip);
        bool DeleteTrip(int idTrip);  // Cambiado a int
    }

}