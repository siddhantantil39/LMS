using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoanManagementSystem.Data;
using LoanManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace LoanManagementSystem.Services
{
    public class EmiService
    {
        private readonly EmiRepository _repository;

        public EmiService()
        {
            _repository = new EmiRepository();
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
            if(emi == null)
            {
                return null;
            }
            
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

        public Emi AddEmi(LoanApplication application)
        {
            EMICalculatorService _EMICalculatorService = new EMICalculatorService();
            float amount = _EMICalculatorService.Calculate(application.Months, application.Amount, application.Interest);

            Emi emi = new Emi(application, amount);
            Emi newEmi = _repository.AddEmi(emi);

            if(newEmi != null)
            {
                return newEmi;
            }
            return null;
        }

        public Emi CompleteEmi(Emi emi)
        {
            if (_repository.CompleteEmi(emi))
            {
                return emi;
            }
            return null;
        }
    }
}
