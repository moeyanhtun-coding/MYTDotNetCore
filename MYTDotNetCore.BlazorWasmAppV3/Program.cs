using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using MYTDotNetCore.BlazorWasmAppV3;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();
builder.Services.AddScoped<HttpClientService>();
builder.Services.AddScoped<IDialogService>();

string domainUrl = "https://localhost:7088";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(domainUrl) });

await builder.Build().RunAsync();
