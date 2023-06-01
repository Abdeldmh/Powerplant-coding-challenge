using Powerplant_coding_challenge.API.Services;
using Powerplant_coding_challenge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Powerplant_coding_challenge.Domain.Services
{

    public class ProductionPlanService : IProductionPlanService
    {
        private double CalculateCostPerMwh(Powerplant plant, Fuel fuels)
        {
            var fuelCost = plant.Type == "gasfired" ? fuels.Gas : fuels.Kerosine;
            var efficiency = plant.Efficiency;
            return fuelCost / efficiency;
        }

        public ProductionPlanResponse CalculateProductionPlan(Payload payload)
        {
            var load = payload.Load;
            var fuels = payload.Fuels;
            var powerPlants = payload.Powerplants;

            var productionPlan = new List<PowerplantOutput>();

            var sortedPowerPlants = powerPlants.OrderByDescending(p => p.Type == "windturbine")
                                               .ThenBy(p => CalculateCostPerMwh(p, fuels));

            foreach (var plant in sortedPowerPlants)
            {
                var name = plant.Name;
                var pmax = plant.Pmax;
                var pmin = plant.Pmin;
                var fuelType = plant.Type;

                if (fuelType == "windturbine")
                {
                    var windPercentage = fuels.Wind;
                    var maxWindPower = pmax * (windPercentage / 100);
                    var powerOutput = Math.Min(maxWindPower, load);
                    productionPlan.Add(new PowerplantOutput { Name = name, P = powerOutput });
                    load -= powerOutput;
                }
                else
                {
                    var fuelCost = fuelType == "gasfired" ? fuels.Gas : fuels.Kerosine;
                    var efficiency = plant.Efficiency;
                    var costPerMwh = fuelCost / efficiency;

                    double powerOutput;

                    if (load >= pmax)
                    {
                        powerOutput = pmax;
                    }
                    else if (load <= pmin)
                    {
                        powerOutput = pmin;
                    }
                    else
                    {
                        powerOutput = load;
                    }

                    var cost = costPerMwh * powerOutput;
                    load -= powerOutput;

                    productionPlan.Add(new PowerplantOutput { Name = name, P = powerOutput });
                }
            }

            if (load > 0)
            {
                var gasPlants = productionPlan.Where(p => p.Name.Contains("gasfired")).ToList();
                var remainingPower = load;

                // Allocate power to gas-fired plants
                foreach (var plant in gasPlants)
                {
                    var pmax = powerPlants.First(p => p.Name == plant.Name).Pmax;
                    var additionalPower = Math.Min(pmax - plant.P, remainingPower);
                    plant.P += additionalPower;
                    remainingPower -= additionalPower;
                }

                // Allocate remaining power to wind turbines
                var windPlants = productionPlan.Where(p => p.Name.Contains("windpark")).ToList();
                foreach (var plant in windPlants)
                {
                    var pmax = powerPlants.First(p => p.Name == plant.Name).Pmax;
                    var additionalPower = Math.Min(pmax - plant.P, remainingPower);
                    plant.P += additionalPower;
                    remainingPower -= additionalPower;
                }
            }

            var response = new ProductionPlanResponse { Powerplants = productionPlan };
            return response;
        }
    }

}
