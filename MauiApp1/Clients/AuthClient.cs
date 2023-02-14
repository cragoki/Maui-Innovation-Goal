using MauiApp1.Clients.Interfaces;
using Newtonsoft.Json;
using SharedComponents.Model.Request;
using SharedComponents.Model.Response;
using System.Net.Http.Headers;
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
                WriteIndented = true
            };
        }

        public async Task<LoginResponseModel> LoginRequest(LoginRequestModel requestModel)
        {
            var result = new LoginResponseModel();
            try
            {
                Uri uri = new Uri(string.Format(Constants.Constants.ApiUrl + "Auth/Login"));


                var request = new HttpRequestMessage(HttpMethod.Post, uri);
                var content = JsonConvert.SerializeObject(requestModel);
                var buffer = Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                request.Content = byteContent;
                var response = await _client.SendAsync(request);

                if (!response.IsSuccessStatusCode) 
                {
                    throw new Exception("Invalid Username or Password");
                }

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    result =  JsonConvert.DeserializeObject<LoginResponseModel>(jsonContent);
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
