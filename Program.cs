namespace RecipeApp;

class Program {
    static void Main(string[] args) {

        const string filePath = "recipes.json";
        AppLogic app = new AppLogic(filePath);

        do {

            app.StartApp();

        } while (app.IsAppRunning);


    }
}