using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
        public interface ITruckDriverRepository
        {
            IEnumerable<TruckDriver> GetAll();
            TruckDriver GetByDni(string dni);
            void Add(TruckDriver truckDriver);
            void Update(TruckDriver truckDriver);
            void Delete(TruckDriver truckDriver);
        }
    }