using SharedComponents.Model.Request;
using SharedComponents.Model.Response;
using System.Text.Json;
using System.Text;
using MauiApp1.Services.Interfaces;
using MauiApp1.Repositories.Interfaces;
using MauiApp1.Entities;
using SharedComponents.Model;

namespace MauiApp1.Services
{
    public class AuthService : IAuthService
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;
        private ITokenRepository _tokenRepository;
        private IUserRepository _userRepository;

        public AuthService(ITokenRepository tokenRepository, IUserRepository userRepository)
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            _tokenRepository = tokenRepository;
            _userRepository = userRepository;
        }

        public async Task<LoginResponseModel> Login(LoginRequestModel requestModel)
        {
            var result = new LoginResponseModel();
            Uri uri = new Uri(string.Format(Constants.Constants.ApiUrl + "Auth/Login"));

            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = uri,
                    Content = new StringContent(JsonSerializer.Serialize(requestModel), Encoding.UTF8),
                };

                HttpResponseMessage response = new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.OK
                };//Mocking this so I dont have to run the API

                    //await _client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    //string content = await response.Content.ReadAsStringAsync();
                    //result = JsonSerializer.Deserialize<LoginResponseModel>(content, _serializerOptions);
                    result = new LoginResponseModel()
                    {
                        Token = new TokenModel() 
                        {
                            UserId = 1,
                            AuthToken = "testToken",
                            RefreshToken = "testRefreshToken",
                            TokenExpiry = DateTime.Now.AddHours(1)
                        },
                        User = new UserModel() 
                        {
                            Id = 1,
                            Email = "TestEmail",
                            FirstName = "Test",
                            LastName = "Test",
                            PermissionLevel = Enums.UserPermissionLevel.admin
                        }
                    };

                    CheckExistingUser(result);
                    CheckToken(result);
                }
                else
                {
                    throw new Exception("Invalid Username or Password");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public void CheckExistingUser(LoginResponseModel model) 
        {
            //Check if user exists in local db if not add.
            var user = _userRepository.Get().Where(x => x.Id == model.User.Id).FirstOrDefault();

            if (user == null)
            {
                _userRepository.Add(new User()
                {
                    Id = model.User.Id,
                    Email = model.User.Email,
                    FirstName = model.User.FirstName,
                    LastName = model.User.LastName,
                    PermissionLevel = model.User.PermissionLevel
                });
            }
        }
        public void CheckToken(LoginResponseModel model)
        {
            var token = _tokenRepository.Get().Where(x => x.UserId == model.User.Id).FirstOrDefault();

            if (token != null) 
            {
                _tokenRepository.Delete(token);
            }

            _tokenRepository.Add(new Token() 
            {
                UserId = model.User.Id,
                AuthToken = model.Token.AuthToken,
                RefreshToken = model.Token.RefreshToken,
                TokenExpiry = model.Token.TokenExpiry
            });
        }
    }
}
