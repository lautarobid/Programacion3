using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IClientRepository
    {
        // Obtener un cliente por su ID
        Client GetById(string idClient);

        // Obtener todos los clientes
        IEnumerable<Client> GetAll();

        // Agregar un nuevo cliente
        void Add(Client client);

        // Actualizar un cliente existente
        void Update(Client client);

        // Eliminar un cliente
        void Delete(Client client);
    }
}