using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedComponents.Model;

namespace MauiApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class PollingStationController : ControllerBase
    {
        private IPollingStationRepository _pollingStationRepository;

        public PollingStationController(IPollingStationRepository pollingStationRepository)
        {
            _pollingStationRepository = pollingStationRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var stations = new List<PollingStationModel>();
            try
            {
                var entities = _pollingStationRepository.Get();

                foreach (var entity in entities) 
                {
                    stations.Add(new PollingStationModel()
                    {
                        Id = entity.Id,
                        AddressLine1 = entity.AddressLine1,
                        AddressLine2 = entity.AddressLine2,
                        AddressLine3 = entity.AddressLine3,
                        AddressLine4 = entity.AddressLine4,
                        IsOpen = entity.IsOpen,
                        Lat = entity.Lat,
                        Lng = entity.Lng,
                        Name = entity.Name,
                        PostCode = entity.PostCode
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Ok(stations);
        }

        [HttpPut]
        public IActionResult Sync(List<PollingStationModel> updates)
        {
            try
            {
                foreach (var update in updates) 
                {
                    var station = _pollingStationRepository.Get().Where(x => x.Id == update.Id).FirstOrDefault();

                    if (station != null) 
                    {
                        station.IsOpen = update.IsOpen;
                        _pollingStationRepository.Update(station);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Ok();
        }
    }
}
