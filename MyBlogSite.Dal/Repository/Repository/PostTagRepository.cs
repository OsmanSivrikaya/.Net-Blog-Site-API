using MyBlogSite.Dal.Entity;
using MyBlogSite.Dal.Repository.IRepository;

namespace MyBlogSite.Dal.Repository.Repository;

public class PostTagRepository(ContextDb context) : Repository<PostTag>(context), IPostTagRepository;