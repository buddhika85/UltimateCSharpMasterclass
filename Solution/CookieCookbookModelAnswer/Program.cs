using CookieCookbookModelAnswer.Recipes;
using CookieCookbookModelAnswer.Recipes.Ingredients;
using static System.Console;

var cookieRecipesApp = new CookieRecipesApp(new RecipesRepository(), new RecipesConsoleUserInteraction(new IngredientRegister()));
cookieRecipesApp.Run("recipes.txt");

public class CookieRecipesApp
{
    private readonly IRecipesRepository _recipesRepository;
    private readonly IRecipesUserInteraction _recipesUserInteraction;

    public CookieRecipesApp(IRecipesRepository recipesRepository, IRecipesUserInteraction recipesUserInteraction)
    {
        _recipesRepository = recipesRepository;
        _recipesUserInteraction = recipesUserInteraction;
    }

    public void Run(string filePath)
    {
        var allRecipes = _recipesRepository.Read(filePath);
        _recipesUserInteraction.PrintExistingRecipes(allRecipes);

        _recipesUserInteraction.PromptToCreateRecipe();

        //var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();
        //if (ingredients.Count > 0)
        //{
        //    var recipe = new Recipe(ingredients);
        //    allRecipes.Add(recipe);
        //    _recipesRepository.Write(filePath, allRecipes);
        //    _recipesUserInteraction.ShowMessage("Recipe added");
        //    _recipesUserInteraction.ShowMessage(recipe.ToString());
        //}
        //else
        //{
        //    _recipesUserInteraction.ShowMessage(
        //        "No ingredients have been selected. Recipe will not be saved."
        //        );
        //}

        _recipesUserInteraction.Exit();
    }
}

public interface IRecipesRepository
{
    List<Recipe> Read(object filePath);
}

public class RecipesRepository : IRecipesRepository
{


    public List<Recipe> Read(object filePath)
    {
        return new List<Recipe>
        {
            new(new List<Ingredient>
            {
                new WheatFlour(),
                new Butter(),
                new Sugar()
            }),
            new(new List<Ingredient>
            {
                new CocoaPowder(),
                new CoconutFlour(),
                new Cinnamon()
            }),
        };
    }

}

public interface IRecipesUserInteraction
{
    public void ShowMessage(string message);
    public void PromptToCreateRecipe();
    public void Exit();

    void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
}

public class RecipesConsoleUserInteraction : IRecipesUserInteraction
{
    private readonly IngredientRegister _ingredientRegister;

    public RecipesConsoleUserInteraction(IngredientRegister ingredientRegister)
    {
        _ingredientRegister = ingredientRegister;
    }

    public void ShowMessage(string message)
    {
        WriteLine(message);
    }

    public void PromptToCreateRecipe()
    {
        WriteLine($"{Environment.NewLine}Create a new cookie recipe! Available ingredients are:");
        foreach (var ingredient in _ingredientRegister.All)
        {
            WriteLine(ingredient);
        }
    }

    public void Exit()
    {
        WriteLine("Press any key to close.");
        ReadKey();
    }

    public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)
    {
        if (allRecipes.Any())
        {
            WriteLine($"Existing recipes are: {Environment.NewLine}");
            var count = 1;
            foreach (var recipe in allRecipes)
            {
                WriteLine($"{Environment.NewLine}**** {count++} ****{Environment.NewLine}{recipe}{Environment.NewLine}");
            }
        }
    }
}

public class IngredientRegister
{
    public IEnumerable<Ingredient> All { get; } = new List<Ingredient>
    {
        new WheatFlour(),
        new CoconutFlour(),
        new Butter(),
        new Chocolate(),
        new Sugar(),
        new Cardamom(),
        new Cinnamon(),
        new CocoaPowder()
    };
}

