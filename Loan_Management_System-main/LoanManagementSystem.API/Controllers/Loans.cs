using LoanManagementSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LoanManagementSystem.Models;

namespace LoanManagementSystem.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class Loans : ControllerBase
    {
        private EmiService emiService;

        public Loans()
        {
            emiService = new EmiService();
        }

        [HttpGet("getAllLoans")]
        public IActionResult GetAllLoans()
        {
            List<Emi>? Loanslist = emiService.GetAllLoans();
            if (Loanslist.Any())
            {
                return Ok(Loanslist);
            }
            return NotFound("No Loans Are Present");
        }

        [HttpGet("getLoanByLoanId/{LoanId}")]
        public IActionResult GetLoanByLoanId([FromRoute] int LoanId)
        {
            Emi Loan = emiService.GetEmiById(LoanId);
            if(Loan == null)
            {
                return BadRequest("Emi Id not valid");
            }
            return Ok(Loan);
        }

        [HttpGet("getLoanByCustomerId/{CustomerId}")]
        public IActionResult GetLoansByCustomerId([FromRoute] int CustomerId)
        {
            List<Emi> Loans = emiService.GetEmisByCustomerId(CustomerId);

            if (Loans != null)
            {
                return Ok(Loans);
                
            }
            return NotFound("No Loans Taken");
        }

        [HttpGet("getLoanTypeDetails/{name}")]
        public IActionResult LoanTypeDetails(string name)
        {
            LoanTypeService loanTypeService = new LoanTypeService();
            LoanType loanType = loanTypeService.GetLoanTypeByName(name);
            if(loanType == null)
            {
                return NotFound($"{name} loan type not found");
            }
            return Ok(loanType);
        }

        [HttpGet("getAllLoanType")]
        public IActionResult AllLoanType()
        {
            LoanTypeService loanTypeService = new LoanTypeService();
            List<LoanType> loanTypes = loanTypeService.GetAllLoanTypes();
            if (loanTypes == null)
            {
                return NotFound("{name} loan type not found");
            }
            return Ok(loanTypes);
        }

        [HttpPost("acceptLoanApplication/{applicationId}")]
        public IActionResult AcceptLoanApplication(int applicationId)
        {
            Emi emi = emiService.AcceptLoanApplication(applicationId);
            
            if(emi == null)
            {
                return BadRequest("Application cannot be accepted");
            }
            return Ok(emi);
        }

        [HttpPost("declineLoanApplication/{applicationId}")]
        public IActionResult DeclineLoanApplication(int applicationId)
        {
            bool declined = emiService.DeclineLoanApplication(applicationId);

            if (declined == false)
            {
                return BadRequest("Cannot Decline Application");
            }
            return Ok(declined);
        }

    }
}
