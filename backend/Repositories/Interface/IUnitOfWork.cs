namespace Repositories.Interface;

public interface IUnitOfWork : IDisposable
{
    IAccountRepository Accounts { get; }
    
    IEventRepository Events { get; }
    
    IRsvpRepository Rsvps { get; }
    
    Task SaveChangesAsync();
}