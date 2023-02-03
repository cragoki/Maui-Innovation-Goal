using SharedComponents.Model.Request;
using SharedComponents.Model.Response;

namespace MauiApp1.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseModel> Login(LoginRequestModel requestModel);
        void CheckExistingUser(LoginResponseModel model);
        void CheckToken(LoginResponseModel model);
        void ClearLocalData();
    }
}