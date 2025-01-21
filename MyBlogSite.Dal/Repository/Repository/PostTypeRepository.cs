using MyBlogSite.Dal.Entity;
using MyBlogSite.Dal.Repository.IRepository;

namespace MyBlogSite.Dal.Repository.Repository;

public class PostTypeRepository(ContextDb context) : Repository<PostType>(context), IPostTypeRepository;