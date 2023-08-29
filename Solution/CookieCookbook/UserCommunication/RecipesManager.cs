namespace CookieCookbook.UserCommunication
{
    public abstract class RecipesManager : IRecipesManager
    {
        protected readonly string RecipesPath;

        protected RecipesManager(string recipesPath)
        {
            RecipesPath = recipesPath;
        }

        public abstract List<string>? ReadRecipes();


        public abstract void WriteRecipes(string ingredientIds);
    }
}
