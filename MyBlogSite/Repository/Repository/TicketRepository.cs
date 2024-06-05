using MyBlogSite.Context;
using MyBlogSite.Entity;
using MyBlogSite.Repository.IRepository;

namespace MyBlogSite.Repository.Repository
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        public TicketRepository(ContextDb context) : base(context)
        {
        }
    }
}