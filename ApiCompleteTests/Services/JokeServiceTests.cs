using System.Net;
using System.Text.Json;
using Api.Services;
using Moq.Protected;

namespace ApiTests
{
    public class JokeServiceTests
    {
        private readonly Mock<HttpMessageHandler> _mockHttpMessageHandler;
        private readonly Mock<HttpClient> _mockHttpClient;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly JokeService _jokeService;

        public JokeServiceTests()
        {
            _mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            var httpClient = new HttpClient(_mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri("https://api.chucknorris.io/")
            };
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
            };
            _jokeService = new JokeService(httpClient);
        }

        [Fact]
        public async Task GetRandomJoke_SuccessfulFetch_ReturnsJoke()
        {
            // Arrange
            var joke = new Joke { Id = "123", Value = "Chuck Norris can divide by zero." };
            var serializedJoke = JsonSerializer.Serialize(joke, _jsonSerializerOptions);
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedJoke)
            };

            _mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            // Act
            var result = await _jokeService.GetRandomJoke();

            // Assert
            Assert.Equal(joke.Id, result.Id);
            Assert.Equal(joke.Value, result.Value);
        }

        [Fact]
        public async Task GetRandomJoke_FailedFetch_ThrowsException()
        {
            // Arrange
            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            _mockHttpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);

            // Act and Assert
            await Assert.ThrowsAsync<HttpRequestException>(async () => await _jokeService.GetRandomJoke());
        }
    }
}