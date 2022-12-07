using Core.Entities;

namespace Core.Interfaces
{
    public interface IPollingStationRepository
    {
        void Delete(int id);
        IQueryable<PollingStation> Get();
        void Update(PollingStation pollingStation);
        void UpdateRange(List<PollingStation> pollingStations);
    }
}