using Api.Models;
using Microsoft.Data.SqlClient;

namespace Api.Data;

public class Repository(IConfiguration configuration) : IRepository
{
    public Person? GetPerson(string id)
    {
        using var connection =
            new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

        connection.Open();
        using var command = new SqlCommand(
            "SELECT * FROM Persons WHERE Id = @id",
            connection);
        command.Parameters.AddWithValue("@id", id);

        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            return new Person
            {
                Id = reader.GetString(0),
                Name = reader.GetString(1),
                Age = reader.GetInt32(2),
                Description = reader.GetString(3)
            };
        }

        return null;
    }

    public Person GetAdministrator()
    {
        const string id = "admin";
        using var connection =
            new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

        connection.Open();
        using var command = new SqlCommand(
            "SELECT * FROM Persons WHERE Id = @id",
            connection);
        command.Parameters.AddWithValue("@id", id);

        using var reader = command.ExecuteReader();
        if (reader.Read())
        {
            return new Person
            {
                Id = reader.GetString(0),
                Name = reader.GetString(1),
                Age = reader.GetInt32(2),
                Description = reader.GetString(3)
            };
        }

        throw new InvalidOperationException("Administrator not found");
    }

    public Person AddPerson(Person person)
    {
        using var connection =
            new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

        connection.Open();

        person.Id = Guid.NewGuid().ToString();

        using var command = new SqlCommand(
            """
            INSERT INTO Persons (Id, Name, Age, Description) 
            VALUES (@id, @name, @age, @description)
            """,
            connection);
        command.Parameters.AddWithValue("@id", person.Id);
        command.Parameters.AddWithValue("@name", person.Name);
        command.Parameters.AddWithValue("@age", person.Age);
        command.Parameters.AddWithValue("@description", person.Description);

        command.ExecuteNonQuery();

        return GetPerson(person.Id)!;
    }

    public void UpdatePerson(Person person)
    {
        using var connection =
            new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

        connection.Open();

        using var command = new SqlCommand(
            """
            UPDATE Persons 
            SET Name = @name, Age = @age, Description = @description 
            WHERE Id = @id
            """,
            connection);
        command.Parameters.AddWithValue("@id", person.Id);
        command.Parameters.AddWithValue("@name", person.Name);
        command.Parameters.AddWithValue("@age", person.Age);
        command.Parameters.AddWithValue("@description", person.Description);

        command.ExecuteNonQuery();
    }
}