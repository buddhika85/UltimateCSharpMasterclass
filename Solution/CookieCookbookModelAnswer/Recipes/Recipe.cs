using CookieCookbookModelAnswer.Recipes.Ingredients;

namespace CookieCookbookModelAnswer.Recipes
{
    public class Recipe
    {
        public IEnumerable<Ingredient> Ingredients { get; }

        public Recipe(IEnumerable<Ingredient> ingredients)
        {
            Ingredients = ingredients;
        }

        public override string ToString()
        {
            var steps = new List<string>();
            foreach (var ingredient in Ingredients)
            {
                steps.Add($"{ingredient.Name}. {ingredient.PreparationInstructions}");
            }
            return string.Join(Environment.NewLine, steps);
        }
    }
}
