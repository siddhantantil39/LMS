using LoanManagementSystem.Models;
using LoanManagementSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankDetailController : ControllerBase
    {
        BankDetailService bankDetailService;

        public BankDetailController()
        {
            bankDetailService = new BankDetailService();
        }

        [HttpGet("getAllBankDetails")]
        public IActionResult GetAllBankDetails()
        {
            List<BankDetail> list = bankDetailService.GetAllBankDetail();
            if (list.Any())
            {
                return Ok(list);
            }
            return NotFound();
        }

        [HttpGet("getAllBankDetailsById/{Id}")]
        public IActionResult GetBankDetailById(int Id)
        {
            BankDetail bankDetail = bankDetailService.GetBankDetailById(Id);
            if(bankDetail == null)
            {
                return NotFound($"Bank not found with Id : {Id}");      
            }

            return Ok(bankDetail);
        }
    }
}
