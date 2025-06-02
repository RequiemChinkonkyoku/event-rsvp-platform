using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Repositories;

public class EventRsvpPlatformDbContextFactory : IDesignTimeDbContextFactory<EventRsvpPlatformDbContext>
{
    public EventRsvpPlatformDbContext CreateDbContext(string[] args)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";

        var basePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "EventRsvpPlatform"));

        var config = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<EventRsvpPlatformDbContext>();
        var connectionString = config.GetConnectionString("EventRsvpPlatformDb");

        optionsBuilder.UseSqlServer(connectionString);

        return new EventRsvpPlatformDbContext(optionsBuilder.Options);
    }
}