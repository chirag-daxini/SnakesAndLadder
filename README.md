Console based SnakesAndLadder game.

Source code is divided into 4 projects
1) SnakeAndLadder - This is main entry point of the game. This project contains host builder for the game.
2) SnakeAndLadder.Domain - This project contains all the domain related services.
3) SnakeAndLadder.Models - This project contains all the objects which are required for game.
4) SnakeAndLadder.Tests -  This project contains unit tests for the application.

With this game, user can configure following things in game [in appsettings.json]
a. BoardSize
b. Where to put snake & ladder.
c. Player count
d. What will be minimum dice number needed.

Below is example configuration for game.

{
  "GameSettings": {
    "BoardSize": 100,
    "Ladders": [
      {
        "CellNumber": 15,
        "AdvantageCell": 26
      },
      {
        "CellNumber": 51,
        "AdvantageCell": 67
      },
      {
        "CellNumber": 71,
        "AdvantageCell": 91
      },
      {
        "CellNumber": 87,
        "AdvantageCell": 94
      }
    ],
    "Snakes": [
      {
        "CellNumber": 16,
        "PenaltyCell": 6
      },
      {
        "CellNumber": 46,
        "PenaltyCell": 25
      },
      {
        "CellNumber": 49,
        "PenaltyCell": 11
      },
      {
        "CellNumber": 99,
        "PenaltyCell": 2
      }
    ],
    "NoOfPlayers": 2,
    "IntialToken" :  1
  }
}


