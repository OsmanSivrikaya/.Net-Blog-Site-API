using MyBlogSite.Dal.Entity;
using MyBlogSite.Dal.Repository.IRepository;

namespace MyBlogSite.Dal.Repository.Repository;

public class PostCommentRepository(ContextDb context) : Repository<PostComment>(context), IPostCommentRepository;