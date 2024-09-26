namespace RecipeApp;

class Program {
    static void Main(string[] args) {

        const string filePath = "recipes.json";
        Recipes recipes = new Recipes(filePath);
        IInputVerifier inputVerifier = new InputVerifier();
        AppLogic app = new AppLogic(recipes, inputVerifier);

        do {

            app.StartApp();

        } while (app.IsAppRunning);


    }
}