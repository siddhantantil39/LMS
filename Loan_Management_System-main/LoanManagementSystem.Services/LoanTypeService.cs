using LoanManagementSystem.Data;
using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LoanManagementSystem.Services
{
    public class LoanTypeService
    {
        LoanTypeRepository _repository = new LoanTypeRepository();
        public List<LoanType> GetAllLoanTypes()
        {
            return _repository.GetAllLoanTypes();
        }

        public LoanType? GetLoanTypeByName(string name)
        {
            return _repository.GetLoanTypebyName(name);
        }

        internal LoanType? GetLoanTypeById(int loanTypeId)
        {
            return _repository.GetLoanTypebyId(loanTypeId);
        }
    }
}
