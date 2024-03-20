using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities;
public class Truck : Vehicle
{
    public int Weight { get; set; }

    [JsonConstructor]
    public Truck(int weight, string model, string brand, int number) : base (model, brand, number)
    {
        Weight = weight;
    }

    public override string ToString()
    {
        return base.ToString() + $" - Type: camion ({Weight} tonnes)";
    }
}

