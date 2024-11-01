using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class TripRepository : EfRepository<Trip>, ITripRepository
    {
        public TripRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
        }


        public async Task<Trip?> GetTripWithBillsAsync(int id)
        {
            return await _context.Trips
                .Include(t => t.Bill) // Incluye la colección de Bills
                .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
