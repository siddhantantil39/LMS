using System;
using System.Collections.Generic;


namespace LoanManagementSystem.Data
{
    public class LoanTypeRepository:BaseRepository
    {
        public List<Models.LoanType> GetAllLoanTypes() {
            return _dbcontext.LoanTypes.ToList();
        }

        public Models.LoanType? GetLoanTypebyName(string name)
        {
            return _dbcontext.LoanTypes.FirstOrDefault(loantype => loantype.LoanTypeName == name);
        }
    }
}
