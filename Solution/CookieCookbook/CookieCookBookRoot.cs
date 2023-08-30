using CookieCookbook.Data;
using CookieCookbook.Extensions;
using CookieCookbook.FileManagement;
using static System.Console;

namespace CookieCookbook
{
    public class CookieCookBookRoot
    {
        private readonly IRecipesManager _recipesManager = null!;
        private readonly Ingredients _ingredients = new();
        private Recipes _recipes = null!;
        private readonly string? _recipesPath;

        public CookieCookBookRoot(FileFormat saveFormat)
        {
            try
            {
                var ingredientsJsonFilePath = $"D:\\buddhika\\projects\\C#Practise\\UltimateCSharpMasterclass\\Solution\\CookieCookbook\\IngredientsData.json";
                _recipesPath =
                    $"D:\\buddhika\\projects\\C#Practise\\UltimateCSharpMasterclass\\Solution\\CookieCookbook\\Recipes{saveFormat.GetFileExtension()}";

                IngredientsLoader.LoadIngredients(_ingredients, ingredientsJsonFilePath);

                _recipesManager = saveFormat == FileFormat.Json
                    ? new JsonRecipesManager(_recipesPath)
                    : new TxtRecipesManager(_recipesPath);

                LoadRecipes();
                RunMenu();
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }

        private void LoadRecipes()
        {
            if (!File.Exists(_recipesPath))
            {
                _recipes = new Recipes();
                return;     // no recipes yet
            }
            var recipeIngredients = _recipesManager.ReadRecipes();
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

        private void DisplayRecipes()
        {
            WriteLine("Existing recipes are:");
            WriteLine(_recipes);
        }

        private void DisplayIngredients()
        {
            WriteLine(_ingredients.ToString());
        }


        private void SaveRecipe(Recipe recipe)
        {
            var ingredientIds = recipe.GetIngredientIdsCsv();
            if (ingredientIds != null)
            {
                _recipesManager.WriteRecipes(ingredientIds);
                _recipes.Add(recipe);
            }
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

        private void DisplayIngredients(Recipe recipe)
        {
            WriteLine(recipe);
        }
    }
}
