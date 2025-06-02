using Models.Entities;
using Repositories.Interface;

namespace Repositories.Implement;

public class RsvpRepository : RepositoryBase<Rsvp>, IRsvpRepository
{
    public RsvpRepository(EventRsvpPlatformDbContext context) : base(context)
    {
    }
}