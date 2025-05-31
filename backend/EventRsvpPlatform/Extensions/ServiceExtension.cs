using Repositories.Implement;
using Repositories.Interface;
using Services.Implement;
using Services.Interface;

namespace EventRsvpPlatform.Extensions;

public static class ServiceExtension
{
    public static IServiceCollection AddServiceExtension(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IEventRepository, EventRepository>();
        services.AddScoped<IRsvpRepository, RsvpRepository>();
        
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IEventService, EventService>();
        services.AddScoped<IRsvpService, RsvpService>();
        
        return services;
    }
}