using LoanManagementSystem.Data;
using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LoanManagementSystem.Services
{
    public class LoanApplicationsService
    {
        private LoanApplicationRepository loanApplicationRepository;

        public LoanApplicationsService()
        {
            loanApplicationRepository = new LoanApplicationRepository();
        }
        public List<LoanApplication> GetAllApplications()
        {
            List<LoanApplication> loanApplications = loanApplicationRepository.GetApplication();

            ProfileService profileService = new ProfileService();

            foreach(var application in loanApplications) {
                CustomerInfo customerInfo = profileService.GetProfileById(application.CustomerInfoId);
                application.Cust = customerInfo;
            }
            

            return loanApplications;
        }

        public List<LoanApplication> GetApplicationByCustomerId(int Id)
        {
            List<LoanApplication> loanApplications = loanApplicationRepository.GetApplicationsByCustomerId(Id);
            ProfileService profileService = new ProfileService();
            CustomerInfo customerInfo = profileService.GetProfileById(Id);
            
            foreach (var application in loanApplications)
            {
                application.Cust = customerInfo;
            }

            return loanApplications;
        }

        public LoanApplication GetApplicationByApplicationId(int Id)
        {
            LoanApplication? application = loanApplicationRepository.GetApplicationById(Id);

            if(application == null)
            {
                return null;
            }

            ProfileService profileService = new ProfileService();
            CustomerInfo customerInfo = profileService.GetProfileById(application.CustomerInfoId);
            application.Cust = customerInfo;
            return application;
        }

        public LoanApplication SubmitApplication(int customerId, int loanTypeId, int loanAmount, int months, int bankId)
        {
            ProfileService profileService = new ProfileService();
            CustomerInfo customerInfo = profileService.GetProfileById(customerId);

            LoanTypeService loanTypeService = new LoanTypeService();
            LoanType? loanType = loanTypeService.GetLoanTypeById(loanTypeId);

            BankDetailService bankDetailService = new BankDetailService();
            BankDetail bankDetail = bankDetailService.GetBankDetailById(bankId);
            
            if(customerInfo == null || loanType == null || bankDetail == null)
            {
                return null;
            }

            LoanApplication loanApplication = loanApplicationRepository.AddLoanApplication(customerInfo, loanType, loanAmount, bankDetail, months);
            loanApplication.Cust = customerInfo;
            loanApplication.BankDetail = bankDetail;
            loanApplication.LoanType = loanType;
            return loanApplication;
        }

        public Emi? AcceptLoanApplication(int applicationId)
        {
            LoanApplication? application = loanApplicationRepository.GetApplicationById(applicationId);

            if (application == null)
            {
                return null;
            }

            if(application.status == LoanStatus.DECLINED || application.status == LoanStatus.ACCEPTED)
            {
                return null;
            }

            loanApplicationRepository.AcceptLoanApplication(applicationId);

            EmiService _EmiService = new EmiService();
            Emi newEMI = _EmiService.AddEmi(application);
            return newEMI;

        }

        public bool DeclineLoanApplication(int applicationId)
        {
            LoanApplication? application = loanApplicationRepository.GetApplicationById(applicationId);

            if(application == null || application.status != LoanStatus.APPLIED)
            {
                return false;
            }

            loanApplicationRepository.DeclineLoanApplication(applicationId);

            return true;
        }
    }
}
