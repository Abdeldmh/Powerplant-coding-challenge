using Powerplant_coding_challenge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Powerplant_coding_challenge.API.Services
{
    public interface IProductionPlanService
    {
        ProductionPlanResponse CalculateProductionPlan(Payload payload);
    }

}
