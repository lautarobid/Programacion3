using Aplication.Models.Request;

namespace Aplication.Interfaces
{
    public interface ICustomAuthenticationService
    {
        Task<string> AutenticarAsync(AuthenticationRequest authenticationRequest);
    }
}
