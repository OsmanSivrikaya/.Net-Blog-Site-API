using MyBlogSite.Dal.Entity;
using MyBlogSite.Dal.Repository.IRepository;

namespace MyBlogSite.Dal.Repository.Repository;

public class NotificationRepository(ContextDb context) : Repository<Notification>(context), INotificationRepository;
