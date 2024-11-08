using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class AdminRepository : EfRepository<Admin>, IAdminRepository
    {
        public AdminRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
        }

        // Implementación de métodos específicos para Admin, si es necesario.
    }
}