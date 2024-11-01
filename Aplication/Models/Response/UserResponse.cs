using Domain.Enum;

namespace Aplication.Models.Response
{
    public class UserResponse
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Dni { get; set; }
        public string Role { get; set; }
    }
}
