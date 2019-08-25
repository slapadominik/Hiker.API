using Microsoft.EntityFrameworkCore;

namespace Hiker.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}