using System.Net.Http.Json;
using System.Windows.Input;
using ApiTest.Config;

namespace ApiTest;

public class MainPageViewModel
{
    private readonly IHttpClientService _httpService;
    public ICommand GetResponse { get; }
    public ICommand PostResponse { get; }

    public MainPageViewModel(IHttpClientService httpService)
    {
        _httpService = httpService;
        GetResponse = new Command(async () => await GetAssetApiAsync());
        PostResponse = new Command(async () => await PostAssetApiAsync());
    }
    public async Task GetAssetApiAsync()
    {
        var url = $"{AppConfig.ToroHubWebApiBaseUrl}/Asset";
        var response = await _httpService.GetAsync(url);
        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine($"Error: {response.StatusCode}");
            return;
        }
        var json = await response.Content.ReadAsStringAsync();
        Console.WriteLine(json);
    }
    
    public async Task PostAssetApiAsync()
    {
        var url = $"{AppConfig.ToroHubWebApiBaseUrl}/Asset";
        var data = new
        {
            assetName = "Docking Station",
            description = "DS STG",
            serialNumber = "DS123456",
            tagId = "DSTg1234",
            isImaged = true,
            isReplacementRequested = true,
            purchaseType = "Rental",
            invoiceNumber = "KJHGF3456JHB",
            vendorName = "Unicorn",
            comments = "none",
            isActive = true,
            updatedAt = "2026-02-02T08:00:35.572Z",
            updatedBy = "Prakrati"
        };
        var content = JsonContent.Create(data);
        var response = await _httpService.PostAsync(url, content);

        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine($"Error: {response.StatusCode}");
            return;
        }
        var postjson = await response.Content.ReadAsStringAsync();
        Console.WriteLine(postjson);
        var getresponse = await _httpService.GetAsync(url);
        var json = await getresponse.Content.ReadAsStringAsync();
        Console.WriteLine(json);
    }
}