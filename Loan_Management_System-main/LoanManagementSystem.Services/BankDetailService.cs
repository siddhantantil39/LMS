using LoanManagementSystem.Data;
using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Services
{
    public class BankDetailService
    {
        BankDetailRepository bankDetailRepository;

        public BankDetailService()
        {
            bankDetailRepository = new BankDetailRepository();
        }

        public List<BankDetail> GetAllBankDetail()
        {
            return bankDetailRepository.GetAllBanks();
        }

        public BankDetail GetBankDetailById(int bankId)
        {
            BankDetail bankDetail =  bankDetailRepository.GetBankDetailById(bankId);
            return bankDetail;
        }
    }
}
