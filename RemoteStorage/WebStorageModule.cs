using System.Threading.Tasks;
using Nancy;

namespace RemoteStorage
{
    public sealed class WebStorageModule : NancyModule
    {
        private readonly IStorage _storage;

        public WebStorageModule(IStorage storage)
        {
            _storage = storage;

            Get("/{key}", async x => await GetValueAsync(x.key));
            Post("/{key}", async x => await UpdateValueAsync(x.key, Request.Form.value.Value));
            Delete("/{key}", async x => await DeleteValueAsync(x.key));
        }

        private async Task<object> GetValueAsync(string key)
        {
            var result = await _storage.GetAsync(key);

            if (result == null)
            {
                return HttpStatusCode.NoContent;
            }

            return result;
        }

        private async Task<object> UpdateValueAsync(string key, object value)
        {
            return await _storage.UpdateAsync(key, value)
                ? HttpStatusCode.OK
                : HttpStatusCode.BadRequest;
        }

        private async Task<object> DeleteValueAsync(string key)
        {
            return await _storage.DeleteAsync(key)
                ? HttpStatusCode.OK
                : HttpStatusCode.BadRequest;
        }
    }
}