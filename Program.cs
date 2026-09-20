var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

int playerScore = 0;
int playerLevel = 1;

// ROUTE 1: LOAD
app.MapGet("/api/load", () =>
{
    Console.WriteLine("Data load requested!");
    return new { Score = playerScore, Level = playerLevel };
});

// ROUTE 2: SAVE
app.MapPost("/api/save", (int newScore, int newLevel) =>
{
    if (newScore < 0 || newLevel < 1)
    {
        return Results.BadRequest("Score Cant be negative and Level must be at least 1.");
    }

    playerScore = newScore;
    playerLevel = newLevel;
    Console.WriteLine($"Data saved! Score: {playerScore}, Level: {playerLevel}");
    return Results.Ok(new { Status = "Success" });
});

// ROUTE 3: RESET
app.MapPost("/api/reset", () =>
{
    playerScore = 0;
    playerLevel = 1;
    Console.WriteLine("Player data has been reset!");
    return Results.Ok(new { Message = "Data reset", Score = playerScore, Level = playerLevel });
});

app.Run();