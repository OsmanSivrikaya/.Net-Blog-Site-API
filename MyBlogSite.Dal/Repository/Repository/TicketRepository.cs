using MyBlogSite.Dal.Entity;
using MyBlogSite.Dal.Repository.IRepository;
using MyBlogSite.Data;

namespace MyBlogSite.Dal.Repository.Repository
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        public TicketRepository(ContextDb context) : base(context)
        {
        }
    }
}