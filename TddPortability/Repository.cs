using System.Threading.Tasks;

namespace TddPortability
{
    public class Repository : IRepository
    {
        private readonly PortabilityContext _context;

        public Repository(PortabilityContext context) => 
            _context = context;

        public async Task Store(Entry entry)
        {
            _context
                .Entries
                .Add(entry);
            await _context.SaveChangesAsync();
        }
    }
}