// See https://aka.ms/new-console-template for more information
using System;
using System.Data;
using System.Data.SqlClient;
using MYTDotNetCore.ConsoleApp;
using MYTDotNetCore.ConsoleApp.DapperExamples;
using Serilog;

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

//DapperExample dapperExample = new DapperExample();
//dapperExample.Generate(491);
//EFCoreExample eFCoreExample = new EFCoreExample();

int pageSize = 10;
AppDbContext _db = new AppDbContext();
int rowCount = _db.Blogs.Count();
Console.WriteLine($"Row Count is {rowCount}");

int pageCount = rowCount / pageSize;
if (rowCount % pageSize > 0)
{
    pageCount++;
}
Console.WriteLine($"Page Count is {pageCount}");

Console.ReadKey();
