using Microsoft.AspNetCore.Mvc;
using Powerplant_coding_challenge.API.Services;
using Powerplant_coding_challenge.Domain.Models;
using Powerplant_coding_challenge.Domain.Services;
using System;
using Newtonsoft.Json;


namespace Powerplant_coding_challenge.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductionPlanController : ControllerBase
    {
        private readonly IProductionPlanService _productionPlanService;

        public ProductionPlanController(IProductionPlanService productionPlanService)
        {
            _productionPlanService = productionPlanService;
        }

        [HttpPost]
        public ActionResult<ProductionPlanResponse> CalculateProductionPlan(Payload payload)
        {
            try
            {
                var response = _productionPlanService.CalculateProductionPlan(payload);
                return Ok(response);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while calculating the production plan: {ex.Message}");
                return StatusCode(500, "An error occurred while calculating the production plan.");
            }

        }
    }
}
