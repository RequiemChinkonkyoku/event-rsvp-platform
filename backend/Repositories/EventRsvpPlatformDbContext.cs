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
        if (!optionsBuilder.IsConfigured)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("EventRsvpPlatformDb");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
    
    public virtual DbSet<Account> Accounts { get; set; }
    public virtual DbSet<Event> Events { get; set; }
    public virtual DbSet<Rsvp> Rsvps { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Rsvp>()
            .HasOne(x => x.Account)
            .WithMany(x => x.Rsvps)
            .HasForeignKey(x => x.AccountId)
            .OnDelete(DeleteBehavior.Restrict); 
        
        modelBuilder.Entity<Rsvp>()
            .HasOne(x => x.Event)
            .WithMany(x => x.Rsvps)
            .HasForeignKey(x => x.EventId)
            .OnDelete(DeleteBehavior.Cascade); // Automatically delete all RSVPs when event is deleted
        
        modelBuilder.Entity<Event>()
            .HasOne(x => x.Account)
            .WithMany(x => x.Events)
            .HasForeignKey(x => x.AccountId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}