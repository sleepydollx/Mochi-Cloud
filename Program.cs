var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Player> leaderboard = new List<Player>();

// ROUTE 1: LOAD
app.MapGet("/api/load", () => 
{
    Console.WriteLine("Asking for leaderboard data...");
    
    return leaderboard; 
});

// ROUTE 2: SAVE
app.MapPost("/api/save", (string playerName, int newScore, int newLevel) => 
{
    Player newPlayer = new Player 
    { 
        Name = playerName, 
        Score = newScore, 
        Level = newLevel 
    };

    leaderboard.Add(newPlayer);
    
    Console.WriteLine($"[DATA INPUT] {playerName} dengan skor {newScore}");
    return $"Data {playerName} berhasil ditambahkan ke server!";
});

app.Run();