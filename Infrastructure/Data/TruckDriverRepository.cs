using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class TruckDriverRepository : EfRepository<TruckDriver>, ITruckDriverRepository
    {
        public TruckDriverRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
        }

        // Implementación del método para obtener conductores disponibles
        public async Task<List<TruckDriver>> GetAvailableDriversAsync(CancellationToken cancellationToken = default)
        {
            return await _context.TruckDrivers
                .Where(driver => driver.TruckPatent != null) // Condición para disponibilidad, ajusta según tu lógica
                .ToListAsync(cancellationToken);
        }
    }
}