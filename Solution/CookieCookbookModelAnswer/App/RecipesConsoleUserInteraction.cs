using CookieCookbookModelAnswer.Recipes;
using CookieCookbookModelAnswer.Recipes.Ingredients;

namespace CookieCookbookModelAnswer.App;

public class RecipesConsoleUserInteraction : IRecipesUserInteraction
{
    private readonly IIngredientRegister _ingredientRegister;

    public RecipesConsoleUserInteraction(IIngredientRegister ingredientRegister)
    {
        _ingredientRegister = ingredientRegister;
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void PromptToCreateRecipe()
    {
        Console.WriteLine($"{Environment.NewLine}Create a new cookie recipe! Available ingredients are:");
        foreach (var ingredient in _ingredientRegister.All)
        {
            Console.WriteLine(ingredient);
        }
    }

    public void Exit()
    {
        Console.WriteLine("Press any key to close.");
        Console.ReadKey();
    }

    public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)
    {
        if (allRecipes.Any())
        {
            Console.WriteLine($"Existing recipes are: {Environment.NewLine}");
            var count = 1;
            foreach (var recipe in allRecipes)
            {
                Console.WriteLine($"{Environment.NewLine}**** {count++} ****{Environment.NewLine}{recipe}{Environment.NewLine}");
            }
        }
    }

    public IEnumerable<Ingredient> ReadIngredientsFromUser()
    {
        var shallStop = false;
        var ingredients = new List<Ingredient>();
        while (!shallStop)
        {
            Console.WriteLine("\nAdd an ingredient by its ID or type anything else if finished.");
            var input = Console.ReadLine();
            if (int.TryParse(input, out var id))
            {
                var selected = _ingredientRegister.GetById(id);
                if (selected is not null)
                    ingredients.Add(selected);
            }
            else
            {
                shallStop = true;
            }
        }

        return ingredients;
    }
}