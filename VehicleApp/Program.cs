using Entities;
using System.Diagnostics;
using System.Text.Json;
using static VehicleApp.ConsoleHelper;
using static VehicleApp.VehicleHelper;

StartProgram();

void StartProgram()
{
    ShowMenu();
    int userChoice = GetUserInt();

    while (userChoice != 0)
    {
        switch (userChoice)
        {
            case 1:
                CreateVehicle();
                break;
            case 2:
                ShowVehicle();
                break;
            case 3:
                UpdateVehicle();
                break;
            case 4:
                DeleteVehicle();
                break;
            case 5:
                SortVehicles();
                break;
            case 6:
                FilterVehicles();
                break;
            case 7:
                SaveVehicles();
                break;
            case 8:
                ShowALl();
                break;
            default:
                Console.WriteLine("Please enter a valid value");
                break;
        }
        StartProgram();
    }
    Console.WriteLine("Enter any key to escape program");
}