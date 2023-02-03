using MauiApp1.Clients.Interfaces;
using MauiApp1.Data.Entities;
using MauiApp1.Data.Repositories.Intefaces;
using MauiApp1.Services.Interfaces;

namespace MauiApp1.Services
{
    public class PollingStationService : IPollingStationService
    {
        private IPollingStationRepository _pollingStationRepository;
        private IPollingStationClient _pollingStationClient;

        public PollingStationService(IPollingStationRepository pollingStationRepository, IPollingStationClient pollingStationClient)
        {
            _pollingStationRepository = pollingStationRepository;
            _pollingStationClient = pollingStationClient;
        }

        public async Task<List<MauiApp1.Models.PollingStation.PollingStationModel>> GetStationModel()
        {
            var result = new List<MauiApp1.Models.PollingStation.PollingStationModel>();

            try
            {
                //Check if we have internet to get from server or not
                var stations = await _pollingStationClient.GetStations();

                foreach (var station in stations)
                {
                    result.Add(new Models.PollingStation.PollingStationModel()
                    {
                        Id = station.Id,
                        Address = string.Concat(station.AddressLine1, ", ", String.IsNullOrEmpty(station.AddressLine2) ? "" : station.AddressLine2 + ", ", String.IsNullOrEmpty(station.AddressLine3) ? "" : station.AddressLine3 + ", ", String.IsNullOrEmpty(station.AddressLine4) ? "" : station.AddressLine4 + ", ", String.IsNullOrEmpty(station.PostCode) ? "" : station.PostCode),
                        JourneyDistanceMiles = 0,
                        Name = station.Name,
                        TravelTime = "",
                        LastVisitTime = station.LastVisit,
                        VisitCount = station.VisitCount,
                    });


                    _pollingStationRepository.Add(new PollingStation()
                    {
                        Id = station.Id,
                        Name = station.Name,
                        AddressLine1 = station.AddressLine1,
                        AddressLine2 = station.AddressLine2,
                        AddressLine3 = station.AddressLine3,
                        AddressLine4 = station.AddressLine4,
                        PostCode = station.PostCode,
                        IsOpen = station.IsOpen,
                        LastVisit = station.LastVisit,
                        Lat = station.Lat,
                        Lng = station.Lng,
                        Synced = true
                    });
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
