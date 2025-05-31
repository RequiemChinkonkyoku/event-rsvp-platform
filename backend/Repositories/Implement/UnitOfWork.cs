using Repositories.Interface;

namespace Repositories.Implement;

public class UnitOfWork : IUnitOfWork
{
    private readonly EventRsvpPlatformDbContext _dbContext;
    
    public IAccountRepository Accounts { get; }
    
    public IEventRepository Events { get; }
    
    public IRsvpRepository Rsvps { get; }

    public UnitOfWork(IAccountRepository accounts, IEventRepository events, IRsvpRepository rsvps)
    {
        _dbContext = new EventRsvpPlatformDbContext();
        
        Accounts = accounts;
        Events = events;
        Rsvps = rsvps;
    }
    
    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            _dbContext.Dispose();
        }
    }
}