using SharedComponents.Model.Request;
using SharedComponents.Model.Response;

namespace MauiApp1.Clients.Interfaces
{
    public interface IAuthClient
    {
        Task<LoginResponseModel> LoginRequest(LoginRequestModel requestModel);
    }
}