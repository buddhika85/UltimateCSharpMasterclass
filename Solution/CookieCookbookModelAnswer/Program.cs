using CookieCookbookModelAnswer.Recipes;
using CookieCookbookModelAnswer.Recipes.Ingredients;
using System.Text.Json;
using static System.Console;

var ingredientRegister = new IngredientRegister();
var cookieRecipesApp = new CookieRecipesApp(
        new RecipesRepository(
            //new StringsTextualRepository(), 
            new StringsJsonRepository(),
            ingredientRegister),
        new RecipesConsoleUserInteraction(
            ingredientRegister));
//cookieRecipesApp.Run("recipes.txt");
cookieRecipesApp.Run("recipes.json");

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

        var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();
        if (ingredients.Any())
        {
            var recipe = new Recipe(ingredients);
            allRecipes.Add(recipe);
            _recipesRepository.Write(filePath, allRecipes);
            _recipesUserInteraction.ShowMessage("Recipe added");
            _recipesUserInteraction.ShowMessage(recipe.ToString());
        }
        else
        {
            _recipesUserInteraction.ShowMessage(
                "No ingredients have been selected. Recipe will not be saved."
                );
        }

        _recipesUserInteraction.Exit();
    }
}

public interface IRecipesRepository
{
    List<Recipe> Read(string filePath);
    void Write(string filePath, List<Recipe> allRecipes);
}

public class RecipesRepository : IRecipesRepository
{
    private readonly IIngredientRegister _ingredientRegister;
    private readonly IStringsRepository _stringsRepository;
    private const char Separator = ',';

    public RecipesRepository(IStringsRepository stringsRepository, IIngredientRegister ingredientRegister)
    {
        _stringsRepository = stringsRepository;
        _ingredientRegister = ingredientRegister;
    }

    public List<Recipe> Read(string filePath)
    {
        var recipes = new List<Recipe>();
        var recipesFromFile = _stringsRepository.Read(filePath);
        foreach (var recipeStr in recipesFromFile)
        {

            recipes.Add(RecipeFromString(recipeStr));
        }
        return recipes;
    }

    private Recipe RecipeFromString(string recipeStr)
    {
        var allIds = recipeStr.Split(Separator);
        var ingredients = new List<Ingredient>();
        foreach (var idStr in allIds)
        {
            var ingredient = _ingredientRegister.GetById(int.Parse(idStr));
            if (ingredient is not null)
                ingredients.Add(ingredient);
        }

        return new Recipe(ingredients);
    }

    public void Write(string filePath, List<Recipe> allRecipes)
    {
        var recipesAsStrings = new List<string>();
        foreach (var recipe in allRecipes)
        {
            var allIds = new List<int>();
            foreach (var ingredient in recipe.Ingredients)
            {
                allIds.Add(ingredient.Id);
            }
            recipesAsStrings.Add(string.Join(Separator, allIds));
        }
        _stringsRepository.Write(filePath, recipesAsStrings);
    }
}

public interface IRecipesUserInteraction
{
    public void ShowMessage(string message);
    public void PromptToCreateRecipe();
    public void Exit();

    void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
    IEnumerable<Ingredient> ReadIngredientsFromUser();
}

public class RecipesConsoleUserInteraction : IRecipesUserInteraction
{
    private readonly IIngredientRegister _ingredientRegister;

    public RecipesConsoleUserInteraction(IIngredientRegister ingredientRegister)
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

    public IEnumerable<Ingredient> ReadIngredientsFromUser()
    {
        var shallStop = false;
        var ingredients = new List<Ingredient>();
        while (!shallStop)
        {
            WriteLine("\nAdd an ingredient by its ID or type anything else if finished.");
            var input = ReadLine();
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

public interface IIngredientRegister
{
    public IEnumerable<Ingredient> All { get; }
    public Ingredient? GetById(int id);
}

public class IngredientRegister : IIngredientRegister
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

    public Ingredient? GetById(int id)
    {
        foreach (var ingredient in All)
        {
            if (ingredient.Id == id)
                return ingredient;
        }
        return null;
    }
}

public interface IStringsRepository
{
    public List<string> Read(string filePath);
    public void Write(string filePath, List<string> strings);
}

public class StringsTextualRepository : IStringsRepository
{
    private static readonly string Separator = Environment.NewLine;

    public List<string> Read(string filePath)
    {
        if (File.Exists(filePath))
        {
            var fileContents = File.ReadAllText(filePath);
            return fileContents.Split(Separator).ToList();
        }

        return new List<string>();
    }

    public void Write(string filePath, List<string> strings)
    {
        File.WriteAllText(filePath, string.Join(Separator, strings));
    }
}


public class StringsJsonRepository : IStringsRepository
{
    public List<string> Read(string filePath)
    {
        if (File.Exists(filePath))
        {
            var fileContents = File.ReadAllText(filePath);
            var result = JsonSerializer.Deserialize<List<string>>(fileContents);
            if (result is not null)
                return result;
        }

        return new List<string>();
    }

    public void Write(string filePath, List<string> strings)
    {
        File.WriteAllText(filePath, JsonSerializer.Serialize(strings));
    }
}