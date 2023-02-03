using MauiApp1.Data.Entities;

namespace MauiApp1.Data.Repositories.Intefaces
{
    public interface IPollingStationRepository
    {
        void Add(PollingStation station);
        void Delete(PollingStation station);
        List<PollingStation> Get();
        PollingStation Update(PollingStation station);
    }
}