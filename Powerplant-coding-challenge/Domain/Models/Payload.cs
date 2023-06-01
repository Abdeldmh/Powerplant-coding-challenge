using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Powerplant_coding_challenge.Domain.Models
{
    public class Payload
    {
        public double Load { get; set; }
        public Fuel Fuels { get; set; }
        public List<Powerplant> Powerplants { get; set; }

    }
}
