using Microsoft.EntityFrameworkCore;
using TestProduct.Models;

namespace TestProduct.DbContexts
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<UserModel> User { get; set; }
    }
}
