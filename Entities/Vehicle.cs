using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities;
[JsonDerivedType(typeof(Car), typeDiscriminator: "Car")]
[JsonDerivedType(typeof(Truck), typeDiscriminator: "Truck")]
public class Vehicle
{
    public string Model { get; set; }
    protected string _brand;
    protected int _number;


    public Vehicle(string model, string brand, int number)
    {
        Model = model;
        Brand = brand;
        Number = number;
    }

    public string Brand
    {
        get { return _brand; }
        set
        {
            _brand = value.Any(c => char.IsDigit(c)) ? throw new Exception("Brand can't contain numbers") : value;
        }
    }

    public int Number
    {
        get { return _number; }
        set
        {
            _number = value > 999999 || value < 1000 ? throw new Exception("Number must be between 4 and 6 numbers") : value;
        }
    }

    public override string ToString()
    {
        return $"N°: {Number} - {Brand.ToUpper()} {Model}";
    }
}
