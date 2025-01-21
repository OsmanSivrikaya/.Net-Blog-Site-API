using MyBlogSite.Dal.Entity;
using MyBlogSite.Dal.Repository.IRepository;

namespace MyBlogSite.Dal.Repository.Repository;

public class BlogRepository(ContextDb context) : Repository<Blog>(context), IBlogRepository;