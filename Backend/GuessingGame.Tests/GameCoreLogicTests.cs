using System.Linq;
using Xunit;

namespace GuessingGame.Tests;

public class GameCoreLogicTests
{
    [Fact]
    public void GetGuessingNumber_ShouldReturn_FourDifferentNumbers()
    {
        //Arrange
        var numbers = GameLogic.GenerateGuessingNumbers(4).ToList();
        numbers.Sort();


        //Act
        var expected = "0123";

        //Assert
        Assert.Equal(expected, string.Join("", numbers));
    }

    [Fact]
    public void IsValidName_ShouldReturnTrue()
    {
        //Arrange
        var expected = GameLogic.IsValidName("Marcis");

        //Assert
        Assert.True(expected);
    }

    [Theory]
    [InlineData(" ")]
    [InlineData("ma")]
    public void IsValidName_ShouldReturnFalse(string name)
    {
        //Arrange
        var expected = GameLogic.IsValidName(name);

        //Assert
        Assert.False(expected);
    }

    [Fact]
    public void IsValidNumber_ShouldReturnFalse()
    {
        //Arrange
        var expected = GameLogic.IsInvalidNumberInput("1234");

        //Assert
        Assert.False(expected);
    }

    [Theory]
    [InlineData("213")]
    [InlineData("1")]
    [InlineData("12")]
    public void IsValidNumber_ShouldReturnTrue(string name)
    {
        //Arrange
        var numbers = GameLogic.IsInvalidNumberInput(name);

        //Assert
        Assert.True(numbers);
    }

    [Fact]
    public void IsWinner_ShouldReturnTrue()
    {
        //Arrange
        GameModel res = GameLogic.StartGame();
        res.NumbersCorrectPlaces = 4;

        //Act
        var expected = GameLogic.IsWinner();

        //Assert
        Assert.True(expected);
    }

    [Fact]
    public void IsWinner_ShouldReturnFalse()
    {
        //Arrange
        GameModel res = GameLogic.StartGame();
        res.NumbersCorrectPlaces = 3;

        //Act
        var expected = GameLogic.IsWinner();

        //Assert
        Assert.False(expected);
    }
}