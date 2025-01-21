using MyBlogSite.Dal.Entity;
using MyBlogSite.Dal.Repository.IRepository;

namespace MyBlogSite.Dal.Repository.Repository;

public class PostRepository(ContextDb context) : Repository<Post>(context), IPostRepository;
