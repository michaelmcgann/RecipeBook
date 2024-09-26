using System.Text.Json;

namespace RecipeApp;

public class RecipeFileManager {
    private static readonly JsonSerializerOptions JsonSerializerOptions = new() { WriteIndented = true };

    public static Recipes LoadFromFile(string filePath) {
        Recipes recipes = new Recipes(filePath);
        if (File.Exists(filePath)) {
            string json = File.ReadAllText(filePath);
            recipes = JsonSerializer.Deserialize<Recipes>(json) ?? new Recipes(filePath);
        }

        return recipes;
    }

    public static void SaveToFile(string filePath, Recipes recipes) {
        
        string json = JsonSerializer.Serialize(recipes, JsonSerializerOptions);
        File.WriteAllText(filePath, json);
    }
    

}