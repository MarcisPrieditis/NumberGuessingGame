using System.Collections.Generic;
using Newtonsoft.Json;
using Xunit;

namespace GuessingGame.Tests;

public class LeaderBoardTests
{
    [Fact]
    public void PlayerCreated_ShouldReturn_PlayerObject()
    {
        //Arrange
        LeaderBoard._leaderBoard.Clear();
        LeaderBoard.PlayerId = 0;

        //Act
        LeaderBoard.CreatePlayer("Marcis");
        var expected = new PlayerModel()
        {
            PlayersId = 1,
            Name = "Marcis",
            GamesWon = 0,
            GamesPlayed = 1
        };

        //Assert
        Assert.Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(LeaderBoard.ReturnPlayerInfo()));
    }

    [Fact]
    public void AddGamesWon_ShouldReturn_GamesWonOne()
    {
        //Arrange
        LeaderBoard._leaderBoard.Clear();
        LeaderBoard.PlayerId = 0;
        LeaderBoard.CreatePlayer("Marcis");

        //Act
        LeaderBoard.AddVictoryAttempt();
        var expected = new PlayerModel()
        {
            PlayersId = 1,
            Name = "Marcis",
            GamesWon = 1,
            GamesPlayed = 1
        };

        //Assert
        Assert.Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(LeaderBoard.ReturnPlayerInfo()));
    }

    [Fact]
    public void AddPlayedGame_ShouldReturn_GamesPlayedTwo()
    {
        //Arrange
        LeaderBoard._leaderBoard.Clear();
        LeaderBoard.PlayerId = 0;
        PlayerModel result = LeaderBoard.CreatePlayer("Marcis");

        var expected =
            new PlayerModel()
            {
                PlayersId = 1,
                Name = "Marcis",
                GamesWon = 0,
                GamesPlayed = 2,
                TotalTries = 0
            };

        //Act
        LeaderBoard.AddPlayedGame();
        var res = LeaderBoard.ReturnPlayerInfo();

        //Assert
        Assert.Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(res));
    }

    [Fact]
    public void GetSortedLeaderBoard_ShouldReturnSorted_ByGamesWonDividedByGamesPlayed()
    {
        //Arrange
        LeaderBoard._leaderBoard.Clear();
        LeaderBoard._leaderBoard.Add(new PlayerModel()
        {
            PlayersId = 1,
            Name = "Test Object 1",
            GamesPlayed = 3,
            GamesWon = 1,
            TotalTries = 6
        });
        LeaderBoard._leaderBoard.Add(new PlayerModel()
        {
            PlayersId = 2,
            Name = "Test Object 2",
            GamesPlayed = 3,
            GamesWon = 3,
            TotalTries = 9
        });
        LeaderBoard._leaderBoard.Add(new PlayerModel()
        {
            PlayersId = 3,
            Name = "Test Object 3",
            GamesPlayed = 4,
            GamesWon = 4,
            TotalTries = 7
        });

        var expected = new List<PlayerModel>()
        {
            new()
            {
                PlayersId = 3,
                Name = "Test Object 3",
                GamesPlayed = 4,
                GamesWon = 4,
                TotalTries = 7
            },
            new()
            {
                PlayersId = 2,
                Name = "Test Object 2",
                GamesPlayed = 3,
                GamesWon = 3,
                TotalTries = 9
            },

            new()
            {
                PlayersId = 1,
                Name = "Test Object 1",
                GamesPlayed = 3,
                GamesWon = 1,
                TotalTries = 6
            }

        };

        //Act
        var res = LeaderBoard.GetLeaderBoard();

        //Assert
        Assert.Equal(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(res));
    }
}