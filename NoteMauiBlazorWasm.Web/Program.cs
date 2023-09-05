using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NoteMauiBlazorWasm.Common.Interfaces;
using NoteMauiBlazorWasm.Common.Services;
using NoteMauiBlazorWasm.Web;
using NoteMauiBlazorWasm.Web.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddTransient<AuthServices>();
builder.Services.AddSingleton<IAlertService, AlertService>()
                           .AddSingleton<IStorageService, StorageService>();

await builder.Build().RunAsync();
