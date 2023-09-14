
using JsonSerializerTests.Helpers;
using JsonSerializerTests.Models;
using System.Text.Json;

var person = new Person
{
    Id = 1,
    FirstName = "Sean",
    LastName = "Connery",
    Age = 90,
    IsAlive = false,
    Address = new Address
    {
        StreetName = "1 main street",
        City = "New York",
        ZipCode = "12345"
    },
    Phones = new List<Phone>
    {
        new Phone
        {
            PhoneType = "Home",
            PhoneNumber = "33344455566"
        },
        new Phone
        {
            PhoneType = "Mobile",
            PhoneNumber = "028888888888"
        }
    }
};

var jsonFilePath = "D:\\buddhika\\projects\\C#Practise\\UltimateCSharpMasterclass\\Solution\\JsonSerializer\\person.json";
var options = new JsonSerializerOptions
{
    WriteIndented = true,
    PropertyNamingPolicy = new LowerCaseNamingPolicy() //JsonNamingPolicy.CamelCase
};

var jsonString = JsonSerializer.Serialize<Person>(person, options);
File.WriteAllText(jsonFilePath, jsonString);

Console.WriteLine(File.ReadAllText(jsonFilePath));