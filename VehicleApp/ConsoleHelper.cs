using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace VehicleApp;
public class ConsoleHelper
{
    public List<Vehicle> vehicles = new List<Vehicle>
    {
        new Truck (19, "Serie S", "Scania", 1000),
        new Truck (26, "EuroCargo", "Iveco", 1001),
        new Truck (5, "FM 460", "Volvo", 1002),
        new Car ("Miltipla", "FIAT", 1003, 1000),
        new Car ("Spring", "Dacia", 1004, 65),
        new Car ("AMI", "Citroën", 1005, 50)
    };

    public static void ShowMenu()
    {
        Console.WriteLine("");
        Console.WriteLine("Select an option :");
        Console.WriteLine("1 - Create vehicle");
        Console.WriteLine("2 - Show 1 vehicle");
        Console.WriteLine("3 - Update vehicle");
        Console.WriteLine("4 - Delete vehicle");
        Console.WriteLine("5 - Sort vehicles");
        Console.WriteLine("6 - Filter vehicles");
        Console.WriteLine("7 - Save current vehicle list");
        Console.WriteLine("8 - Show all");
    }
  
    /// <summary>
    /// Get string input from user
    /// </summary>
    /// <param name="question"></param>
    /// <returns>A string entered by the user in the console</returns>
    public static string GetUserString(string question)
    {
        Console.WriteLine(question);
        string? result = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(result))
        {
            Console.WriteLine("Wrong entry, please try again");
            GetUserString(question);
        }

        return result;
    }

    public static int GetUserInt(string question = "Type a number :")
    {
        string userInput = GetUserString(question);

        if (!int.TryParse(userInput, out int value))
        {
            GetUserInt(question);
        }

        return value;
    }
}
