namespace CookieCookbook
{
    public class Recipes
    {
        private readonly List<Recipe> _list = new();

        public Recipes()
        {
        }

        public Recipes(List<string> recipesIngredientIds, Ingredients ingredients)
        {
            foreach (var ingredientsForRecipe in recipesIngredientIds)
            {
                var ingredientIds = ingredientsForRecipe.Split(',');
                var recipe = GetRecipeByIngredientIds(ingredients, ingredientIds);
                if (recipe != null)
                    _list.Add(recipe);
            }
        }

        private Recipe? GetRecipeByIngredientIds(Ingredients ingredients, string[] ingredientIds)
        {
            Recipe? recipe = null;
            foreach (var id in ingredientIds)
            {
                if (int.TryParse(id, out var ingredientId))
                {
                    var ingredient = ingredients.Find(ingredientId);
                    if (ingredient != null)
                    {
                        if (recipe == null)
                        {
                            recipe = new Recipe();
                        }

                        recipe.Add(ingredient);
                    }
                }
            }
            return recipe;
        }

        public void Add(Recipe recipe) => _list.Add(recipe);

        public bool HasAny() => _list.Any();

        public override string ToString()
        {
            var str = string.Empty;
            for (var i = 0; i < _list.Count; i++)
            {
                str += $"\n**** {i + 1} ****\n{_list[i]}\n";
            }

            return str;
        }
    }
}
