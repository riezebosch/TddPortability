using Microsoft.EntityFrameworkCore;

namespace TddPortability
{
    public class PortabilityContext : DbContext
    {
        public PortabilityContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Entry> Entries { get; set; }
    }
}