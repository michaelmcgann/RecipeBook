using System.Text.Json;

namespace RecipeApp;

public class FileManager {
    private static readonly JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions { WriteIndented = true };

    public static Recipes LoadFromFile(string filePath) {
        Recipes recipes = new Recipes();
        if (File.Exists(filePath)) {
            string json = File.ReadAllText(filePath);
            recipes = JsonSerializer.Deserialize<Recipes>(json) ?? new Recipes();
        }

        return recipes;
    }

    public static void SaveToFile(string filePath, Recipes recipes) {
        
        string json = JsonSerializer.Serialize(recipes, JsonSerializerOptions);
        File.WriteAllText(filePath, json);
    }
    

}