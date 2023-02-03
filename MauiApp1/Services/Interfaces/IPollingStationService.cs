namespace MauiApp1.Services.Interfaces
{
    public interface IPollingStationService
    {
        Task<List<Models.PollingStation.PollingStationModel>> GetStationModel();
    }
}