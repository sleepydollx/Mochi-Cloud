var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<Player> leaderboard = new List<Player>();

// ROUTE 1: LOAD
app.MapGet("/api/load", () => 
{
    Console.WriteLine("Game meminta data leaderboard...");
    
    return leaderboard; 
});

// ROUTE 2: SAVE
app.MapPost("/api/save", (string playerName, int newScore, int newLevel) => 
{
    Player pemainBaru = new Player 
    { 
        Name = playerName, 
        Score = newScore, 
        Level = newLevel 
    };
    
    leaderboard.Add(pemainBaru);
    
    Console.WriteLine($"[DATA MASUK] {playerName} dengan skor {newScore}");
    return $"Data {playerName} berhasil ditambahkan ke server!";
});

app.Run();