namespace CookieCookbook
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Instruction { get; set; } = null!;

        public bool Matches(int id) => Id == id;

        public override string ToString() => $"{Id}. {Name}";
    }
}