// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

HttpClient client = new HttpClient();
HttpResponseMessage response = await client.GetAsync("https://localhost:7088/api/blog");

if (response.IsSuccessStatusCode)
{
    string JsonStr = await response.Content.ReadAsStringAsync();
    Console.WriteLine(JsonStr);

}
