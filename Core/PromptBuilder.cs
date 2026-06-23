namespace AIPoweredApp.Core;

public static class PromptBuilder
{
    public static string Build(string context, string question)
    {
        var today = DateTime.Now.ToString("yyyy-MM-dd");

        return $"""
                You are a senior workplace assistant.

                Today’s date is: {today}
                Use this date as the reference point for terms like
                "upcoming", "coming up", "next", or "recent".

                Use ONLY the provided JSON context.
                Do NOT assume or invent data.

                Context (JSON data):
                {context}

                Question:
                {question}

                Answering rules:
                - Be clear and confident
                - Use dates explicitly when relevant
                - If nothing occurs after today, say so clearly
                """;
    }
}
