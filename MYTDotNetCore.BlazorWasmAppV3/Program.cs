using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MYTDotNetCore.BlazorWasmAppV3;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

string domainUrl = "https://localhost:7088";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(domainUrl) });

await builder.Build().RunAsync();
