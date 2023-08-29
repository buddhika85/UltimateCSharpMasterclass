namespace CookieCookbook.UserCommunication
{
    public interface IRecipesManager
    {
        public List<string>? ReadRecipes();
        public void WriteRecipes(string ingredientIds);
    }
}
