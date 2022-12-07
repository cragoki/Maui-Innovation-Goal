using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Interfaces
{
    public interface IMauiContext
    {
        DbSet<User> User { get; set; }
        DbSet<PollingStation> PollingStation { get; set; }
        DbSet<UserPollingStationVisit> UserPollingStationVisit { get; set; }
        DbSet<PollingStationPhoto> PollingStationPhoto { get; set; }
    }
}