namespace RecipeApp;

public static class IngredientRepository {

    private static readonly Dictionary<int, Ingredient> IngredientsById = new Dictionary<int, Ingredient>() {
        { 1, new Ingredient("Flour", 1, "Add 100g to the mix.") },
        { 2, new Ingredient("Cheese", 2, "Grate and sprinkle evenly.") },
        { 3, new Ingredient("Sugar", 3, "Add 1 teaspoon to the mix.") },
        { 4, new Ingredient("Salt", 4, "Add 1g to the mix.") },
        { 5, new Ingredient("Butter", 5, "Add 1 tablespoon to the mix") }
    };

    public static Ingredient GetIngredientById(int id) {
        if (IngredientsById.TryGetValue(id, out var ingredient)) {
            return ingredient;
        }

        throw new ArgumentException($"No ingredient found with ID {id}");
        
    }

    public static IEnumerable<Ingredient> AllIngredients => IngredientsById.Values;
        
    
}