namespace RecipeApp;

public class Recipes {

    public List<Recipe> RecipesList { get; set; }
    private readonly string _filePath;

    public Recipes(string filePath) {
        _filePath = filePath;
        RecipesList = new List<Recipe>();
    }

    public void AddRecipe(Recipe recipe) {
        RecipesList.Add(recipe);
        SaveRecipes(_filePath);
        
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
        RecipeFileManager.SaveToFile(_filePath, this);
    }

    public Recipes LoadRecipes() {
        return RecipeFileManager.LoadFromFile(_filePath);
    }
}