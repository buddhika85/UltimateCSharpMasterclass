using System.Text.Json.Serialization;

namespace JsonSerializerTests.Models
{
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
    }
}
