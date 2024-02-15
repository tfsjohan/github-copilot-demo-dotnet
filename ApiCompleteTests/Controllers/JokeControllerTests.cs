using System.Net;
using Api.Services;
using Api.Controllers;
using Microsoft.AspNetCore.Mvc;

/*
 * Tests should check valid responses for the JokeController. It should handle cases where the JokeService
 * throws HttpRequestErrors. It should never return a null value for a joke.
 */

public class JokeControllerTests
{
    // Test a successful fetch of a random joke. Moq the IJokeService to return a random Joke.
    [Fact]
    public async Task GetJoke_ReturnsOk_WhenJokeExists()
    {
        // Create a Joke object used in the test that sets the joke's properties to a known value.
        var joke = new Joke
        {
            Id = "1",
            Value = "This is a joke"
        };

        // Arrange
        var jokeService = new Mock<IJokeService>();
        jokeService.Setup(js => js.GetRandomJoke()).ReturnsAsync(joke);
        var controller = new JokeController(jokeService.Object);

        // Act
        var result = await controller.GetJoke();

        // Assert
        Assert.Equal(result.Value, joke);
    }

    // Test a failed fetch of a random joke. Moq the IJokeService throw a HttpRequestException.
    [Fact]
    public async Task GetJoke_ReturnsServerError_WhenExceptionIsThrown()
    {
        // Arrange
        var jokeService = new Mock<IJokeService>();
        jokeService.Setup(js => js.GetRandomJoke()).ThrowsAsync(new HttpRequestException());
        var controller = new JokeController(jokeService.Object);

        // Act
        var result = await controller.GetJoke();

        // Assert
        Assert.IsType<StatusCodeResult>(result.Result);
        Assert.Equal((int)HttpStatusCode.ServiceUnavailable, ((StatusCodeResult)result.Result).StatusCode);
    }
}