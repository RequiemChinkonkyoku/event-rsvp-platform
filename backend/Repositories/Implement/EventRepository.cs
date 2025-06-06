using Models.Entities;
using Repositories.Interface;

namespace Repositories.Implement;

public class EventRepository : RepositoryBase<Event>, IEventRepository
{
    public EventRepository(EventRsvpPlatformDbContext context) : base(context)
    {
    }
}