using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Infrastructure.Data
{
    public class MauiContext : DbContext, IMauiContext
    {
        protected readonly IConfiguration configuration;

        public DbSet<User> User { get; set; }
        public DbSet<PollingStation> PollingStation { get; set; }
        public DbSet<UserPollingStationVisit> UserPollingStationVisit { get; set; }
        public DbSet<PollingStationPhoto> PollingStationPhoto { get; set; }
        public MauiContext(DbContextOptions<MauiContext> options) : base(options) { }
    }
}
