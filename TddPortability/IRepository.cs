using System.Threading.Tasks;

namespace TddPortability
{
    public interface IRepository
    {
        Task Store(Entry entry);
    }
}