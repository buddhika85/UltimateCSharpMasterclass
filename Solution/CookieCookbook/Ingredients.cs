namespace CookieCookbook;

public class Ingredients
{
    private int _id;
    private readonly List<Ingredient> _list = new();

    public void Add(string name, string instruction) =>
        _list.Add(new Ingredient { Id = ++_id, Name = name, Instruction = instruction });

    public void Add(Ingredient ingredient) => _list.Add(ingredient);

    public Ingredient? Find(int id) => _list.SingleOrDefault(x => x.Matches(id));

    public override string ToString()
    {
        var str = string.Empty;
        foreach (var item in _list)
        {
            str += $"{item}\n";
        }
        return str;
    }
}