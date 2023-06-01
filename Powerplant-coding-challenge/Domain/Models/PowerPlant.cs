using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Powerplant_coding_challenge.Domain.Models
{
    public class Powerplant
    {
        public string Name { get; set; }
        public int Pmin { get; set; }
        public int Pmax { get; set; }
        public string Type { get; set; }
        public double Efficiency { get; set; }

        public Powerplant()
        {
                
        }
        public Powerplant(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public Powerplant(string name, string type, double efficiency)
        {
            Name = name;
            Type = type;
            Efficiency = efficiency;
        }

        public FuelType GetFuelType()
        {
            switch (this.Type)
            {
                case "windturbine": 
                    return FuelType.Wind;
                case "gasfired": 
                    return FuelType.Gas;
                case "turbojet": 
                    return FuelType.Kerosine;
                default:
                    throw new Exception("Unknown type " + this.Type);

            }
        }
    }

}
