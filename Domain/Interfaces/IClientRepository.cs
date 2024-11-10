using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public interface IClientRepository
    {
        // Obtiene un cliente por su ID
        Client? GetById(int clientId);

        // Obtiene todos los clientes
        IEnumerable<Client> GetAll();

        // Agrega un nuevo cliente
        void Add(Client client);

        // Actualiza un cliente existente
        void Update(Client client);

        // Elimina un cliente
        void Delete(Client client);

        // Obtiene los viajes de un cliente por su ID
        List<Trip> GetTripsByClientId(int clientId);

        // Obtiene las facturas de un cliente por su ID
        List<Bill> GetBillsByClientId(int clientId);
    }
}