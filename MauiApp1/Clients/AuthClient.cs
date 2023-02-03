using MauiApp1.Clients.Interfaces;
using SharedComponents.Model.Request;
using SharedComponents.Model.Response;
using System.Net;
using System.Text;
using System.Text.Json;

namespace MauiApp1.Clients
{
    public class AuthClient : IAuthClient
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        public AuthClient()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<LoginResponseModel> LoginRequest(LoginRequestModel requestModel)
        {
            var result = new LoginResponseModel();
            try
            {
                Uri uri = new Uri(string.Format(Constants.Constants.ApiUrl + "Auth/Login"));   

                var response = await _client.PostAsync(uri, new StringContent(JsonSerializer.Serialize(requestModel), Encoding.UTF8));

                if (!response.IsSuccessStatusCode) 
                {
                    throw new Exception("Invalid Username or Password");
                }

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    result = JsonSerializer.Deserialize<LoginResponseModel>(content, _serializerOptions);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
