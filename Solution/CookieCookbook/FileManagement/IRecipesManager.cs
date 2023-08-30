namespace CookieCookbook.FileManagement
{
    public interface IRecipesManager
    {
        public List<string>? ReadRecipes();
        public void WriteRecipes(string ingredientIds);
    }
}
