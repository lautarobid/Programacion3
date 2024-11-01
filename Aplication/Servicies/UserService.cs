using Domain.Entities;
using Domain.Interfaces;
using Aplication.Models.Request;
using Aplication.Models.Response;
using Aplication.Models.Mappings;

namespace Aplication.Servicies
{
    public class UserService : IUserService
    {
        private readonly IRepositoryBase<User> _userRepositoryBase;
        private readonly UserMapping _userMapping;

        public UserService(IRepositoryBase<User> userRepositoryBase, UserMapping userMapping)
        {
            _userRepositoryBase = userRepositoryBase;
            _userMapping = userMapping;
        }


        public async Task<UserResponse> CreateUserAsync(UserRequest userRequest)
        {
            var userEntity = _userMapping.MapToEntity(userRequest);
            var createdUser = await _userRepositoryBase.AddAsync(userEntity);
            return _userMapping.MapToResponse(createdUser);
        }


        public async Task<UserResponse> UpdateUserAsync(int userId, UserRequest userRequest)
        {
            var existingUser = await _userRepositoryBase.GetByIdAsync(userId);
            if (existingUser == null)
            {
                throw new Exception("Usuario no encontrado.");
            }

            _userMapping.UpdateEntityFromRequest(existingUser, userRequest);

            await _userRepositoryBase.UpdateAsync(existingUser);

            return _userMapping.MapToResponse(existingUser);
        }

    }
}
