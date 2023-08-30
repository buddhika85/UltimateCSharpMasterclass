using CookieCookbookModelAnswer.Recipes;
using CookieCookbookModelAnswer.Recipes.Ingredients;

namespace CookieCookbookModelAnswer.App;

public interface IRecipesUserInteraction
{
    public void ShowMessage(string message);
    public void PromptToCreateRecipe();
    public void Exit();

    void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
    IEnumerable<Ingredient> ReadIngredientsFromUser();
}