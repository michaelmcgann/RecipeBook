namespace RecipeApp;

public class Recipe {
    
    public string Name { get; set; }
    public List<Ingredient> Ingredients { get; set; }

    public Recipe(string name) {
        Name = name;
        Ingredients = new List<Ingredient>();
    }

    public void AddIngredient(int id) {

        Ingredients.Add(IngredientRepository.GetIngredientById(id));
    }

    public string Display() {
        string displayString = "";
        foreach (Ingredient ingredient in Ingredients) {
            displayString += $"{ingredient.Name}. {ingredient.Instructions}\n";
        }
        
        return displayString;
    }
    
    
}