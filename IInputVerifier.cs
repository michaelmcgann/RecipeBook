namespace RecipeApp;public interface IInputVerifier {
                    
    public bool MainMenuChoiceVerifier(string? inputString, out int inputInt, int mainMenuSize);
                    
    public bool BackToMainOrQuitVerifier(string? input, string backButton, string quitButton);
                    
    public bool IngredientChoiceVerifier(string? inputString, out int inputInt, int ingredientListSize);
                    
}

