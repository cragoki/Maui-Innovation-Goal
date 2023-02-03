using SharedComponents.Model;

namespace MauiApp1.Clients.Interfaces
{
    public interface IPollingStationClient
    {
        Task<List<PollingStationModel>> GetStations();
    }
}