using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanManagementSystem.Data;
using LoanManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LoanManagementSystem.Services
{
    public class EmiService
    {
        private readonly LoanApplicationRepository? loanApplicationRepository;
        private readonly EmiRepository _repository;

        public EmiService()
        {
            _repository = new EmiRepository();
        }
        
        public Emi AcceptLoanApplication(int applicationId)
        {
            LoanApplication application = loanApplicationRepository.GetApplicationById(applicationId);

            if(application == null)
            {
                return null;
            }

            Emi emi = new Emi(application);
            loanApplicationRepository.AcceptLoanApplication(applicationId);
            return emi;
            
        }

        public List<Emi>? GetAllLoans()
        {
            List<Emi> emis = _repository.GetAllEMIs();
            if (emis.Count == 0)
            {
                return null;
            }

            return emis;
        }

        public Emi GetEmiById(int emiId)
        {
            Emi emi = _repository.GetEMIById(emiId);

            EmiPaymentService emiPaymentService = new EmiPaymentService();
            List<EmiPayment> emiPayments = emiPaymentService.GetPaymentsByEmiId(emiId);

            emi.EmiPayments = emiPayments;
            return emi;
        }

        public List<Emi> GetEmisByCustomerId(int customerId)
        {
            List<Emi> emis = _repository.GetEMIByCustId(customerId);

            EmiPaymentService emiPaymentService = new EmiPaymentService();

            foreach(Emi emi in emis)
            {
                List<EmiPayment> emiPayments = emiPaymentService.GetPaymentsByEmiId(emi.Id);
                emi.EmiPayments = emiPayments;
            }

            return emis;
        }

        public bool DeclineLoanApplication(int applicationId)
        {
            LoanApplication application = loanApplicationRepository.GetApplicationById(applicationId);

            loanApplicationRepository.DeclineLoanApplication(applicationId);

            return true;
        }
    }
}
