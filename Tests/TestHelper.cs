using RESTfull.Infrastructure.Data;
using RESTfull.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    public class TestHelper
    {
        private readonly Context _context;
        public TestHelper()
        {
            var builder = new DbContextOptionsBuilder<Context>();
            builder.UseInMemoryDatabase(databaseName: "test");

            var dbContextOptions = builder.Options;
            _context = new Context(dbContextOptions);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        public EmployeeRepository EmployeeRepository
        {
            get
            {
                return new EmployeeRepository(_context);
            }
        }
        public AudienceRepository AudienceRepository
        {
            get
            {
                return new AudienceRepository(_context);
            }
        }
    }
}
