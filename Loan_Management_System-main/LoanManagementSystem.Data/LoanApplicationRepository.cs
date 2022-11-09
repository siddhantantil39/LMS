using LoanManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementSystem.Data
{
    public class LoanApplicationRepository:BaseRepository
    {

        public LoanApplication AddLoanApplication(CustomerInfo customerInfo, LoanType loanType, int loanAmount, BankDetail bankDetail, int months)
        {
            LoanApplication loanappl = new LoanApplication();
            loanappl.CustomerInfoId = customerInfo.Id;
            loanappl.LoanTypeId = loanType.Id;
            loanappl.Amount = loanAmount;
            loanappl.BankDetailId = bankDetail.Id;
            loanappl.Interest = loanType.InterestRate;
            loanappl.Months = months;
            loanappl.status = LoanStatus.APPLIED;
            _dbcontext.LoanApplications.Add(loanappl);
            _dbcontext.SaveChanges();
            return loanappl;
        }

        public void AcceptLoanApplication(int applicationId)
        {
            LoanApplication? application = _dbcontext.LoanApplications.Find(applicationId);
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
            return _dbcontext.LoanApplications.Include(app => app.LoanType).FirstOrDefault(application => application.Id == Id);
        }

        public List<LoanApplication> GetApplicationsByCustomerId(int Id)
        {
            return _dbcontext.LoanApplications.Where(app => app.CustomerInfoId == Id).Include(app => app.LoanType).ToList();
        }
    }
}