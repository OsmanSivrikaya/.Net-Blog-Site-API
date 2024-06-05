namespace MyBlogSite.Repository.UnitofWork
{
    public interface IUnitofwork : IDisposable
    {
        Task<bool> CommitAsync(bool state = true);
    }
}
