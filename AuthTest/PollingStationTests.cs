using FluentAssertions;
using MauiApp1.Clients.Interfaces;
using MauiApp1.Repositories.Interfaces;
using MauiApp1.Services;
using MauiApp1.Services.Interfaces;
using Moq;
using SharedComponents.Model;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static SQLite.SQLite3;

namespace UnitTests
{
    public class PollingStationTests
    {
        [Fact]
        public async void ShouldConcatinateAddressesFromClientResponseAllPopulated()
        {
            Mock<IPollingStationRepository> pollingStationRepoMock = new Mock<IPollingStationRepository>();
            Mock<IPollingStationClient> pollingStationClientMock = new Mock<IPollingStationClient>();


            pollingStationClientMock.Setup(x => x.GetStations()).ReturnsAsync(new List<PollingStationModel>()
            {
                        new PollingStationModel()
                        {
                            Id = 1,
                            Name = "ALDI",
                            AddressLine1 = "Dalston Rd",
                            AddressLine2 = "Carlisle",
                            AddressLine3 = "Line3",
                            AddressLine4 = "Line4",
                            PostCode = "CA2 5NP",
                            IsOpen = false,
                            Lat = 54.89084059407141,
                            Lng = -2.9474876212618604
                        }
            });


            var pollingStationService = InstantiatePollingStationService(pollingStationRepoMock.Object, pollingStationClientMock.Object);

            var result = await pollingStationService.GetStationModel();

            result.FirstOrDefault().Address.Should().Be("Dalston Rd, Carlisle, Line3, Line4, CA2 5NP");
        }

        [Fact]
        public async void ShouldConcatinateAddressesFromClientResponseSomePopulated()
        {
            Mock<IPollingStationRepository> pollingStationRepoMock = new Mock<IPollingStationRepository>();
            Mock<IPollingStationClient> pollingStationClientMock = new Mock<IPollingStationClient>();


            pollingStationClientMock.Setup(x => x.GetStations()).ReturnsAsync(new List<PollingStationModel>()
            {
                        new PollingStationModel()
                        {
                            Id = 1,
                            Name = "ALDI",
                            AddressLine1 = "Dalston Rd",
                            AddressLine2 = "Carlisle",
                            PostCode = "CA2 5NP",
                            IsOpen = false,
                            Lat = 54.89084059407141,
                            Lng = -2.9474876212618604
                        }
            });


            var pollingStationService = InstantiatePollingStationService(pollingStationRepoMock.Object, pollingStationClientMock.Object);

            var result = await pollingStationService.GetStationModel();

            result.FirstOrDefault().Address.Should().Be("Dalston Rd, Carlisle, CA2 5NP");
        }


        private IPollingStationService InstantiatePollingStationService(IPollingStationRepository pollingStationRepo, IPollingStationClient pollingStationClient)
        {
            return new PollingStationService(pollingStationRepo, pollingStationClient);
        }
    }
}