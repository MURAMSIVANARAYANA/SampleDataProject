using SampleDataProject.Models;
using System.Threading.Tasks;

namespace SampleDataProject.Services
{
    public interface IDataStore
    {            
        Task<Datum> GetItemAsync(string id);
        Task<Item>GetItemsAsync(bool forceRefresh = false);
    }
}
