using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Repositorys
{
    public class UserPollingStationVisitRepository : IUserPollingStationVisitRepository
    {
        private readonly IMauiContext _context;
        public UserPollingStationVisitRepository(IMauiContext context)
        {
            _context = context;
        }

        public IQueryable<UserPollingStationVisit> Get()
        {
            return _context.UserPollingStationVisit;
        }

        public void Update(UserPollingStationVisit pollingStationVisit)
        {

        }

        public List<UserPollingStationVisit> AddRange(List<UserPollingStationVisit> pollingStationVisits)
        {
            _context.UserPollingStationVisit.AddRange(pollingStationVisits);

            return pollingStationVisits;
        }

        public void Delete(int id)
        {

        }
    }
}
