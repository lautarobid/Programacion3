using Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAdminService
    {
        Task<Admin?> GetAdminByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<List<Admin>> GetAllAdminsAsync(CancellationToken cancellationToken = default);
        Task<Admin> AddAdminAsync(Admin admin, CancellationToken cancellationToken = default);
        Task UpdateAdminAsync(Admin admin, CancellationToken cancellationToken = default);
        Task DeleteAdminAsync(int id, CancellationToken cancellationToken = default);
    }
}