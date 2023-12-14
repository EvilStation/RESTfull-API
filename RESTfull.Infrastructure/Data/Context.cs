using Microsoft.EntityFrameworkCore;
using RESTfull.Domain.Model;

namespace RESTfull.Infrastructure.Data
{
    public class Context : DbContext
    {
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Audience> Audiences { get; set; } = null!;
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}