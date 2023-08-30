namespace CookieCookbookModelAnswer.Recipes.Ingredients;

public interface IIngredientRegister
{
    public IEnumerable<Ingredient> All { get; }
    public Ingredient? GetById(int id);
}