using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TruckDriverRepository : ITruckDriverRepository
    {
        private readonly ApplicationDBContext _context;

        public TruckDriverRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        // Obtener todos los conductores
        public IEnumerable<TruckDriver> GetAll()
        {
            return _context.TruckDrivers.ToList();
        }

        // Obtener un conductor por DNI
        public TruckDriver GetByDni(string dni)
        {
            var driver = _context.TruckDrivers.SingleOrDefault(td => td.Dni == dni);
            if (driver == null)
                throw new KeyNotFoundException($"No se encontró un conductor con el DNI {dni}");

            return driver;
        }

        // Agregar un nuevo conductor
        public void Add(TruckDriver truckDriver)
        {
            _context.TruckDrivers.Add(truckDriver);
            _context.SaveChanges();
        }

        // Actualizar los datos de un conductor
        public void Update(TruckDriver truckDriver)
        {
            _context.TruckDrivers.Update(truckDriver);
            _context.SaveChanges();
        }

        // Eliminar un conductor
        public void Delete(TruckDriver truckDriver)
        {
            _context.TruckDrivers.Remove(truckDriver);
            _context.SaveChanges();
        }
    }
}