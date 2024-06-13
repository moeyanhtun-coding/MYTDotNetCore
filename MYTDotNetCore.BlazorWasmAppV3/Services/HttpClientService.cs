namespace MYTDotNetCore.BlazorWasmAppV3.Services;

public class HttpClientService
{
    private readonly HttpClient _httpClient;

    public HttpClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<T> ExecutAsync<T>(
        string endpoint,
        EnumHttpMethod httpMethod,
        object? requestModel = null
    ) { }
}

public enum EnumHttpMethod
{
    None,
    Get,
    Post,
    Patch,
    Delete
}
