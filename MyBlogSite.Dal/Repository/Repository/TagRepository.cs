using MyBlogSite.Dal.Entity;
using MyBlogSite.Dal.Repository.IRepository;

namespace MyBlogSite.Dal.Repository.Repository;

public class TagRepository(ContextDb context) : Repository<Tag>(context), ITagRepository;