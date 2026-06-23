
using System.Net.Http.Json;
namespace ApiTest;

public class HttpClientService : IHttpClientService
{
    private readonly HttpClient _client = new();
    
    public Task<HttpResponseMessage> GetAsync(string url) =>
        _client.GetAsync(url);
    public Task<HttpResponseMessage> PostAsync(string url, HttpContent content) =>
        _client.PostAsJsonAsync(url, content); 
    
    public Task<HttpResponseMessage> PutAsync(string url, HttpContent content) =>
        _client.PutAsJsonAsync(url, content);
    public Task<HttpResponseMessage> DeleteAsync(string url) =>
        _client.DeleteAsync(url);
}
