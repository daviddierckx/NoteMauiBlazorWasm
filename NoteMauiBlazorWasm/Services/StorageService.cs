using NoteMauiBlazorWasm.Common.Interfaces;

namespace NoteMauiBlazorWasm.Services
{
    public class StorageService : IStorageService
    {
        private readonly ISecureStorage _storage;
        public StorageService()
        {
            _storage = SecureStorage.Default;
        }
        public async Task<string?> GetAsync(string key) => await _storage.GetAsync(key);
       

        public async Task SaveAsync(string key, string value) => await _storage.SetAsync(key, value);
        
    }
}
