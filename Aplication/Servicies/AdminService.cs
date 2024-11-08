using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        public async Task<Admin?> GetAdminByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _adminRepository.GetByIdAsync(id, cancellationToken);
        }

        public async Task<List<Admin>> GetAllAdminsAsync(CancellationToken cancellationToken = default)
        {
            return await _adminRepository.ListAsync(cancellationToken);
        }

        public async Task<Admin> AddAdminAsync(Admin admin, CancellationToken cancellationToken = default)
        {
            return await _adminRepository.AddAsync(admin, cancellationToken);
        }

        public async Task UpdateAdminAsync(Admin admin, CancellationToken cancellationToken = default)
        {
            await _adminRepository.UpdateAsync(admin, cancellationToken);
        }

        public async Task DeleteAdminAsync(int id, CancellationToken cancellationToken = default)
        {
            var admin = await _adminRepository.GetByIdAsync(id, cancellationToken);
            if (admin != null)
            {
                await _adminRepository.DeleteAsync(admin, cancellationToken);
            }
            else
            {
                throw new KeyNotFoundException("Admin no encontrado");
            }
        }
    }
}