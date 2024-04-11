// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;
using MYTDotNetCore.ConsoleApp;

Console.WriteLine("Hello, World!");


// => c# => db connection 

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
adoDotNetExample.Read();
//adoDotNetExample.Create("this is title", "this is Author", "this is Content");
// Ado.Net Read
// CRUD

Console.ReadKey(); 