namespace Api.Models;

public class Person
{
    public required string Id { get; set; }

    public required string Name { get; set; }
    public int Age { get; set; }

    public string? Description { get; set; }
}