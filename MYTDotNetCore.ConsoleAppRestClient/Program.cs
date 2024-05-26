// See https://aka.ms/new-console-template for more information
using MYTDotNetCore.ConsoleAppHttpClientExample;

Console.WriteLine("Hello, World!");

RestClientExample restClient = new RestClientExample();
await restClient.RunAsync();

Console.ReadLine();