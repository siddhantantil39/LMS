using LoanManagementSystem.Models;
using LoanManagementSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagementSystem.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class EMICalculator : ControllerBase
    {
        EMICalculatorService emiCalculatorService;
        public EMICalculator()
        {
            emiCalculatorService = new EMICalculatorService();
        }

        [HttpGet("calculateEmi")]
        public IActionResult CalculateEMI(int months, float amount,float rate)
        {
            float totalAmount = emiCalculatorService.Calculate(months, amount, rate); 
            return Ok(totalAmount);
        }
    }
}
