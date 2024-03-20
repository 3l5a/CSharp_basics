using Microsoft.VisualStudio.TestTools.UnitTesting;
using VehicleApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace VehicleApp.Tests;

[TestClass()]
public class VehicleHelperTests
{
    List<Vehicle> vehicles = new List<Vehicle>
    {
        new Truck (19, "Serie S", "Scania", 1000),
        new Truck (26, "EuroCargo", "Iveco", 1001),
        new Truck (5, "FM 460", "Volvo", 1002),
        new Car ("Miltipla", "FIAT", 1003, 1000),
        new Car ("Spring", "Dacia", 1004, 65),
        new Car ("AMI", "Citroën", 1005, 50)
    };

    [TestMethod()]
    public void ShowVehicle_WithValidVehicle_VehicleIsDisplayed()
    {
        //arrange
        int numCarToShow = 1003;

        //act
        Car vehicleExpected = (Car)vehicles[3];

        //assert
        Assert.AreEqual(vehicleExpected, vehicles.FirstOrDefault(v => v.Number == numCarToShow));
    }

    [TestMethod()]
    public void DeleteVehicle_WithValidVehicle_ListShortenedByOneItem()
    {
        //arrange
        int numCarToDelete = 1002;
        int countBefore = vehicles.Count();

        //act
        vehicles.RemoveAll(v => v.Number == numCarToDelete);
        int countAfter = vehicles.Count();

        Assert.AreEqual(countBefore-1, countAfter);
    }
}