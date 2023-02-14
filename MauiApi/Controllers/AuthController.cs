using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SharedComponents.Model;
using SharedComponents.Model.Request;
using SharedComponents.Model.Response;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MauiApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private static IConfiguration _configuration;
        private static IUserRepository _userRepository;
        public AuthController(IConfiguration config, IUserRepository userRepository)
        {
            _configuration = config;
            _userRepository = userRepository;
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginRequestModel request)
        {
            try
            {
                if (request != null && request.Email != null && request.Password != null)
                {
                    var userData = _userRepository.Get().Where(x => x.Email == request.Email && x.Password == request.Password).FirstOrDefault();

                    if (userData != null)
                    {
                        //create claims details based on the user information
                        var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", userData.Id.ToString()),
                        new Claim("Email", userData.Email),
                    };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            _configuration["Jwt:Issuer"],
                            _configuration["Jwt:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddMinutes(10),
                            signingCredentials: signIn);

                        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                        return Ok(new LoginResponseModel() 
                        {
                            Token = new TokenModel() 
                            {
                                AuthToken = tokenString,
                                RefreshToken = "",
                                TokenExpiry = token.ValidTo,
                                UserId = userData.Id
                            },
                            User = new UserModel() 
                            {
                                Email = userData.Email,
                                FirstName = userData.FirstName,
                                LastName = userData.LastName,
                                PermissionLevel = userData.PermissionLevel
                            }
                        });
                    }
                    else
                    {
                        return BadRequest("Invalid Credentials");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return BadRequest();
        }
    }
}
