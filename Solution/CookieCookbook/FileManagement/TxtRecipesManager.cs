namespace CookieCookbook.FileManagement
{
    public class TxtRecipesManager : RecipesManager
    {
        public TxtRecipesManager(string recipesPath) : base(recipesPath)
        { }
        public override List<string>? ReadRecipes()
        {
            return File.ReadAllLines(RecipesPath).ToList();
        }

        public override void WriteRecipes(string ingredientIds)
        {
            var txtStr = string.Empty;
            if (File.Exists(RecipesPath))
                txtStr = File.ReadAllText(RecipesPath);
            txtStr = $"{txtStr}{ingredientIds}{Environment.NewLine}";
            File.WriteAllText(RecipesPath, txtStr);
        }
    }
}
