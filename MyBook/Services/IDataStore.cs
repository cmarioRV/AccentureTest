using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBook
{
    public interface IDataStore<T>
    {
        Task<IEnumerable<T>> GetItemsAsync(string query);
    }
}
