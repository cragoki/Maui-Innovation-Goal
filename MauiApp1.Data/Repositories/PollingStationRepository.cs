using MauiApp1.Data.Entities;
using MauiApp1.Data.Repositories.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace MauiApp1.Data.Repositories
{
    public class PollingStationRepository : IPollingStationRepository
    {
        private ILocalMauiContext _context;
        public PollingStationRepository(ILocalMauiContext context) 
        {
            _context = context;
        }
        public void Add(PollingStation station)
        {
            int result = 0;
            try
            {
                _context.PollingStation.Add(station);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(PollingStation station)
        {
            try
            {
                _context.PollingStation.Remove(station);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<PollingStation> Get()
        {
            try
            {
                return _context.PollingStation.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public PollingStation Update(PollingStation station)
        {
            var result = new PollingStation();
            try
            {
                var entity = _context.PollingStation.Where(x => x.Id == station.Id).FirstOrDefault();

                if (entity == null)
                {
                    throw new Exception("Polling Station could not be found");
                }
                else
                {
                    station.Synced = false;
                    entity = station;
                }

                _context.PollingStation.Update(entity);
                result = entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
