using System.Threading.Tasks;

namespace RemoteStorage
{
    public interface IStorage
    {
        Task<string> GetAsync(string key);
        Task<bool> UpdateAsync(string key, object value);
        Task<bool> DeleteAsync(string key);
    }
}