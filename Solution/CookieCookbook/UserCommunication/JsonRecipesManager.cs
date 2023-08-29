using System.Text.Json;

namespace CookieCookbook.UserCommunication
{
    public class JsonRecipesManager : RecipesManager
    {

        private readonly JsonSerializerOptions _options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public JsonRecipesManager(string recipesPath) : base(recipesPath)
        { }


        public override List<string>? ReadRecipes()
        {
            return JsonSerializer.Deserialize<List<string>>(File.ReadAllText(RecipesPath), _options) ??
                   null;
        }

        public override void WriteRecipes(string ingredientIds)
        {
            List<string>? recipeIngredients = null;
            if (File.Exists(RecipesPath))
                recipeIngredients = ReadRecipes();
            if (recipeIngredients == null)
                recipeIngredients = new List<string>();
            recipeIngredients.Add(ingredientIds);
            var updatedJson = JsonSerializer.Serialize(recipeIngredients, _options);
            File.WriteAllText(RecipesPath, updatedJson);
        }
    }
}
