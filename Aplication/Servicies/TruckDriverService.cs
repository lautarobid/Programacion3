
using Domain.Entities;
using Domain.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TruckDriverService : ITruckDriverService
    {
        private readonly ITruckDriverRepository _truckDriverRepository;

        public TruckDriverService(ITruckDriverRepository truckDriverRepository)
        {
            _truckDriverRepository = truckDriverRepository;
        }

        // Método para obtener todos los conductores disponibles
        public async Task<List<TruckDriver>> GetAvailableDriversAsync(CancellationToken cancellationToken = default)
        {
            return await _truckDriverRepository.GetAvailableDriversAsync(cancellationToken);
        }

        // Método para agregar un nuevo conductor
        public async Task<TruckDriver> AddTruckDriverAsync(TruckDriver driver, CancellationToken cancellationToken = default)
        {
            await _truckDriverRepository.AddAsync(driver, cancellationToken);
            return driver;
        }

        // Método para actualizar un conductor existente
        public async Task UpdateTruckDriverAsync(TruckDriver driver, CancellationToken cancellationToken = default)
        {
            await _truckDriverRepository.UpdateAsync(driver, cancellationToken);
        }

        // Método para eliminar un conductor por su ID
        public async Task DeleteTruckDriverAsync(int id, CancellationToken cancellationToken = default)
        {
            var driver = await _truckDriverRepository.GetByIdAsync(id, cancellationToken);
            if (driver != null)
            {
                await _truckDriverRepository.DeleteAsync(driver, cancellationToken);
            }
            else
            {
                throw new KeyNotFoundException("Conductor no encontrado");
            }
        }

        // Método para obtener un conductor por su ID
        public async Task<TruckDriver?> GetTruckDriverByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _truckDriverRepository.GetByIdAsync(id, cancellationToken);
        }
    }
}