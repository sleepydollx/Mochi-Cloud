var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Temporary in-memory "database"
int playerScore = 0;
int playerLevel = 1;

// ROUTE 1: LOAD (Client requests data from server)

app.MapGet("/api/load", () => 
{
    Console.WriteLine("Data load requested!");
    
    // Returns data in JSON format
    return new { Score = playerScore, Level = playerLevel }; 
});


// ROUTE 2: SAVE (Client sends data to server)

app.MapPost("/api/save", (int newScore, int newLevel) => 
{
    // Update the temporary data
    playerScore = newScore;
    playerLevel = newLevel;
    
    Console.WriteLine($"New data saved! Score: {playerScore}, Level: {playerLevel}");
    
    return "Data successfully saved to the server!";
});

app.Run();