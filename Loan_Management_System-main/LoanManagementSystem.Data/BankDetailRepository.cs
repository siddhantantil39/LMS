using System;
using System.Collections.Generic;

#nullable disable

namespace LoanManagementSystem.Data
{
    public class BankDetailRepository:BaseRepository
    {
        public List<Models.BankDetail> GetAllBanks()
        {
            return _dbcontext.BankDetails.ToList();
        }

        public Models.BankDetail? GetProfileByName(string name)
        {
            return _dbcontext.BankDetails.FirstOrDefault(bank => bank.BankName==name);
        }

    }
}
