namespace DesignPatterns.FactoryMethod
{
    public class FactoryMethodDemo
    {
        private readonly IIceCreamFactory _iceCreamFactory;
        public FactoryMethodDemo(IIceCreamFactory iceCreamFactory)
        {
            _iceCreamFactory = iceCreamFactory;
        }
        public IceCream? GetIceCreamForCustomer(List<string> customerAsked)
        {
            return _iceCreamFactory.Prepare(customerAsked);
        }
    }

    public abstract class IceCream
    {
        public List<string> Ingredients { get; }

        protected IceCream(List<string> ingredients)
        {
            Ingredients = ingredients;
        }

        public void AddIngredient(string ingredient)
            => Ingredients.Add(ingredient);
    }

    public class VanillaIceCream : IceCream
    {
        public static readonly List<string> DefaultIngredients =
            new() { "Cream", "Sugar", "Vanilla" };

        public VanillaIceCream() : base(DefaultIngredients) { }
    }

    public class ChocolateIceCream : IceCream
    {
        public static readonly List<string> DefaultIngredients =
            new() { "Cream", "Sugar", "Chocolate" };

        public ChocolateIceCream() : base(DefaultIngredients) { }
    }

    public interface IIceCreamFactory
    {
        public IceCream? Prepare(List<string> ingredients);
    }

    public class IceCreamFactory
    {
        public IceCream? Prepare(List<string> ingredients)
        {
            if (Enumerable.SequenceEqual(ingredients, VanillaIceCream.DefaultIngredients))
                return new VanillaIceCream();
            if (Enumerable.SequenceEqual(ingredients, ChocolateIceCream.DefaultIngredients))
                return new ChocolateIceCream();
            return null;
        }
    }
}
