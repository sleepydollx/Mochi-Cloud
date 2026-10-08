from fastapi import FastAPI
from pydantic import BaseModel

app = FastAPI()

# note book player gitu
leaderboard = []

# Cetakan Player
class Player(BaseModel):
    name: str
    score: int
    level: int

# ROUTE 1: LOAD
@app.get("/api/load")
def load_data():
    print("Game meminta data leaderboard...")
    return leaderboard

# ROUTE 2: SAVE
@app.post("/api/save")
def save_data(player: Player):
    leaderboard.append(player.dict())
    print(f"[DATA INPUT] {player.name} dengan skor {player.score}")
    return {"message": f"Data {player.name} berhasil ditambahkan ke server!"}