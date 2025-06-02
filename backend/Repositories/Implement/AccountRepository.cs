using Models.Entities;
using Repositories.Interface;

namespace Repositories.Implement;

public class AccountRepository : RepositoryBase<Account>, IAccountRepository
{
    public AccountRepository(EventRsvpPlatformDbContext context) : base(context)
    {
    }
}