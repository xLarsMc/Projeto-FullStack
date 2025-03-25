namespace Solution.Domain.Repositories.User
{
    public interface IUserReadOnlyRepository
    {
        public Task<bool> UserExist(string email);
    }
}
