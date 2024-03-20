using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static VehicleApp.ConsoleHelper;

namespace VehicleApp;
public static class VehicleHelper
{
    public static List<Vehicle> vehicles = new List<Vehicle>
    {
        new Truck (19, "Serie S", "Scania", 1000),
        new Truck (26, "EuroCargo", "Iveco", 1001),
        new Truck (5, "FM 460", "Volvo", 1002),
        new Car ("Miltipla", "FIAT", 1003, 1000),
        new Car ("Spring", "Dacia", 1004, 65),
        new Car ("AMI", "Citroën", 1005, 50)
    };

    public static void CreateVehicle()
    {
        string userInput = GetUserString("Car (c) or truck (t) ? Type (m) for menu.");

        switch (userInput)
        {
            case "c":
                try
                {
                    Car newCar = new Car
                                    (
                                    GetUserString("Enter model :"),
                                    GetUserString("Enter brand :"),
                                    GetVehiclesFromDB().Max(v => v.Number) + 1,
                                    GetUserInt("Enter horsepower :")
                                    );
                    vehicles.Add(newCar);
                    Console.WriteLine("Vehicle was successfully created");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could not create car. " + ex.Message);
                }
                break;
            case "t":
                try
                {
                    Truck newTruck = new Truck
                                    (
                                    GetUserInt("Enter weight :"),
                                    GetUserString("Enter model :"),
                                    GetUserString("Enter brand :"),
                                    GetVehiclesFromDB().Max(v => v.Number) + 1
                                    );
                    vehicles.Add(newTruck);
                    Console.WriteLine("Vehicle was successfully created");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could not create truck. " + ex.Message);
                }
                break;
            case "m":
                break;
            default:
                Console.WriteLine("Wrong entry, try again");
                CreateVehicle();
                break;
        }

    }

    public static void DeleteVehicle()
    {
        int vehicleNum = GetUserInt("Type number of vehicle to delete");
        Vehicle? vehicleToDelete = vehicles.FirstOrDefault(v => v.Number == vehicleNum);

        if (vehicleToDelete == null) Console.WriteLine("Vehicle not found, try again.");
        else vehicles.Remove(vehicleToDelete);
    }

    public static void ShowVehicle()
    {
        List<Vehicle> vehicles = GetVehiclesFromDB();
        int vehicleNumber = GetUserInt("Vehicle number to look up : ");

        while (vehicles.FirstOrDefault(v => v.Number == vehicleNumber) == null)
        {
            Console.WriteLine("Vehicle not found, please try again");
            ShowVehicle();
        }

        Console.WriteLine(vehicles.FirstOrDefault(v => v.Number == vehicleNumber).ToString());
    }

    public static void UpdateVehicle()
    {
        int vehicleNum = GetUserInt("Type number of vehicle to update");
        Vehicle? vehicleToUpdate = vehicles.FirstOrDefault(v => v.Number == vehicleNum);

        if (vehicleToUpdate != null)
        {
            switch (vehicleToUpdate)
            {
                case Car car:
                    try
                    {
                        string? brand = GetUserString("Brand ? (Type enter if you don't want to update vehicle brand");
                        car.Brand = string.IsNullOrEmpty(brand) ? car.Brand : brand;
                        string? model = GetUserString("Model ? (Type enter if you don't want to update vehicle model");
                        car.Model = string.IsNullOrEmpty(model) ? car.Model : model;
                        int horsePower = GetUserInt("Weight ? Type 0 if you don't want to update vehicle model");
                        car.HorsePower = horsePower == 0 ? car.HorsePower : horsePower;

                        Console.WriteLine("Vehicle was successfully updated");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Could not update car. " + ex.Message);
                    }
                    break;
                case Truck truck:
                    try
                    {
                        string? brand = GetUserString("Brand ? (Type enter if you don't want to update vehicle brand");
                        truck.Brand = string.IsNullOrEmpty(brand) ? truck.Brand : brand;
                        string? model = GetUserString("Model ? (Type enter if you don't want to update vehicle model");
                        truck.Model = string.IsNullOrEmpty(model) ? truck.Model : model;
                        int weight = GetUserInt("Weight ? Type 0 if you don't want to update vehicle model");
                        truck.Weight = weight == 0 ? truck.Weight : weight;

                        Console.WriteLine("Vehicle was successfully updated");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Could not update truck. " + ex.Message);
                    }
                    break;
                default:
                    Console.WriteLine("Type of vehicle not found");
                    break;
            }
        }
    }

    public static void SortVehicles()
    {
        string sortBy = GetUserString("Sort by : number (n), brand (b), model (m), weight (w), horsepower (h) ?");
        List<Vehicle> sortedVehicles = new();

        switch (sortBy)
        {
            case "n":
                sortedVehicles = vehicles.OrderBy(v => v.Number).ToList();
                break;
            case "b":
                sortedVehicles = vehicles.OrderBy(v => v.Brand).ToList();
                break;
            case "m":
                sortedVehicles = vehicles.OrderBy(v => v.Model).ToList();
                break;
            case "w":
                sortedVehicles = vehicles.OfType<Truck>().OrderBy(v => v.Weight).Cast<Vehicle>().ToList();
                break;
            case "h":
                sortedVehicles = vehicles.OfType<Car>().OrderBy(v => v.HorsePower).Cast<Vehicle>().ToList();
                break;
            default:
                break;
        }
        Console.WriteLine(string.Join("\n", sortedVehicles));
    }

    public static void FilterVehicles()
    {
        string sortBy = GetUserString("Search : brand (b), weight (w), horsepower (h) ? Type (m) for menu.");
        List<Vehicle> filteredVehicles = new();

        switch (sortBy)
        {
            case "b":
                string brandToSearch = GetUserString("Which brand ?");
                filteredVehicles = vehicles.Where(v => v.Brand == brandToSearch).ToList();
                break;
            case "w":
                int weightToSearch = GetUserInt("Which weight ?");
                filteredVehicles = vehicles.OfType<Truck>().Where(v => v.Weight == weightToSearch).Cast<Vehicle>().ToList();
                break;
            case "h":
                int horsePowerToSearch = GetUserInt("Which horsepower ?");
                filteredVehicles = vehicles.OfType<Car>().Where(v => v.HorsePower == horsePowerToSearch).Cast<Vehicle>().ToList();
                break;
            case "m":
                break;
            default:
                Console.WriteLine("Wrong entry, try again");
                FilterVehicles();
                break;
        }

        if (filteredVehicles.Count == 0) Console.WriteLine("Nothing to show here...");
        else Console.WriteLine(string.Join("\n", filteredVehicles));
    }

    public static void ShowALl()
    {
        List<Vehicle> vehicles = GetVehiclesFromDB();
        Console.WriteLine(string.Join("\n\n", vehicles));
    }

    public static void SaveVehicles()
    {
        File.WriteAllText("vehicles.json", JsonSerializer.Serialize(vehicles));
    }

    public static List<Vehicle> GetVehiclesFromDB()
    {
        if (!File.Exists("vehicles.json"))
            File.WriteAllText("vehicles.json", JsonSerializer.Serialize(vehicles));

        string content = File.ReadAllText("vehicles.json");
        List<Vehicle> deserializedVehicles = JsonSerializer.Deserialize<List<Vehicle>>(content);

        return deserializedVehicles;
    }
}
