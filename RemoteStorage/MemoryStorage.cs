using System.Collections.Generic;
using System.Threading.Tasks;

namespace RemoteStorage
{
    public class MemoryStorage : IStorage
    {
        private readonly Dictionary<string, string> _dictionary;

        public MemoryStorage()
        {
            _dictionary = new Dictionary<string, string>();
        }

        public Task<string> GetAsync(string key)
        {
            if (_dictionary.TryGetValue(key, out var value))
            {
                return Task.FromResult(value);
            }

            return Task.FromResult<string>(null);
        }

        public Task<bool> UpdateAsync(string key, object value)
        {
            if (!(value is string) || string.IsNullOrWhiteSpace((string) value))
            {
                return Task.FromResult(false);
            }

            _dictionary[key] = (string) value;

            return Task.FromResult(true);
        }

        public Task<bool> DeleteAsync(string key)
        {
            if (!_dictionary.ContainsKey(key))
            {
                return Task.FromResult(false);
            }

            _dictionary.Remove(key);

            return Task.FromResult(true);
        }
    }
}