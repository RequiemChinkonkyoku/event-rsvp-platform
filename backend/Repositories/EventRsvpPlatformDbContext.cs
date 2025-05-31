using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models.Entities;

namespace Repositories;

public class EventRsvpPlatformDbContext : DbContext
{
    public EventRsvpPlatformDbContext()
    {
        
    }

    public EventRsvpPlatformDbContext(DbContextOptions<EventRsvpPlatformDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        
        string connectionStringFile = environment == "Development" 
            ? "connectionstrings.Development.json" 
            : "connectionstrings.Production.json";
        
        if (!File.Exists(connectionStringFile))
        {
            throw new FileNotFoundException($"Missing connection string file: {connectionStringFile}");
        }
        
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile(connectionStringFile, true, true)
                .Build();
            var connectionString = configuration.GetConnectionString("EventRvspPlatformDb");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
    
    public virtual DbSet<Account> Accounts { get; set; }
    public virtual DbSet<Event> Events { get; set; }
    public virtual DbSet<Rsvp> Rvsps { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Rsvp>()
            .HasOne(x => x.Account)
            .WithMany(x => x.Rsvps)
            .HasForeignKey(x => x.AccountId)
            .OnDelete(DeleteBehavior.SetNull); // Keep RSVP, mark account as null
        
        modelBuilder.Entity<Rsvp>()
            .HasOne(x => x.Event)
            .WithMany(x => x.Rsvps)
            .HasForeignKey(x => x.EventId)
            .OnDelete(DeleteBehavior.Cascade); // Automatically delete all RSVPs when event is deleted
    }
}