// See https://aka.ms/new-console-template for more information
using MYTDotNetCore.ConsoleAppHttpClientExample;

Console.WriteLine("Hello, World!");

RestClient restClient = new RestClient();
await restClient.RunAsync();

Console.ReadLine();