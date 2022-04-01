using Microsoft.AspNetCore.Mvc;

namespace GuessingGameAPI.Controllers;

[Route("[controller]")]
[ApiController]

public class GameAPIController : ControllerBase
{
    [HttpGet]
    [Route("StartGame")]
    public IActionResult StartGame()
    {
        return Ok(GameLogic.StartGame());
    }

    [HttpGet]
    [Route("GetGameData")]
    public GameModel GetGameData()
    {
        return GameLogic.ReturnGame();
    }

    [HttpGet]
    [Route("getPlayerInfo")]
    public PlayerModel GetPlayerInfo()
    {
        return LeaderBoard.ReturnPlayerInfo();
    }

    [HttpGet]
    [Route("getLeaderBoard")]
    public IEnumerable<PlayerModel> GetLeaderBoard()
    {
        return LeaderBoard.GetLeaderBoard();
    }

    [HttpGet]
    [Route("addPlayedGame")]
    public double AddPlayerGame()
    {
        return LeaderBoard.AddPlayedGame();
    }


    [HttpPost]
    [Route("player")]
    public IActionResult CreateNewPlayerRequest(string name)
    {
        if (!GameLogic.IsValidName(name))
        {
            return BadRequest("The name cannot be empty and must contain at least 3 characters");
        }

        return Created("", LeaderBoard.CreatePlayer(name));
    }

    [HttpPost]
    [Route("postNumbers")]
    public IActionResult ReturnGuessNumber(string input)
    {
        if (GameLogic.IsInvalidNumberInput(input))
            return BadRequest("The input is incorrect");

        var checkNumbers = GameLogic.CheckPlayersGuess(input);

        return Ok(checkNumbers);
    }
}

