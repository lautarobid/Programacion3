using Aplication.Models.Request;
using Aplication.Models.Response;

namespace Domain.Interfaces
{
    public interface IUserService
    {
        Task<UserResponse> CreateUserAsync(UserRequest userRequest);
        Task<UserResponse> UpdateUserAsync(int userId, UserRequest userRequest);
    }
}
