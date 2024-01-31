namespace DesignPatterns.FactoryMethod
{
    public class FactoryMethodDemo
    {
    }

    public abstract class IceCream
    {
        public List<string> Ingredients { get; }

        protected IceCream(List<string> ingredients)
        {
            Ingredients = ingredients;
        }

        public void AddIngredient(string ingredient)
        {
            Ingredients.Add(ingredient);
        }
    }

    public class VanillaIceCream : IceCream
    {
        private static readonly List<string> DefaultIngredients =
            new() { "Cream", "Sugar", "Vanilla" };

        public VanillaIceCream() : base(DefaultIngredients) { }
    }

    public class IceCreamFactory
    {
        public IceCream? Prepare(List<string> ingredients)
        {
            //if (Enumerable.SequenceEqual(ingredients, ));
            return null;
        }
    }
}
