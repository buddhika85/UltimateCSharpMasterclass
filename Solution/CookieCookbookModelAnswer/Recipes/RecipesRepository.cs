using CookieCookbookModelAnswer.DataAccess;
using CookieCookbookModelAnswer.Recipes.Ingredients;

namespace CookieCookbookModelAnswer.Recipes;

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