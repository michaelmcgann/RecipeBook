namespace RecipeApp;

public class Recipes {

    public List<Recipe> RecipesList { get; set; }

    public Recipes() {
        RecipesList = new List<Recipe>();
    }

    public Recipes(List<Recipe> recipes) {
        RecipesList = recipes;
    }

    public void AddRecipe(Recipe recipe, string filePath) {
        RecipesList.Add(recipe);
        SaveRecipes(filePath);
        
    }

    public string DisplayRecipes() {
        string result = "";
        for (int i = 0; i < RecipesList.Count; i++) {
            result += $"******* {i + 1}. {RecipesList[i].Name} *******\n" +
                      $"{RecipesList[i].Display()}\n";
        }

        return result;
    }

    public void SaveRecipes(string filePath) {
        FileManager.SaveToFile(filePath, this);
    }

    public static Recipes LoadRecipes(string filePath) {
        return FileManager.LoadFromFile(filePath);
    }
}