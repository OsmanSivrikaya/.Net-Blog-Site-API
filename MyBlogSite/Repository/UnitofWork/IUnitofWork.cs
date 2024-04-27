namespace MyBlogSite.Repository.UnitofWork
{
    public interface IUnitofwork : IDisposable
    {
        bool Commit(bool state = true);
    }
}
