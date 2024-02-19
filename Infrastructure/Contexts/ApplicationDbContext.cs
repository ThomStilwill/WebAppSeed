using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Domain.Weather;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Forecast> Forecast { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = //Configuration.GetConnectionString("Default");
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=WebAppSeed;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            optionsBuilder.UseSqlServer(connectionString);
        }



        private IEnumerable<Forecast> SeedForecast() => new List<Forecast>()
            {
                new(){Id=1, Summary = WeatherSummary.Hot, TemperatureC = 40, Date = DateOnly.Parse("6/1/2023")},
                new(){Id=2, Summary = WeatherSummary.Warm, TemperatureC = 28, Date = DateOnly.Parse("10/31/2023")},
                new(){Id=3, Summary = WeatherSummary.Chilly, TemperatureC = 6, Date = DateOnly.Parse("1/9/2024")},
            };

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Forecast>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Summary)
                     .HasConversion<string>(c=>c.Key,c=> WeatherSummary.FromKey<WeatherSummary>(c))
                     .IsRequired();
            });

            modelBuilder.Entity<Forecast>().HasData(
                SeedForecast()
            );

        }
    };
}
