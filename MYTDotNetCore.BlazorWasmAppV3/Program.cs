using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using MYTDotNetCore.BlazorWasmAppV3;
using MYTDotNetCore.BlazorWasmAppV3.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

string domainUrl = "https://localhost:7088";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(domainUrl) });
builder.Services.AddScoped<HttpClientService>();

await builder.Build().RunAsync();
