using Aplication.Models.Request;
using Aplication.Models.Response;
using Domain.Entities;

namespace Aplication.Models.Mappings
{
    public class UserMapping
    {
        // Método para mapear de UserRequest a User (DTO a Entidad)
        public User MapToEntity(UserRequest request)
        {
            return new User
            {
                Name = request.Name,
                LastName = request.LastName,
                Email = request.Email,
                Dni = request.Dni,
                Password = request.Password,
                Role = request.Role
            };
        }

        // Método para mapear de User a UserResponse (Entidad a DTO)
        public UserResponse MapToResponse(User user)
        {
            return new UserResponse
            {
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Dni = user.Dni,
                Role = user.Role.ToString() // Convertir el enum Role a string
            };
        }
        public User UpdateEntityFromRequest(User existingUser, UserRequest request)
        {
            existingUser.Name = request.Name ?? existingUser.Name;
            existingUser.LastName = request.LastName ?? existingUser.LastName;
            existingUser.Email = request.Email ?? existingUser.Email;
            existingUser.Dni = request.Dni ?? existingUser.Dni;
            existingUser.Password = request.Password ?? existingUser.Password;
            existingUser.Role = request.Role != null ? request.Role : existingUser.Role;

            return existingUser;
        }
    }
}
