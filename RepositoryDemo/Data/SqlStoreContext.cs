using Microsoft.EntityFrameworkCore;
using RepositoryDemo.Models;

namespace RepositoryDemo.Data
{
    public class SqlStoreContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Game> Games { get; set; }

        public SqlStoreContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=RepositoryDemo;Trusted_Connection=True;");
        }
    }
}
