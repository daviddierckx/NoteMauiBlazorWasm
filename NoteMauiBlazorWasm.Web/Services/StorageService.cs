using Microsoft.JSInterop;
using NoteMauiBlazorWasm.Common.Interfaces;

namespace NoteMauiBlazorWasm.Web.Services
{
    public class StorageService : IStorageService
        {
        private readonly IJSRuntime _jsRuntime;
        private readonly string _storageName;
        public StorageService(IJSRuntime jSRuntime)
        {
            _jsRuntime = jSRuntime;
            _storageName = "window.localStorage";
        }

            public async Task<string?> GetAsync(string key) => await _jsRuntime.InvokeAsync<string?>($"{_storageName}.getItem", key);


            public async Task SaveAsync(string key, string value) => await _jsRuntime.InvokeVoidAsync($"{_storageName}.setItem", key, value);

        }
}
