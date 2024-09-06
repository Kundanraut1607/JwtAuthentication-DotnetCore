using JWTAuthentication.Interfaces;
using JWTAuthentication.Models;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
             _authService = authService;
        }

        [HttpPost("AddUser")]
        public User AddUser(User user)
        {
            return _authService.AddUser(user);
        }

        [HttpPost("Login")]
        public string Login(LoginRequest loginRequest)
        {
            return _authService.Login(loginRequest);
        }
    }
}
