namespace Solution.Domain.Repositories
{
    public interface IUnitOfWork
    {
        public Task Commit();
    }
}
