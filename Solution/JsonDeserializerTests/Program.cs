
using System.Text.Json;

var jsonPath = "D:\\buddhika\\projects\\C#Practise\\UltimateCSharpMasterclass\\Solution\\JsonDeserializerTests\\person.json";
var options = new JsonSerializerOptions
{
    WriteIndented = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
};
var jsonString = File.ReadAllText(jsonPath);

var person = JsonSerializer.Deserialize<Person>(jsonString, options);
Console.WriteLine(person);
