﻿namespace MauiApp1.Data
{
    using MauiApp1.Data.Entities;
    using MauiApp1.Enums;
    using Microsoft.EntityFrameworkCore;
    using System;

    public class LocalMauiContext : DbContext, ILocalMauiContext
    {
        public DbSet<PollingStation> PollingStation { get; set; }
        public DbSet<Token> Token { get; set; }
        public DbSet<User> User { get; set; }

        public string DbPath { get; }

        public LocalMauiContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "mauiDb.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                    .Property(s => s.PermissionLevel)
                    .HasDefaultValue(UserPermissionLevel.regular)
                    .IsRequired();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(true, cancellationToken);
            return result;
        }
    }
}