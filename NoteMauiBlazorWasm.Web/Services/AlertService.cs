using Microsoft.JSInterop;
using NoteMauiBlazorWasm.Common.Interfaces;

namespace NoteMauiBlazorWasm.Web.Services
{
    public class AlertService : IAlertService
        {
            private readonly IJSRuntime _jsRuntime;
            public AlertService(IJSRuntime jSRuntime)
            {
                _jsRuntime = jSRuntime;
            }
            public async Task AlertAsync(string message, string title = "Alert", string buttonName = "Ok")
            {
                await _jsRuntime.InvokeVoidAsync("window.alert", $"{title} \n{message}");
            }

            public async Task<string> PromptAsync(string message, string title)
            {
                return await _jsRuntime.InvokeAsync<string?>("window.prompt", $"{title} \n{message}");
            }
        }
}
