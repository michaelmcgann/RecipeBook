namespace RecipeApp;

public class InputVerifier : IInputVerifier {

    public bool MainMenuChoiceVerifier(string? inputString, out int inputInt, int mainMenuSize) =>
        int.TryParse(inputString, out inputInt) && inputInt > 0 && inputInt <= mainMenuSize;

    public bool BackToMainOrQuitVerifier(string? input, string backButton, string quitButton) =>
        input != null && (input.ToLower().Equals(backButton) || input.ToLower().Equals(quitButton));

    public bool IngredientChoiceVerifier(string? inputString, out int inputInt, int ingredientListSize) =>
        int.TryParse(inputString, out inputInt) && inputInt > 0 && inputInt <= ingredientListSize;

}