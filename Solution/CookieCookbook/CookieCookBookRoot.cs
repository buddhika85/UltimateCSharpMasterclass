using System.Text.Json;
using static System.Console;

namespace CookieCookbook
{
    public class CookieCookBookRoot
    {
        private const FileFormat FileFormat = CookieCookbook.FileFormat.Json;
        private readonly Ingredients _ingredients = new();
        private readonly JsonSerializerOptions _options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        private readonly string _jsonFilePath = $"D:\\buddhika\\projects\\C#Practise\\UltimateCSharpMasterclass\\Solution\\CookieCookbook\\IngredientsData.json";

        public CookieCookBookRoot()
        {
            try
            {
                LoadIngredients();
                RunMenu();
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }

        private void RunMenu()
        {
            WriteLine("\nCreate a new cookie recipe! Available ingredients are:");
            DisplayIngredients();
            var recipe = CreateRecipe();
            if (recipe != null)
            {
                WriteLine("Recipe added:");
                DisplayIngredients(recipe);
            }
            else
            {
                WriteLine("Recipe not created");
            }


            WriteLine("\n");
        }

        private Recipe? CreateRecipe()
        {
            Recipe? recipe = null;
            var addMore = true;
            do
            {
                var ingredientId = ReadIngredientId();
                if (ingredientId == null)
                    addMore = false;  // end of recipe creation, not an int
                else
                {
                    var ingredient = _ingredients.Find(ingredientId.Value);
                    if (ingredient != null)
                    {
                        if (recipe == null)
                            recipe = new Recipe();
                        recipe.Add(ingredient);
                    }
                }
            } while (addMore);
            return recipe;
        }

        private int? ReadIngredientId()
        {
            WriteLine("\nAdd an ingredient by its ID or type anything else if finished.");
            var input = ReadLine();
            if (input == null)
            {
                return null;
            }

            if (!int.TryParse(input, out var id))
            {
                return null;
            }
            return id;
        }

        private void DisplayIngredients()
        {
            WriteLine(_ingredients.ToString());
        }

        private void DisplayIngredients(Recipe recipe)
        {
            WriteLine(recipe.ToString());
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
                _ingredients.Add(ingredient.Name, ingredient.Instruction);
            }
        }
    }
}
