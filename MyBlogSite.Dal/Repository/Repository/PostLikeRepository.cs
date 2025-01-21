using MyBlogSite.Dal.Entity;
using MyBlogSite.Dal.Repository.IRepository;

namespace MyBlogSite.Dal.Repository.Repository;

public class PostLikeRepository(ContextDb context) : Repository<PostLike>(context), IPostLikeRepository;