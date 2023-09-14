using JsonDeserializerTests.Models;
using System.Text.Json.Serialization;


public class Person
{
    public int Id { get; set; }

    // if null do not write
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? FirstName { get; set; }

    // display this attribute name surname
    [JsonPropertyName("surname")]
    public string? LastName { get; set; }

    // do not write this in json
    [JsonIgnore]
    public bool IsAlive { get; set; }

    public int Age { get; set; }



    public Address? Address { get; set; }
    public IList<Phone>? Phones { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, First name: {FirstName}, Surname: {LastName}";
    }
}

