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

        public LoanApplication SubmitApplication(int customerId, string loanTypeName, int loanAmount)
        {
            ProfileService profileService = new ProfileService();
            CustomerInfo customerInfo = profileService.GetProfileById(customerId);
            
            if(customerInfo == null)
            {
                return null;
            }

            LoanTypeService loanTypeService = new LoanTypeService();
            LoanType loanType = loanTypeService.GetLoanTypeByName(loanTypeName);

            if(loanType == null)
            {
                return null;
            }

            LoanApplication loanApplication = loanApplicationRepository.AddLoanApplication(customerInfo, loanType, loanAmount);
            return loanApplication;
        }
    }
}
