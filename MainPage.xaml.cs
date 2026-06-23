
using System.Reflection;
using System.Text;
using System.Text.Json;
using AIPoweredApp.Core;

namespace AIPoweredApp;

public partial class MainPage : ContentPage
{
    // Gemini configuration
    private const string ApiKey = "AIzaSyCqQiqmM5fUvJZ0UjWPvqXeCrnxALRUc2w";
    private const string Url =
        "https://generativelanguage.googleapis.com/v1beta/models/gemini-2.5-flash:generateContent";

    private readonly HttpClient _http = new();

    // JSON data (loaded at runtime)
    private string _eventsJson = string.Empty;
    private string _sprintJson = string.Empty;
    private string _assetsjson = string.Empty;
    private string _parkingjson = string.Empty;

    public MainPage()
    {
        InitializeComponent();

        try
        {
            // ✅ Load embedded JSON safely
            _eventsJson = LoadEmbeddedJson("EventsHolidayCalendar2026.json");
            _sprintJson = LoadEmbeddedJson("StgOptimusHavenSprintMetrics.json");
            _assetsjson = LoadEmbeddedJson("AssignedAssets.json");
            _parkingjson = LoadEmbeddedJson("ParkingSlots.json");
        }
        catch (Exception ex)
        {
            // ✅ Prevent startup crash & show error
            Dispatcher.Dispatch(() =>
            {
                ChatStack.Children.Add(new Label
                {
                    Text = $"Startup error:\n{ex.Message}",
                    TextColor = Colors.Red
                });
            });
        }
    }

    // ==============================
    // ✅ UI EVENT
    // ==============================
    private async void OnSendTapped(object sender, EventArgs e)
    {
        var userPrompt = PromptEditor.Text?.Trim();
        if (string.IsNullOrWhiteSpace(userPrompt))
            return;

        PromptEditor.Text = string.Empty;
        AddBubble(userPrompt, isUser: true);

        try
        {
            var finalPrompt = BuildFinalPrompt(userPrompt);
            var reply = await AskGeminiAsync(finalPrompt);
            var cleanedReply = CleanGeminiText(reply);
            AddBubble(cleanedReply, isUser: false);
                
        }
        catch (Exception ex)
        {
            AddBubble($"⚠ {ex.Message}", isUser: false);
        }

        await ScrollToBottomAsync();
    }

    // ==============================
    // ✅ ORCHESTRATION LOGIC
    // ==============================
    private string BuildFinalPrompt(string userPrompt)
    {
        var queryType = QueryRouter.Detect(userPrompt);
        string context;

        switch (queryType)
        {
            case QueryType.Events:
            case QueryType.Holidays:
                context = DataFilter.GetFullEventsContext(_eventsJson);
                break;
            
            case QueryType.SprintMetrics:
                context = DataFilter.GetFullSprintContext(_sprintJson);
                break;
            
            case QueryType.AssignedAssets:
                context = DataFilter.GetFullAssetsContext(_assetsjson);
                break;
            
            case QueryType.ParkingSlots:
                context = DataFilter.GetFullParkingContext(_parkingjson);
                break;
            

            default:
                context = "No relevant data available.";
                break;
        }

        return PromptBuilder.Build(context, userPrompt);
    }

    // ==============================
    // ✅ GEMINI API CALL
    // ==============================
    private async Task<string> AskGeminiAsync(string finalPrompt)
    {
        var body = JsonSerializer.Serialize(new
        {
            contents = new[]
            {
                new
                {
                    parts = new[]
                    {
                        new { text = finalPrompt }
                    }
                }
            }
        });

        var request = new HttpRequestMessage(
            HttpMethod.Post,
            $"{Url}?key={ApiKey}"
        )
        {
            Content = new StringContent(body, Encoding.UTF8, "application/json")
        };

        var response = await _http.SendAsync(request);
        var raw = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            try
            {
                var errorDoc = JsonDocument.Parse(raw);
                var message = errorDoc.RootElement
                    .GetProperty("error")
                    .GetProperty("message")
                    .GetString();

                throw new Exception($"Gemini error ({(int)response.StatusCode}): {message}");
            }
            catch
            {
                throw new Exception($"Gemini error ({(int)response.StatusCode})");
            }
        }

        var doc = JsonDocument.Parse(raw);
        return doc.RootElement
            .GetProperty("candidates")[0]
            .GetProperty("content")
            .GetProperty("parts")[0]
            .GetProperty("text")
            .GetString() ?? "No response";
    }

    // ==============================
    // ✅ EMBEDDED JSON LOADER
    // ==============================
    private static string LoadEmbeddedJson(string fileName)
    {
        var assembly = Assembly.GetExecutingAssembly();
        var resourceName = $"AIPoweredApp.Data.{fileName}";

        using var stream = assembly.GetManifestResourceStream(resourceName);
        if (stream == null)
            throw new Exception($"Embedded resource not found: {resourceName}");

        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }

    // ==============================
    // ✅ UI HELPERS
    // ==============================
    private void AddBubble(string text, bool isUser)
    {
        var label = new Label
        {
            Text = text,
            TextColor = isUser ? Colors.White : Colors.LightGray,
            FontSize = 15,
            LineHeight = 1.4
        };

        var bubble = new Frame
        {
            Content = label,
            BackgroundColor = isUser
                ? Color.FromArgb("#8B0000")
                : Color.FromArgb("#1A1A1F"),
            Padding = new Thickness(12),
            CornerRadius = 12,
            HorizontalOptions = isUser
                ? LayoutOptions.End
                : LayoutOptions.Start
        };

        ChatStack.Children.Add(bubble);
    }

    private async Task ScrollToBottomAsync()
    {
        await Task.Delay(50);
        await ChatScrollView.ScrollToAsync(0, double.MaxValue, true);
    }
    
    private static string CleanGeminiText(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return text;

        return text
            .Replace("**", "")   
            .Replace("*", "")    
            .Replace("•", "")   
            .Trim();
    }
}