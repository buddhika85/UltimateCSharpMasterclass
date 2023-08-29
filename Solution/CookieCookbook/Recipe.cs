namespace CookieCookbook;

public class Recipe
{
    public List<Ingredient> Ingredients { get; private set; }

    public Recipe()
    {
        Ingredients = new List<Ingredient>();
    }

    public Recipe(List<Ingredient> ingredients)
    {
        Ingredients = ingredients;
    }

    public void Add(Ingredient ingredient)
    {
        Ingredients.Add(ingredient);
    }

    public override string ToString()
    {
        var str = string.Empty;
        foreach (var item in Ingredients)
        {
            str += $"{item.Name}. {item.Instruction}\n";
        }
        return str;
    }
}