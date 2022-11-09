using LoanManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementSystem.Data
{
    public class LoanApplicationRepository:BaseRepository
    {

        public LoanApplication AddLoanApplication(CustomerInfo customerInfo, LoanType loanType, int loanAmount)
        {
            LoanApplication loanappl = new LoanApplication();
            loanappl.Cust = customerInfo;
            loanappl.LoanType = loanType;
            loanappl.Amount = loanAmount;
            _dbcontext.Add(loanappl);
            _dbcontext.SaveChanges();
            return loanappl;
        }

        public void AcceptLoanApplication(int applicationId)
        {
            LoanApplication application = GetApplicationById(applicationId);
            application.status = LoanStatus.ACCEPTED;
            _dbcontext.SaveChanges();
        }

        public void DeclineLoanApplication(int applicationId)
        {
            LoanApplication application = GetApplicationById(applicationId);
            application.status = LoanStatus.DECLINED;
            _dbcontext.SaveChanges();
        }

        public List<LoanApplication> GetApplication()
        {
            return _dbcontext.LoanApplications.Include(app => app.LoanType).ToList();
        }

        public LoanApplication? GetApplicationById(int Id)
        {
            return _dbcontext.LoanApplications.Include(app => app.LoanType).FirstOrDefault(application => application.AppId == Id);
        }

        public List<LoanApplication> GetApplicationsByCustomerId(int Id)
        {
            return _dbcontext.LoanApplications.Where(app => app.CustomerInfoId == Id).Include(app => app.LoanType).ToList();
        }
    }
}