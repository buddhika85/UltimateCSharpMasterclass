using CookieCookbook.Extensions;
using System.Text.Json;
using static System.Console;

namespace CookieCookbook
{
    public class CookieCookBookRoot
    {
        private const FileFormat SaveFormat = CookieCookbook.FileFormat.Json;
        private readonly Ingredients _ingredients = new();
        private Recipes _recipes = null!;
        private readonly JsonSerializerOptions _options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        private readonly string _jsonFilePath =
            $"D:\\buddhika\\projects\\C#Practise\\UltimateCSharpMasterclass\\Solution\\CookieCookbook\\IngredientsData{SaveFormat.GetFileExtension()}";
        private readonly string _recipesPath =
            $"D:\\buddhika\\projects\\C#Practise\\UltimateCSharpMasterclass\\Solution\\CookieCookbook\\Recipes{SaveFormat.GetFileExtension()}";

        public CookieCookBookRoot()
        {
            try
            {
                LoadIngredients();
                LoadRecipes();
                RunMenu();
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
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

        private void LoadRecipes()
        {
            if (!File.Exists(_recipesPath))
            {
                _recipes = new Recipes();
                return;     // no recipes yet
            }
            var recipeIngredients = JsonSerializer.Deserialize<List<string>>(File.ReadAllText(_recipesPath), _options);
            _recipes = recipeIngredients != null ? new Recipes(recipeIngredients, _ingredients) : new Recipes();
        }

        private void RunMenu()
        {
            if (_recipes.HasAny())
            {
                DisplayRecipes();
            }

            WriteLine("\nCreate a new cookie recipe! Available ingredients are:");

            DisplayIngredients();
            var recipe = CreateRecipe();
            if (recipe != null)
            {
                SaveRecipe(recipe);
                WriteLine("Recipe added:");
                DisplayIngredients(recipe);
            }
            else
            {
                WriteLine("Recipe not created");
            }


            WriteLine("\n");
        }

        private void SaveRecipe(Recipe recipe)
        {
            _recipes.Add(recipe);

            string? ingredientIds = null;
            foreach (var ingredient in recipe.Ingredients)
            {
                if (ingredientIds == null)
                {
                    ingredientIds += $"{ingredient.Id}";
                }
                else
                {
                    ingredientIds += $",{ingredient.Id}";
                }
            }

            if (ingredientIds != null)
            {
                List<string>? recipeIngredients = null;
                if (File.Exists(_recipesPath))
                    recipeIngredients = JsonSerializer.Deserialize<List<string>>(File.ReadAllText(_recipesPath), _options);
                if (recipeIngredients == null)
                    recipeIngredients = new List<string>();
                recipeIngredients.Add(ingredientIds);
                var updatedJson = JsonSerializer.Serialize(recipeIngredients, _options);
                File.WriteAllText(_recipesPath, updatedJson);
            }

        }

        private void DisplayRecipes()
        {
            WriteLine("Existing recipes are:");
            WriteLine(_recipes);
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


    }
}
