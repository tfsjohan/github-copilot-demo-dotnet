using System.Net;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

// Make a JokeController that uses the IJokeService.
// The controller should have a single Http Get endpoint that returns a random joke.

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JokeController : ControllerBase
    {
        private readonly IJokeService _jokeService;

        public JokeController(IJokeService jokeService)
        {
            _jokeService = jokeService;
        }

        [HttpGet]
        public async Task<ActionResult<Joke>> GetJoke()
        {
            try
            {
                var joke = await _jokeService.GetRandomJoke();
                return Ok(joke);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode((int)HttpStatusCode.ServiceUnavailable);
            }
        }
    }
}