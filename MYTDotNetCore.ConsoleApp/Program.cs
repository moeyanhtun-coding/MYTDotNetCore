// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;
using MYTDotNetCore.ConsoleApp;
using MYTDotNetCore.ConsoleApp.DapperExamples;

Console.WriteLine("Hello, World!");


// => c# => db connection 

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Create("this is title", "this is Author", "this is Content");
//adoDotNetExample.Delete(11);
//adoDotNetExample.Update(10, "this is Moe Yan Htun", "this is from Myanmar", "this is Web Developer");
//adoDotNetExample.Edit(11);
// Ado.Net Read
// CRUD

DapperExample dapperExample = new DapperExample();
dapperExample.Run();     


EFCoreExample eFCoreExample = new EFCoreExample();
eFCoreExample.Run();
Console.ReadKey();