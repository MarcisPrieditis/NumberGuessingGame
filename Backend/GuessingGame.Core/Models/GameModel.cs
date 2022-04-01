public class GameModel
{
    public int GameId { get; set; }
    public string? NumbersToGuess { get; set; }
    public int NumbersGuessed { get; set; }
    public int NumbersCorrectPlaces { get; set; }
    public int Attempts { get; set; }
    public bool GamesWon { get; set; }
    public List<string>? PreviousGuesses { get; set; }
}