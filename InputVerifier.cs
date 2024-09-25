namespace RecipeApp;

public static class InputVerifier {
    private const int MainMenuSize = 3;
    private const int IngredientListSize = 5;

    public static bool MainMenuChoiceVerifier(string? inputString, out int inputInt) =>
        int.TryParse(inputString, out inputInt) && inputInt is > 0 and <= MainMenuSize;

    public static bool BackToMainOrQuitVerifier(string? input) =>
        input != null && (input.ToLower().Equals("b") || input.ToLower().Equals("q"));

    public static bool IngredientChoiceVerifier(string? inputString, out int inputInt) =>
        int.TryParse(inputString, out inputInt) && inputInt is > 0 and <= IngredientListSize;

}