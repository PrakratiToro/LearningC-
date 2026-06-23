namespace AIPoweredApp.Core;

public enum QueryType
{
    Events,
    Holidays,
    SprintMetrics,
    AssignedAssets,
    ParkingSlots,
    Unknown
}

public static class QueryRouter
{
    public static QueryType Detect(string prompt)
    {
        if (string.IsNullOrWhiteSpace(prompt))
            return QueryType.Unknown;

        var p = prompt.ToLowerInvariant();

        //  Sprint / team performance (HIGHEST PRIORITY)
        if (
            p.Contains("sprint") ||
            p.Contains("perform") ||
            p.Contains("performance") ||
            p.Contains("team") ||
            p.Contains("bugs") ||
            p.Contains("stories") ||
            p.Contains("velocity") ||
            p.Contains("optimus") ||
            p.Contains("haven")
        )
        {
            return QueryType.SprintMetrics;
        }

        //  Holidays
        if (
            p.Contains("holiday") ||
            p.Contains("leave") ||
            p.Contains("day off") ||
            p.Contains("festival")
        )
        {
            return QueryType.Holidays;
        }

        //  Events
        if (
            p.Contains("event") ||
            p.Contains("session") ||
            p.Contains("outing") ||
            p.Contains("workshop") ||
            p.Contains("activity")
        )
        {
            return QueryType.Events;
        }

        //  Assigned Assets
        if (
            p.Contains("asset") ||
            p.Contains("assets") ||
            p.Contains("assigned") ||
            p.Contains("device") ||
            p.Contains("equipment") ||
            p.Contains("hardware") ||
            p.Contains("laptop") ||
            p.Contains("keyboard") ||
            p.Contains("mouse") ||
            p.Contains("headset") ||
            p.Contains("number") ||
            p.Contains("printer") ||
            p.Contains("projector") ||
            p.Contains("dock") ||
            p.Contains("usb")
        )
        {
            return QueryType.AssignedAssets;
        }

        //  Parking Slots
        if (
            p.Contains("parking") ||
            p.Contains("park") ||
            p.Contains("slot") ||
            p.Contains("slots") ||
            p.Contains("two wheeler") ||
            p.Contains("2 wheeler") ||
            p.Contains("available") ||
            p.Contains("occupied") ||
            p.Contains("four wheeler") ||
            p.Contains("4 wheeler")
        )
        {
            return QueryType.ParkingSlots;
        }
        
        
        //  Unknown (safe fallback handled elsewhere)
        return QueryType.Unknown;
    }

    private static bool ContainsAny(string text, IEnumerable<string> keywords)
    {
        foreach (var keyword in keywords)
        {
            if (text.Contains(keyword))
                return true;
        }

        return false;
    }
}