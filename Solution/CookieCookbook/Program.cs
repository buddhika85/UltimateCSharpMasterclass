using CookieCookbook;
using static System.Console;

WriteLine("Hello, Welcome to Cookie cookbook!");

var ingredientsJsonPath = "D:\\buddhika\\projects\\C#Practise\\UltimateCSharpMasterclass\\Solution\\CookieCookbook\\IngredientsData.json";
var recipeFilePath = "D:\\buddhika\\projects\\C#Practise\\UltimateCSharpMasterclass\\Solution\\CookieCookbook";


//new CookieCookBookRoot(ingredientsJsonPath, recipeFilePath, FileFormat.Json);
new CookieCookBookRoot(ingredientsJsonPath, recipeFilePath, FileFormat.Txt);
