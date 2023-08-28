using System.Text.Json;
using static System.Console;

namespace CookieCookbook
{
    public class CookieCookBookRoot
    {
        private readonly Ingredients _ingredients = new();
        private readonly JsonSerializerOptions _options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        private readonly string _jsonFilePath = $"D:\\buddhika\\projects\\C#Practise\\UltimateCSharpMasterclass\\Solution\\CookieCookbook\\IngredientsData.json";

        public CookieCookBookRoot()
        {
            LoadIngredients();
            RunMenu();
        }

        private void RunMenu()
        {
            DisplayIngredients();
        }

        private void DisplayIngredients()
        {
            WriteLine(_ingredients.ToString());
        }

        private void LoadIngredients()
        {
            if (!File.Exists(_jsonFilePath))
                throw new Exception($"{_jsonFilePath} - JSON file unavailable");
            var ingredientsData = JsonSerializer.Deserialize<List<Ingredient>>(File.ReadAllText(_jsonFilePath), _options);
            if (ingredientsData == null)
                throw new Exception($"{_jsonFilePath} - JSON invalid");
            foreach (var ingredient in ingredientsData)
            {
                _ingredients.Add(ingredient.Name, ingredient.Name);
            }
        }
    }
}
