namespace RecipeApp;

public class AppLogic {

    public Recipes RecipesList { get; set; }
    public bool IsAppRunning { get; private set; } = true;
    private readonly IInputVerifier _inputVerifier;
    private const int MainMenuSize = 3;
    private const int IngredientListSize = 5;
    private const string BackButton = "b";
    private const string QuitButton = "q";

    public AppLogic(Recipes recipes, IInputVerifier inputVerifier) {
        _inputVerifier = inputVerifier;
        RecipesList = recipes;
    }

    public void StartApp() {
        int mainMenuChoice = GetMainMenuChoice();
        ProcessMainMenuChoice(mainMenuChoice);
        
    }

    private int GetMainMenuChoice() {
        int mainMenuChoice;
        bool isValidMainMenuChoice;
        do {
            DisplayMainMenu();
            string? mainMenuChoiceString = Console.ReadLine();
            isValidMainMenuChoice =
                _inputVerifier.MainMenuChoiceVerifier(mainMenuChoiceString, out mainMenuChoice, MainMenuSize);
        } while (!isValidMainMenuChoice);

        return mainMenuChoice;
    }

    private void DisplayMainMenu() {
        Console.WriteLine("********MAIN MENU********");
        Console.WriteLine();
        Console.WriteLine("Select from an option below.");
        Console.WriteLine("1. View stored recipes.\n" +
                          "2. Add new recipe.\n" +
                          "3. Quit");
        Console.WriteLine("--------------------------");
    }

    private void DisplayStoredRecipes() => Console.WriteLine(RecipesList.DisplayRecipes());

    private void DisplayNewRecipeMenu() {
        Console.WriteLine("--------------------------");
        Console.WriteLine("Select an ingredient below, once finished press [Q] to save recipe.\n" +
                          "1. Flour\n" +
                          "2. Cheese\n" +
                          "3. Sugar\n" +
                          "4. Salt\n" +
                          "5. Butter\n");
        Console.WriteLine("--------------------------");
    }

    private void ProcessNewRecipe() {
        Console.WriteLine("********NEW RECIPE********");
        Console.WriteLine();
        Recipe recipe = GetNameAndReturnNewRecipe();
        
        GetIngredients(recipe);

        if (recipe.Ingredients.Count > 0) {
            Console.WriteLine("--------------------------");
            Console.WriteLine($"Recipe added: {recipe.Name}");
            Console.WriteLine("--------------------------");
            RecipesList.AddRecipe(recipe);
        }
        else {
            Console.WriteLine($"Recipe is empty. {recipe.Name} has not been added.");
        }

        Console.WriteLine("--------------------------");
        Console.WriteLine("Returning to Main Menu...");
        Console.WriteLine("--------------------------");

    }

    private void GetIngredients(Recipe recipe) {
        do {
            DisplayNewRecipeMenu();
            string? choiceString = Console.ReadLine();
            if (choiceString != null && choiceString.ToLower().Equals("q")) {
                break;
            }
            bool isValidChoice = _inputVerifier.IngredientChoiceVerifier(choiceString, out int choiceInt, IngredientListSize);
            if (isValidChoice) {
                recipe.AddIngredient(choiceInt);
                Console.WriteLine("--------------------------");
                Console.WriteLine($"{IngredientRepository.GetIngredientById(choiceInt).Name} added.");
                Console.WriteLine("--------------------------");
            }
            else {
                Console.WriteLine("--------------------------");
                Console.WriteLine("Not a valid option.");
                Console.WriteLine("--------------------------");
            }
            
        } while (true);
    }

    private static Recipe GetNameAndReturnNewRecipe() {
        Recipe recipe;
        do {
            Console.WriteLine("--------------------------");
            Console.WriteLine("What would you like to name your recipe?");
            Console.WriteLine("--------------------------");
            string? recipeName = Console.ReadLine();
            if (recipeName!.Length < 1) {
                Console.WriteLine("--------------------------");
                Console.WriteLine("Name cannot be empty.");
                Console.WriteLine("--------------------------");
            }
            else {
                recipe = new Recipe(recipeName);
                break;
            }
        } while (true);
        
        return recipe;
    }

    private void ProcessStoredRecipes() {
        DisplayStoredRecipes();
        string? choiceString;

        bool isValidChoice;
        do {
            Console.WriteLine("--------------------------");
            Console.WriteLine("[B]ack to MAIN MENU.\n" +
                              "[Q]uit app.");
            Console.WriteLine("--------------------------");
            choiceString = Console.ReadLine();
            isValidChoice = _inputVerifier.BackToMainOrQuitVerifier(choiceString, BackButton, QuitButton);
        } while (!isValidChoice);

        if (choiceString!.ToLower().Equals(QuitButton)) {
            IsAppRunning = false;
        }
    }
    

    private void ProcessMainMenuChoice(int choice) {
        switch (choice) {
            case 1:
                ProcessStoredRecipes();
                break;
            case 2: 
                ProcessNewRecipe();
                break;
            case 3:
                IsAppRunning = false;
                break;
        }
    }
}