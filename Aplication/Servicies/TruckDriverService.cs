using Aplication.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class TruckDriverService
    {
        private readonly ITruckDriverRepository _truckDriverRepository;

        public TruckDriverService(ITruckDriverRepository truckDriverRepository)
        {
            _truckDriverRepository = truckDriverRepository;
        }

        // Obtener todos los conductores
        public IEnumerable<TruckDriverDto> GetAllDrivers()
        {
            return _truckDriverRepository.GetAll().Select(driver => new TruckDriverDto
            {
                Dni = driver.Dni,
                Name = driver.Name,
                LastName = driver.LastName,
                Email = driver.Email,
                TruckPatent = driver.TruckPatent
            });
        }

        // Obtener un conductor por DNI
        public TruckDriverDto GetDriverByDni(string dni)
        {
            var driver = _truckDriverRepository.GetByDni(dni);
            if (driver == null)
                throw new KeyNotFoundException($"No se encontró un conductor con el DNI {dni}");

            return new TruckDriverDto
            {
                Dni = driver.Dni,
                Name = driver.Name,
                LastName = driver.LastName,
                Email = driver.Email,
                TruckPatent = driver.TruckPatent
            };
        }

        // Agregar un nuevo conductor
        public void AddDriver(TruckDriverForCreationDto driverDto)
        {
            var truckDriver = new TruckDriver
            {
                Dni = driverDto.Dni,
                Name = driverDto.Name,
                LastName = driverDto.LastName,
                Email = driverDto.Email,
                Password = driverDto.Password, // Asigna el Password del DTO de creación
                TruckPatent = driverDto.TruckPatent
            };

            _truckDriverRepository.Add(truckDriver);
        }

        // Actualizar los datos de un conductor
        public bool UpdateDriver(string dni, TruckDriverForUpdateDto driverDto) // Cambiar a TruckDriverForUpdateDto
        {
            var existingDriver = _truckDriverRepository.GetByDni(dni);
            if (existingDriver == null) return false;

            // Actualizar solo las propiedades proporcionadas
            if (!string.IsNullOrEmpty(driverDto.Name))
                existingDriver.Name = driverDto.Name;

            if (!string.IsNullOrEmpty(driverDto.LastName))
                existingDriver.LastName = driverDto.LastName;

            if (!string.IsNullOrEmpty(driverDto.Email))
                existingDriver.Email = driverDto.Email;

            if (!string.IsNullOrEmpty(driverDto.TruckPatent))
                existingDriver.TruckPatent = driverDto.TruckPatent;

            _truckDriverRepository.Update(existingDriver);
            return true;
        }
        public bool DeleteDriver(string dni)
        {
            var driver = _truckDriverRepository.GetByDni(dni);
            if (driver == null) return false;

            _truckDriverRepository.Delete(driver);
            return true;
        }
    }
}