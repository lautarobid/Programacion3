using Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ITruckDriverRepository : IRepositoryBase<TruckDriver>
    {
        // Método para obtener una lista de conductores disponibles
        Task<List<TruckDriver>> GetAvailableDriversAsync(CancellationToken cancellationToken = default);
    }
}