namespace ApiTest;

public interface IHttpClientService
{
    Task<HttpResponseMessage> GetAsync(string url);
    Task<HttpResponseMessage> PostAsync(string url, HttpContent content);
    Task<HttpResponseMessage> PutAsync(string url, HttpContent content);
    Task<HttpResponseMessage> DeleteAsync(string url);
}