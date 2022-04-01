public static class GameLogic
{
    private static readonly Random rand = new();
    private static GameModel? _game;
    private static int _gameId;
    private static string? _numberToGuess;

    public static string GenerateGuessingNumbers(int maxNumber)
    {
        List<int> allNumbers = Enumerable.Range(0, maxNumber).ToList();
        List<int> guessingNumbers = new List<int>();
        for (int i = 0; i < 4; i++)
        {
            int index = rand.Next(0, allNumbers.Count);
            guessingNumbers.Add(allNumbers[index]);
            allNumbers.RemoveAt(index);
        }
        _numberToGuess = string.Join("", guessingNumbers);

        return _numberToGuess;
    }

    public static GameModel StartGame()
    {
        _gameId++;
        _numberToGuess = GenerateGuessingNumbers(10);

        _game = new GameModel
        {
            GameId = _gameId,
            NumbersToGuess = _numberToGuess,
            NumbersGuessed = 0,
            NumbersCorrectPlaces = 0,
            Attempts = 8,
            GamesWon = false,
            PreviousGuesses = new List<string>(),
        };

        return _game;
    }
    public static GameModel ReturnGame()
    {
        return _game!;
    }

    public static bool IsValidName(string name)
    {
        return name.Length >= 3 && !string.IsNullOrEmpty(name);
    }

    public static bool IsInvalidNumberInput(string input)
    {
        return input.Length < 4 || string.IsNullOrEmpty(input);
    }

    public static GameModel CheckPlayersGuess(string userInput)
    {
        _game!.NumbersCorrectPlaces = 0;
        _game.NumbersGuessed = 0;

        _game.PreviousGuesses?.Add(userInput);

        var splitGamesNumbers = _numberToGuess?.ToCharArray();
        var SplitUsersNumbers = userInput.Trim().ToCharArray();

        for (var i = 0; i < _numberToGuess!.Length; i++)
        {
            if (_numberToGuess.Contains(SplitUsersNumbers[i]))
            {
                _game.NumbersGuessed++;
            }

            if (splitGamesNumbers?[i] == SplitUsersNumbers[i])
            {
                _game.NumbersCorrectPlaces++;
            }
        }

        if (IsWinner())
        {
            _game.GamesWon = true;
            LeaderBoard.AddVictoryAttempt();
        }

        LeaderBoard.AddTry();
        _game.Attempts--;

        return _game;
    }

    public static bool IsWinner()
    {
        return _game?.NumbersCorrectPlaces == 4;
    }
}