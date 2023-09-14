using JsonDeserializerTests.Models;
using System.Text.Json;

//ReadStaticJson();
await ReadFromWeatherApi();

async Task ReadFromWeatherApi()
{
    var options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };

    using HttpClient client = new()
    {
        BaseAddress = new Uri("https://localhost:7241")
    };

    var response = await client.GetAsync("weatherforecast");
    if (response.IsSuccessStatusCode)
    {
        var temperatures =
            await JsonSerializer.DeserializeAsync<Temperature[]>(await response.Content.ReadAsStreamAsync(), options);

        if (temperatures == null) return;

        foreach (var temperature in temperatures)
        {
            Console.WriteLine($"{temperature.Summary}");
        }
    }
    else
    {
        Console.WriteLine($"Whoops ! Error: {response.StatusCode}");
    }
}

void ReadStaticJson()
{
    var jsonPath = "D:\\buddhika\\projects\\C#Practise\\UltimateCSharpMasterclass\\Solution\\JsonDeserializerTests\\person.json";
    var options = new JsonSerializerOptions
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };
    var jsonString = File.ReadAllText(jsonPath);

    var person = JsonSerializer.Deserialize<Person>(jsonString, options);
    Console.WriteLine(person);

}
