using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Repositorys
{
    public class PollingStationRepository : IPollingStationRepository
    {
        private readonly IMauiContext _context;
        public PollingStationRepository(IMauiContext context)
        {
            _context = context;
        }

        public IQueryable<PollingStation> Get()
        {
            return _context.PollingStation;
        }

        public void Update(PollingStation pollingStation)
        {

        }

        public void UpdateRange(List<PollingStation> pollingStations)
        {

        }

        public void Delete(int id)
        {

        }
    }
}
