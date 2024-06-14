using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using MYTDotNetCore.BlazorWasmApp;
using MYTDotNetCore.BlazorWasmApp.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddMudServices();
builder.Services.AddScoped<HttpClientService>();
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

string DomainUrl = "https://localhost:7088";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(DomainUrl) });

await builder.Build().RunAsync();
