using Microsoft.EntityFrameworkCore;
using Solution.Domain.Entities;
using Solution.Domain.Repositories.User;

namespace Solution.Infrastructure.BancoContext.Repositories
{
    public class UserRepository: IUserReadOnlyRepository, IUserWriteOnlyRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public UserRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;
        public async Task Add(User user) => await _dbContext.Users.AddAsync(user);
        public async Task<bool> UserExist(string email)
        {
            return await _dbContext.Users.AnyAsync(user => user.Email.Equals(email) && user.isActive);
        }
    }
}
