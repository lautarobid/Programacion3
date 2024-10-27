using Aplication.Dtos;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Aplication.Servicies
{
    public class UserService
    {
        // Inyectamos IUserRepository
        private readonly IUserRepository _userRepository;

        // Constructor para la inyección de dependencias
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // Usamos el repositorio para obtener el usuario por nombre
        public User? Get(string name)
        {
            return _userRepository.Get(name); // Obtener el usuario desde el repositorio
        }
        public List<User> Get()
        {
            return _userRepository.Get();
        }
        // Agregar un nuevo usuario
        public int AddUser(UserForAddRequest request)
        {
            // Creamos una nueva instancia de User con los datos del DTO
            var user = new User
            {
                Name = request.Name,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password
            };

            // Llamamos al repositorio para agregar el nuevo usuario
            return _userRepository.AddUser(user);
        }

        public bool DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id);
        }

        public UserModel? CheckCredentials(CredentialsRequest credentials)
        {
            User? user = Get(credentials.UserName);

            // Verificación de nulidad
            if (user != null && user.Password == credentials.Password)
            {
                return new UserModel()
                {
                    UserName = user.Name,      // Inicializar UserName aquí
                    Password = user.Password,   // Inicializar Password aquí
                    Email = user.Email,
                    Id = user.Id,
                    Name = user.Name,
                };
            }
            return null;
        }
    }

 }


