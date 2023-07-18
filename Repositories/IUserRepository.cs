using TestProduct.Models;

namespace TestProduct.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<UserModel> GetUsers();
        void CreateUser(UserModel user);
    }
}
