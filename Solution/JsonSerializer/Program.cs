
using JsonSerializerTests.Models;
using System.Text.Json;

var person = new Person
{
    Id = 1,
    FirstName = "Sean",
    LastName = "Connery",
    Age = 90,
    IsAlive = false
};

var jsonFilePath = "D:\\buddhika\\projects\\C#Practise\\UltimateCSharpMasterclass\\Solution\\JsonSerializer\\person.json";
var jsonString = JsonSerializer.Serialize(person);
File.WriteAllText(jsonFilePath, jsonString);

Console.WriteLine(File.ReadAllText(jsonFilePath));