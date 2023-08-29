namespace CookieCookbook.UserCommunication
{
    public class TxtRecipesManager : RecipesManager
    {
        public TxtRecipesManager(string recipesPath) : base(recipesPath)
        { }
        public override List<string>? ReadRecipes()
        {
            throw new NotImplementedException();
        }

        public override void WriteRecipes(string ingredientIds)
        {
            throw new NotImplementedException();
        }
    }
}
