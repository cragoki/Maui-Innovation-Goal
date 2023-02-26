using MauiApp1.Clients.Interfaces;
using MauiApp1.Data.Repositories.Intefaces;
using SharedComponents.Model;
using System.Text.Json;

namespace MauiApp1.Clients
{
    public class PollingStationClient : IPollingStationClient
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;
        private ITokenRepository _tokenRepository;
        private IUserRepository _userRepository;

        public PollingStationClient(ITokenRepository tokenRepository, IUserRepository userRepository)
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

        public async Task<List<PollingStationModel>> GetStations()
        {
            var result = new List<PollingStationModel>();
            Uri uri = new Uri(string.Format(Constants.Constants.ApiUrl + "PollingStation"));

            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = uri
                };

                //Need to implement a Base Client to register this
                var user = _userRepository.Get().Where(x => x.IsActiveUser).FirstOrDefault();
                var token = _tokenRepository.Get().Where(x => x.Id == user.Id).FirstOrDefault();

                _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.AuthToken);

                var response = await _client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    result = JsonSerializer.Deserialize<List<PollingStationModel>>(content, _serializerOptions);
                }
                else
                {
                    throw new Exception("Something went wrong when trying to retrieve the polling station details");
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
