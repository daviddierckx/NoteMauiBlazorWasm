namespace NoteMauiBlazorWasm.Common.Interfaces
{
    public interface IStorageService
    {
        Task SaveAsync(string key, string value);
        Task<string?> GetAsync(string key);

    }
}
