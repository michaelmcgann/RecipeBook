# RecipeApp
## Overview
RecipeApp is a console-based application for creating, storing, and managing recipes. Each recipe consists of a list of ingredients, and users can interact with the app to build custom recipes and save them to a JSON file. The app supports loading existing recipes from a JSON file, adding new recipes, and viewing them in a user-friendly format.

## Features
Create Recipes: Users can create a new recipe by selecting ingredients from a predefined list.
Manage Ingredients: The app maintains a repository of ingredients, each with its name, ID, and instructions.
Save and Load Recipes: Recipes are stored in a JSON file, allowing the user to persist and reload their recipe collection across sessions.
User-Friendly Display: Recipes can be displayed in a clean, readable format, including ingredient details and instructions.
JSON Serialization: The app uses JSON serialization to save and load recipes, making it easy to transfer or share recipe data.

## Project Structure
Ingredient.cs: Contains the Ingredient class, which holds information like the name, ID, and instructions for using the ingredient.
IngredientRepository.cs: Manages a collection of ingredients, allowing the user to fetch ingredients by their ID.
Recipe.cs: Represents a single recipe, which contains a list of ingredients and methods for displaying the recipe.
Recipes.cs: Contains a collection of multiple Recipe objects and provides functionality to add, display, save, and load recipes.
FileManager.cs: Handles the saving and loading of recipes to and from a JSON file using the System.Text.Json library.
Program.cs: Acts as the entry point for the console application, providing a menu-driven interface for the user.

## Installation
Prerequisites
.NET SDK (version 6.0 or later)
A compatible IDE (such as Visual Studio, Rider, or Visual Studio Code)

Steps
Clone the repository:

git clone https://github.com/your-repository/RecipeApp.git
cd RecipeApp
Build the project:

dotnet build
Run the application:

dotnet run --project RecipeApp
Usage
Once the app is running, you will be presented with a menu that allows you to:

Add a New Recipe: Create a new recipe by selecting ingredients by their ID.
View Recipes: Display all saved recipes in a readable format.
Save Recipes: Save your current recipe collection to a JSON file.
Load Recipes: Load previously saved recipes from a JSON file.
