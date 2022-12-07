using Core.Entities;
using Core.Interfaces;
using Infrastructure.Repositorys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedComponents.Model;
using static Azure.Core.HttpHeader;
using System.Security.Cryptography.Xml;

namespace MauiApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UserPollingStationVisitController : ControllerBase
    {
        private IUserPollingStationVisitRepository _pollingStationVisitRepository;

        public UserPollingStationVisitController(IUserPollingStationVisitRepository pollingStationVisitRepository)
        {
            _pollingStationVisitRepository = pollingStationVisitRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var stations = new List<UserPollingStationVisitModel>();
            try
            {
                var entities = _pollingStationVisitRepository.Get();

                foreach (var entity in entities) 
                {
                    stations.Add(new UserPollingStationVisitModel()
                    {
                        Id = entity.Id,
                        DateOfVisit = entity.DateOfVisit,
                        DisabledAccess = entity.DisabledAccess,
                        Signature = entity.Signature,
                        Notes = entity.Notes,
                        PeopleOutsideInQueue = entity.PeopleOutsideInQueue,
                        PollingStationId = entity.PollingStationId,
                        UserId = entity.PollingStationId
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
        public IActionResult SyncUpdate(List<UserPollingStationVisitModel> updates)
        {
            if (updates.Any(x => x.Id == null)) 
            {
                throw new Exception("Failed to synchronize with the server, Update endpoint received update without an identifier.");
            }
            try
            {
                foreach (var update in updates) 
                {
                    //Id should never be null here
                    var stationVisit = _pollingStationVisitRepository.Get().Where(x => x.Id == update.Id).FirstOrDefault();

                    if (stationVisit != null) 
                    {
                        stationVisit.DateOfVisit = update.DateOfVisit;
                        stationVisit.DisabledAccess = update.DisabledAccess;
                        stationVisit.Signature = update.Signature;
                        stationVisit.Notes = update.Notes;
                        stationVisit.PeopleOutsideInQueue = update.PeopleOutsideInQueue;
                        stationVisit.PollingStationId = update.PollingStationId;
                        stationVisit.UserId = update.PollingStationId;

                        _pollingStationVisitRepository.Update(stationVisit);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Ok();
        }

        [HttpPost]
        public IActionResult SyncAdd(List<UserPollingStationVisitModel> additions)
        {
            var result = new List<UserPollingStationVisitModel>();
            try
            {
                var additionEntities = new List<UserPollingStationVisit>();

                foreach (var addition in additions) 
                {
                    //TODO: CREATE MAPPER FOR MORE EFFICIENT WAY OF MAPPING ENTITIES AND MODELS
                    additionEntities.Add(new UserPollingStationVisit() 
                    {
                        DateOfVisit = addition.DateOfVisit,
                        DisabledAccess = addition.DisabledAccess,
                        Signature = addition.Signature,
                        PollingStationId = addition.PollingStationId,
                        Notes = addition.Notes,
                        PeopleOutsideInQueue = addition.PeopleOutsideInQueue,
                        UserId = addition.UserId
                    });
                }

                additionEntities = _pollingStationVisitRepository.AddRange(additionEntities);

                //Map API Ids with app Ids and return
                additions.ForEach(x =>
                {
                    var entity = additionEntities.Where(x => x.MySqlId == x.MySqlId).FirstOrDefault();
                    x.Id = entity.Id;
                });

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Ok(additions);
        }
    }
}
