using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities;

public class Car : Vehicle
{
    public int HorsePower { get; set; }

    public Car(string model, string brand, int number, int horsePower) : base(model, brand, number)
    {
        HorsePower = horsePower;
    }

    public override string ToString()
    {
        return base.ToString() + $" - Type : voiture ({HorsePower} chevaux)";
    }
}
