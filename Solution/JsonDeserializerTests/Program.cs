using JsonDeserializerTests.Models;
using System.Net.Http.Json;
using System.Text.Json;

//ReadStaticJson();
//await ReadFromWeatherApi();
await ReadFromWeatherApiUsingExtensionMethods();
//await ReadFromWeatherApiUsingJsonDocument();

async Task ReadFromWeatherApiUsingJsonDocument()
{
    using HttpClient client = new()
    {
        BaseAddress = new Uri("https://localhost:7241")
    };
    var response = await client.GetAsync("weatherforecast");

    if (response.IsSuccessStatusCode)
    {
        var jsonString = await response.Content.ReadAsStringAsync();
        using (var jsonDocument = JsonDocument.Parse(jsonString))
        {
            var root = jsonDocument.RootElement;
            //Console.WriteLine($"{root.ValueKind}");
            foreach (var temperature in root.EnumerateArray())
            {
                Console.WriteLine(temperature.GetProperty("Summary").ToString());
            }
        }
    }
    else
    {
        Console.WriteLine($"Whoops ! Error: {response.StatusCode}");
    }
}

async Task ReadFromWeatherApiUsingExtensionMethods()
{
    var options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };

    using HttpClient client = new()
    {
        BaseAddress = new Uri("https://localhost:7241")
    };

    var temperatures = await client.GetFromJsonAsync<Temperature[]>("weatherforecast", options);
    if (temperatures == null) return;

    foreach (var temperature in temperatures)
    {
        Console.WriteLine($"{temperature.Summary}");
    }
}


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
