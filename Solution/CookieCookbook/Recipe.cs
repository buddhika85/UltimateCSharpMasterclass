namespace CookieCookbook;

public class Recipe
{
    private readonly List<Ingredient> _ingredients = new();

    public void Add(Ingredient ingredient)
    {
        _ingredients.Add(ingredient);
    }

    public override string ToString()
    {
        var str = string.Empty;
        foreach (var item in _ingredients)
        {
            str += $"{item.Name}. {item.Instruction}\n";
        }
        return str;
    }
}