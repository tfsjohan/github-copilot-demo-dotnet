using System.Text.Json;

namespace Api.Services;

/*
 * Create a JokeService class that implements IJokeService.
 * The class should take an HttpClient as a constructor argument. This HttpClient will have it's base address set to "https://api.chucknorris.io/".
 * The GetRandomJoke method should make a GET request to "https://api.chucknorris.io/jokes/random" and return the result as a Joke object.
 * The Chuck Norris api uses snake_case for properties, make sure serializer settings are set to use **snake_case**.
 */
public class JokeService : IJokeService
{
    private readonly HttpClient _client;
    private readonly JsonSerializerOptions _options;

    public JokeService(HttpClient client)
    {
        _client = client;
        _options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
        };
    }

    public async Task<Joke> GetRandomJoke()
    {
        var response = await _client.GetAsync("jokes/random");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<Joke>(content, _options)!;
    }
}