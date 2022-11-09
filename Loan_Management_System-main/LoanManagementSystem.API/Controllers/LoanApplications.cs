using LoanManagementSystem.Data;
using LoanManagementSystem.Models;
using LoanManagementSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace LoanManagementSystem.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanApplications : ControllerBase
    {
        LoanApplicationsService loanApplicationsService;
        public LoanApplications()
        {
            loanApplicationsService = new LoanApplicationsService();
        }

        [HttpGet("getAllApplications")]
        public IActionResult GetAllApplications()
        {
            List<LoanApplication> list = loanApplicationsService.GetAllApplications();
            if (list.Any())
            {
                return Ok(list);
            }
            return NotFound();
        }

        [HttpGet("getApplicationByCustomerId/{customerId}")]
        public IActionResult GetApllicationByCustomerId([FromRoute] int customerId)
        {
            List<LoanApplication> applications = loanApplicationsService.GetApplicationByCustomerId(customerId);
            if(applications.Any())
            {
                return Ok(applications);
            }

            return NotFound();
        }

        [HttpGet("getApplicationByApplicationId/{applicationId}")]
        public IActionResult GetApllicationByApplicationId([FromRoute] int applicationId)
        {
            LoanApplication application = loanApplicationsService.GetApplicationByApplicationId(applicationId);
            if (application == null)
            {
                return NotFound();
            }

            return Ok(application);
        }

        [HttpPost("submitLoanApplication")]
        public IActionResult SubmitLoanApplication(int CustomerId, string LoanType, int LoanAmount)
        {
            LoanApplication application = loanApplicationsService.SubmitApplication(CustomerId, LoanType, LoanAmount);

            if (application == null)
            {
                return BadRequest();
            }
            return Ok(application);
        }

    }
}
