using Microsoft.EntityFrameworkCore;
using WebApplicationEugeneM.DAL.Entities;

namespace WebApplicationEugeneM.DAL.EF
{
    public class UsersContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;
        public UsersContext(DbContextOptions<UsersContext> options)
            : base(options)
        {
            Database.EnsureCreated(); // создаем базу данных при первом обращении
        }
    }
}
