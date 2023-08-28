namespace CookieCookbook
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Instruction { get; set; } = null!;

        public override string ToString() => $"{Id}. {Name}";
    }

    public class Ingredients
    {
        private int _id;
        public List<Ingredient> List { get; set; } = new();

        public void Add(string name, string instruction) =>
            List.Add(new Ingredient { Id = ++_id, Name = name, Instruction = instruction });

        public override string ToString()
        {
            var str = string.Empty;
            foreach (var item in List)
            {
                str += $"{item}\n";
            }
            return str;
        }
    }

    public class Recipe
    {
        public Ingredients Ingredients { get; set; } = null!;
    }
}
