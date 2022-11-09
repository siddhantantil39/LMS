using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace LoanManagementSystem.Data
{
    public class BankDetailRepository:BaseRepository
    {
        public List<BankDetail> GetAllBanks()
        {
            return _dbcontext.BankDetails.ToList();
        }

        public BankDetail? GetProfileByName(string name)
        {
            return _dbcontext.BankDetails.FirstOrDefault(bank => bank.BankName==name);
        }

        public BankDetail GetBankDetailById(int bankId)
        {
            return _dbcontext.BankDetails.Find(bankId);
        }

    }
}
