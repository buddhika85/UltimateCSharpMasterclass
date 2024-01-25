using static System.Console;

namespace DesignPatterns.Adapter
{
    public static class AdapterDemo
    {
        public static void Test()
        {
            Client client = new();
            client.DisplayCustomers("London");
            client.DisplayCustomers("NewYork");
        }
    }

    public class Customer
    {
        public string Name { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public override string ToString()
        {
            return $"{Name}:{ZipCode}";
        }
    }

    // Client
    public class Client
    {
        private CustomersByCityAdapter _adapter = new();

        // client works with city name
        public void DisplayCustomers(string cityName)
        {
            WriteLine($"\nCustomers of {cityName}");
            var customers = _adapter.FindCustomers(cityName);
            foreach (var customer in customers)
            {
                WriteLine(customer);
            }
        }
    }

    // Supplier
    public class Supplier
    {
        private readonly List<Customer> _customers = new()
        {
            new Customer { Name = "Jack", ZipCode = "ABC123" },
            new Customer { Name = "Gill", ZipCode = "ABC456" },
            new Customer { Name = "James", ZipCode = "DEF123" }
        };

        // supplier works with zip code
        public IEnumerable<Customer> FindCustomers(string zipCode)
        {
            return _customers.Where(x => x.ZipCode == zipCode);
        }
    }

    // Adapter
    public class CustomersByCityAdapter
    {
        // supplier / adaptee object
        private readonly Supplier _supplier = new Supplier();

        // adapting code
        public IEnumerable<Customer> FindCustomers(string cityName)
        {
            WriteLine($"------------------>LOG: Finding zip codes for {cityName}");
            // adapting city name to zip code - find zip codes for city
            IEnumerable<string> zipCodesByCity = FindZipCodesByCity(cityName);
            WriteLine($"------------------>LOG: Found: {string.Join(",", zipCodesByCity)}");
            // now use supplier
            return zipCodesByCity.SelectMany(x => _supplier.FindCustomers(x));
        }

        // helper - find city name by zip code
        private IEnumerable<string> FindZipCodesByCity(string cityName)
        {
            var zipCodesWithCities = new List<(string, string)>
            {
                new ("London", "ABC123"),  new ("London", "ABC456"),
                new ("NewYork", "DEF123")
            };
            return zipCodesWithCities.Where(x => x.Item1 == cityName).Select(x => x.Item2);
        }
    }
}