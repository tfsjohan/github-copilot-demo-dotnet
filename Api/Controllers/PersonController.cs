using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController(IRepository repository) : ControllerBase
{
    public ActionResult<Person> Get(string id)
    {
        var person = repository.GetPerson(id);

        if (person != null)
        {
            return Ok(person);
        }

        return NotFound();
    }

    [HttpPost("{id}/description")]
    public ActionResult<Person> UpdateDescription(
        string id,
        [FromBody] string description)
    {
        var person = repository.GetPerson(id);

        if (person != null)
        {
            person.Description = description;
            repository.UpdatePerson(person);
            
            return Ok(person);
        }

        return NotFound();
    }

    [HttpPut("{id}")]
    public ActionResult<Person> UpdatePerson(
        [FromBody] Person person)
    {
        repository.UpdatePerson(person);
        
        return Ok(person);
    }

    [HttpPost("")]
    public ActionResult<Person> AddPerson(
        [FromBody] Person person)
    {
        repository.AddPerson(person);
        
        return Ok(person);
    }
}