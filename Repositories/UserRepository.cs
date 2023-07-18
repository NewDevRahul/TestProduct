using TestProduct.DbContexts;
using TestProduct.Models;

namespace TestProduct.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _dbContext;
        public UserRepository(MyDbContext dbContext) 
        { 
            _dbContext = dbContext;
        }

        public IEnumerable<UserModel> GetUsers()
        {
            return _dbContext.User.ToList();
        }

        public void CreateUser(UserModel user)
        {
            _dbContext.User.Add(user);
            _dbContext.SaveChanges();
        }
    }
}
