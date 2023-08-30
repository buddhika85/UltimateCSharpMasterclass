using CookieCookbookModelAnswer.App;
using CookieCookbookModelAnswer.DataAccess;
using CookieCookbookModelAnswer.FileAccess;
using CookieCookbookModelAnswer.Recipes;
using CookieCookbookModelAnswer.Recipes.Ingredients;


const FileFormat format = FileFormat.Json;
IStringsRepository stringsRepository = format == FileFormat.Json ?
    new StringsJsonRepository() :
    new StringsTextualRepository();
var fileMetaData = new FileMetaData("recipes", format);
var ingredientRegister = new IngredientRegister();
var cookieRecipesApp = new CookieRecipesApp(
        new RecipesRepository(
            stringsRepository,
            ingredientRegister),
        new RecipesConsoleUserInteraction(
            ingredientRegister));
cookieRecipesApp.Run(fileMetaData.ToPath());