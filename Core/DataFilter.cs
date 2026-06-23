using System.Text.Json;
using System.Linq;

namespace AIPoweredApp.Core;

public static class DataFilter
{
    // ✅ FULL EVENTS + HOLIDAYS CONTEXT
    public static string GetFullEventsContext(string json)
    {
        using var doc = JsonDocument.Parse(json);
        return doc.RootElement.ToString();
    }

    // ✅ FULL SPRINT CONTEXT (ALL SPRINTS)
    public static string GetFullSprintContext(string json)
    {
        using var doc = JsonDocument.Parse(json);
        return doc.RootElement.ToString();
    }
    // ✅ ASSIGNED ASSETS 
    public static string GetFullAssetsContext(string json)
    {
        using var doc = JsonDocument.Parse(json);
        return doc.RootElement.ToString();
    }
    // ✅ PARKING SLOTS CONTEXT
    public static string GetFullParkingContext(string json)
    {
        using var doc = JsonDocument.Parse(json);
        return doc.RootElement.ToString();
    }
}
