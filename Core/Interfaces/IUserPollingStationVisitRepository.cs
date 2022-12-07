using Core.Entities;

namespace Core.Interfaces
{
    public interface IUserPollingStationVisitRepository
    {
        void Delete(int id);
        IQueryable<UserPollingStationVisit> Get();
        void Update(UserPollingStationVisit pollingStationVisit);
        List<UserPollingStationVisit> AddRange(List<UserPollingStationVisit> pollingStationVisits);
    }
}