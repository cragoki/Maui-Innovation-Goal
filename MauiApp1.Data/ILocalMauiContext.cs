using MauiApp1.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MauiApp1.Data
{
    public interface ILocalMauiContext
    {
        string DbPath { get; }
        DbSet<PollingStation> PollingStation { get; set; }
        DbSet<Token> Token { get; set; }
        DbSet<User> User { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}