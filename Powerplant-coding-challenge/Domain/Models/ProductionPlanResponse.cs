using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Powerplant_coding_challenge.Domain.Models
{
    public class ProductionPlanResponse
    {
        public List<PowerplantOutput> Powerplants { get; set; }
    }

    public class PowerplantOutput
    {
        public string Name { get; set; }
        public double P { get; set; }
    }

}
