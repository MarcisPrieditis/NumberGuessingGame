public class LeaderBoard
{
    public static List<PlayerModel> _leaderBoard = new()
    {
        new()
        {
            PlayersId = 1,
            Name = "Test Object 1",
            GamesPlayed = 3,
            GamesWon = 1,
            TotalTries = 6
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
            PlayersId = 3,
            Name = "Test Object 3",
            GamesPlayed = 4,
            GamesWon = 4,
            TotalTries = 7
        },
    };

    private static PlayerModel? _currentPlayer;
    public static int PlayerId = 3;

    public static PlayerModel CreatePlayer(string name)
    {
        PlayerId++;

        var player = new PlayerModel
        {
            PlayersId = PlayerId,
            Name = name,
            GamesPlayed = 1,
            GamesWon = 0,
            TotalTries = 0
        };

        _leaderBoard.Add(player);
        _currentPlayer = player;

        return player;
    }

    public static IEnumerable<PlayerModel> GetLeaderBoard()
    {
        var sortedList = _leaderBoard.Where(f => f.GamesPlayed >= 3)
            .OrderByDescending(c => c.GamesWon / c.GamesPlayed).ThenBy(c => c.TotalTries);

        return sortedList;
    }

    public static PlayerModel ReturnPlayerInfo()
    {
        return _currentPlayer!;
    }

    public static double AddPlayedGame()
    {
        return _currentPlayer!.GamesPlayed++;
    }

    public static double AddVictoryAttempt()
    {
        return _currentPlayer!.GamesWon++;
    }

    public static int AddTry()
    {
        return _currentPlayer!.TotalTries++;
    }
}