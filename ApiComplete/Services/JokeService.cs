using System.Text.Json;

namespace Api.Services;

/*
 * Create a JokeService class that implements IJokeService.
 * The class should take an HttpClient as a constructor argument.
 * This HttpClient will already have it's base address set to "https://api.chucknorris.io/".
 * The GetRandomJoke method should make a GET request to "https://api.chucknorris.io/jokes/random" and return the result as a Joke object.
 */
public class JokeService : IJokeService
{
    private readonly HttpClient _httpClient;

    public JokeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Joke> GetRandomJoke()
    {
        return await _httpClient.GetFromJsonAsync<Joke>("jokes/random");
    }
}
