using System;
using System.Collections.Generic;

// Define the Recipe class
class Recipe
{
    // Private fields to hold the recipe information
    private List<string> ingredients; // List of ingredients
    private List<string> measurements; // List of measurements for each ingredient
    private List<double> quantities;   // List of quantities for each ingredient
    private List<string> steps;        // List of steps for the recipe

    // Constructor to initialize the lists
    public Recipe()
    {
        ingredients = new List<string>();
        measurements = new List<string>();
        quantities = new List<double>();
        steps = new List<string>();
    }

    // Method to add an ingredient to the recipe
    public void AddIngredient(string ingredient, double quantity, string measurement)
    {
        // Add the ingredient, quantity, and measurement to their respective lists
        ingredients.Add(ingredient);
        quantities.Add(quantity);
        measurements.Add(measurement);
    }

    // Method to add a step to the recipe
    public void AddStep(string step)
    {
        steps.Add(step);  // Add the step to the steps list
    }

    // Method to display the recipe
    public void Display()
    {
        // Print out the list of ingredients and their quantities and measurements
        Console.WriteLine("Ingredients:");
        for (int i = 0; i < ingredients.Count; i++)
        {
            Console.WriteLine("Quantities are " + $" {quantities[i]} of {ingredients[i]}");
            Console.WriteLine("Measurement(s) are " + $" {measurements[i]} of {ingredients[i]}");
        }

        // Print out the list of steps for the recipe
        Console.WriteLine("\nSteps:");
        for (int i = 0; i < steps.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {steps[i]}");
        }
    }

    // Method to scale the recipe by a certain factor
    public void Scale(double factor)
    {
        // Multiply each quantity by the scaling factor
        for (int i = 0; i < quantities.Count; i++)
        {
            quantities[i] *= factor;
        }
    }

    // Method to reset the quantities of the ingredients back to their original values
    public void ResetQuantities()
    {
        // Set each quantity to its original value (stored in the originalQuantities list)
        for (int i = 0; i < quantities.Count; i++)
        {
            quantities[i] = originalQuantities[i];
        }
    }

    // Method to clear the recipe (i.e., remove all ingredients and steps)
    public void Clear()
    {
        ingredients.Clear();
        measurements.Clear();
        quantities.Clear();
        steps.Clear();
    }

    // Private list to hold the original quantities of the ingredients
    private List<double> originalQuantities = new List<double>();

    // Method to save the original quantities of the ingredients (before any scaling)
    public void SaveOriginalQuantities()
    {
        originalQuantities.Clear();
        foreach (double quantity in quantities)
        {
            originalQuantities.Add(quantity);
        }
    }
}

// Define the Program class (contains the Main method)
class Program
{
    static void Main(string[] args)
    {
        // Create a new Recipe object
        Recipe recipe = new Recipe();
        string input;

        // Loop until the user enters "0" to exit
        do
        {
            // Print out the list of available commands
            Console.WriteLine("\nCommands:");
            Console.WriteLine("1 - Add ingredient(s)");
            Console.WriteLine("2 - Add step(s)");
            Console.WriteLine("3 - Display recipe(s)");
            Console.WriteLine("4 - Scale recipe");
            Console.WriteLine("5 - Reset quantities");
            Console.WriteLine("6 - Clear recipe(s)");
            Console.WriteLine("0 - Exit");

            input = Console.ReadLine();  // Read user input and execute the corresponding command

            switch (input)
            {
                case "1":
                    // Prompt the user to enter an ingredient, quantity, and measurement, 
                    // and add it to the recipe
                    Console.Write("Enter ingredient name: ");
                    string ingredient = Console.ReadLine();

                    Console.Write("Enter quantity: ");
                    double quantity = double.Parse(Console.ReadLine());

                    Console.Write("Enter measurement: ");
                    string measurement = Console.ReadLine();

                    recipe.AddIngredient(ingredient, quantity, measurement);
                    recipe.SaveOriginalQuantities();
                    break;

                case "2":
                    //Prompt the user to enter steps to the recipe
                    Console.Write("Enter step description: ");
                    string step = Console.ReadLine();

                    recipe.AddStep(step);
                    break;

                case "3":
                    //Prompt the user to display ingredient, quantity, measurement and steps
                    recipe.Display();
                    break;

                case "4":
                    //Prompt the user to enter the scale factor
                    Console.Write("Enter scaling factor (0.5, 2, or 3): ");
                    double factor = double.Parse(Console.ReadLine());

                    recipe.Scale(factor);
                    break;

                case "5":
                    //Prompt the user to reset all quantities to the recipe 
                    recipe.ResetQuantities();
                    break;

                case "6":
                    //Prompt the user to clear all recipes
                    recipe.Clear();
                    break;

                case "0":
                    //Prompt the user to exit the application
                    break;

                default:
                    //Allows the application to return an invalid message when the user entered the invalid command
                    Console.WriteLine("Invalid command.");
                    break;
            }
        } while (input != "0"); // Loops the application to run until the user enters "0"
    }
}

