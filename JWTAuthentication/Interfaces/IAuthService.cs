using JWTAuthentication.Models;

namespace JWTAuthentication.Interfaces
{
    public interface IAuthService
    {
        string Login(LoginRequest loginRequest);
        User AddUser(User user);

    }
}
