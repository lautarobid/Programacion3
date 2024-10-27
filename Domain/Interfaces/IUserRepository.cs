using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        User? Get(string name);
        List<User> Get();
        int AddUser(User user);
        bool DeleteUser(int id);  // Añade esta línea
                                  // Contrato para obtener un usuario por nombre
    }
}
