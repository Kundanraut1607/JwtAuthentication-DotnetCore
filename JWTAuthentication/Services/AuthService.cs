using JWTAuthentication.Context;
using JWTAuthentication.Interfaces;
using JWTAuthentication.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTAuthentication.Services
{
    public class AuthService : IAuthService
    {
        private readonly JwtDBContext _dbContext;
        private readonly IConfiguration _configuration;
        public AuthService(JwtDBContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }
        public User AddUser(User user)
        {
            var addUser = _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return addUser.Entity;
        }

        public string Login(LoginRequest loginRequest)
        {
            if (loginRequest.UserName != null && loginRequest.Password != null)
            { 
                 var user = _dbContext.Users.Where( x => x.Email == loginRequest.UserName && x.Password == loginRequest.Password).FirstOrDefault();
                if (user != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim("Id", user.Id.ToString()),
                        new Claim("UserName", user.Name),
                        new Claim("Email",user.Email)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                                        _configuration["Jwt:Issuer"],
                                        _configuration["Jwt:Audience"],
                                        claims,
                                        expires: DateTime.UtcNow.AddMinutes(10),
                                        signingCredentials: signIn
                                    );

                    var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                    return jwtToken;
                }
                else
                {
                    throw new Exception("User is not valid");
                }

            }
            else
            {
                throw new Exception("Credentials are not valid");
            }
        }
    }
}
