using MyBlogSite.Dal.Entity;
using MyBlogSite.Dal.Repository.IRepository;

namespace MyBlogSite.Dal.Repository.Repository;

public class PostFileRepository(ContextDb context) : Repository<PostFile>(context), IPostFileRepository;
