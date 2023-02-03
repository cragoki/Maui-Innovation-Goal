using SharedComponents.Model.Request;
using SharedComponents.Model.Response;
using System.Text.Json;
using System.Text;
using MauiApp1.Services.Interfaces;
using SharedComponents.Model;
using MauiApp1.Data.Repositories.Intefaces;
using MauiApp1.Data.Entities;
using MauiApp1.Clients.Interfaces;

namespace MauiApp1.Services
{
    public class AuthService : IAuthService
    {
        private IAuthClient _client;
        private ITokenRepository _tokenRepository;
        private IUserRepository _userRepository;

        public AuthService(ITokenRepository tokenRepository, IUserRepository userRepository, IAuthClient client)
        {
            _tokenRepository = tokenRepository;
            _userRepository = userRepository;
            _client = client;
        }

        public async Task<LoginResponseModel> Login(LoginRequestModel requestModel)
        {
            var result = new LoginResponseModel();

            try
            {
                result = await _client.LoginRequest(requestModel);
                CheckExistingUser(result);
                CheckToken(result);
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

        public void ClearLocalData() 
        {
            _userRepository.ClearLocalData();
        }
    }
}
