namespace Api.Services;

// Make a public interface called IJokeService that has a public async method called GetJoke.
// The method returns a Joke object. 
public interface IJokeService
{
    public Task<Joke> GetRandomJoke();
}


