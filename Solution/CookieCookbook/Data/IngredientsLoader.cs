using System.Text.Json;

namespace CookieCookbook.Data
{
    public static class IngredientsLoader
    {
        private static readonly JsonSerializerOptions Options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public static void LoadIngredients(Ingredients ingredients, string jsonFilePath)
        {
            if (!File.Exists(jsonFilePath))
                throw new Exception($"{jsonFilePath} - JSON file unavailable");
            var ingredientsData = JsonSerializer.Deserialize<List<Ingredient>>(File.ReadAllText(jsonFilePath), Options);
            if (ingredientsData == null)
                throw new Exception($"{jsonFilePath} - JSON invalid");
            foreach (var ingredient in ingredientsData)
            {
                ingredients.Add(ingredient.Name, ingredient.Instruction);
            }
        }
    }
}
