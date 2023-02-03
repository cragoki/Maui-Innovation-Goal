using MauiApp1.Clients.Interfaces;
using SharedComponents.Model;
using System.Text.Json;

namespace MauiApp1.Clients
{
    public class PollingStationClient : IPollingStationClient
    {
        HttpClient _client;
        JsonSerializerOptions _serializerOptions;

        public PollingStationClient()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
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
                    RequestUri = uri,
                };

                HttpResponseMessage response = new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.OK
                };//Mocking this so I dont have to run the API

                //await _client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    //string content = await response.Content.ReadAsStringAsync();
                    //result = JsonSerializer.Deserialize<List<PollingStationModel>>(content, _serializerOptions);
                    result = new List<PollingStationModel>()
                    {
                        new PollingStationModel()
                        {
                            Id = 1,
                            Name = "ALDI",
                            AddressLine1 = "Dalston Rd",
                            AddressLine2 = "Carlisle",
                            PostCode = "CA2 5NP",
                            IsOpen = false,
                            Lat = 54.89084059407141,
                            Lng = -2.9474876212618604
                        },
                        new PollingStationModel()
                        {
                            Id = 2,
                            Name = "Greggs",
                            AddressLine1 = "131, 133 Denton St",
                            AddressLine2 = "Carlisle",
                            PostCode = "CA2 5EN",
                            IsOpen = false,
                            Lat = 54.887039362019635,
                            Lng = -2.9402778435305073
                        },
                        new PollingStationModel()
                        {
                            Id = 3,
                            Name = "McDonald's",
                            AddressLine1 = "Kingstown",
                            AddressLine2 = "Grearshill Rd",
                            AddressLine3 = "Carlisle",
                            PostCode = "CA3 0ET",
                            IsOpen = false,
                            Lat = 54.92715769008813,
                            Lng = -2.947976488792807
                        }
                    };
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
