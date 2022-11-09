using LoanManagementSystem.Data;
using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanManagementSystem.Services
{
    public class EmiPaymentService
    {
        private readonly EmiPaymentRepository emiPaymentRepository;

        public EmiPaymentService()
        {
            emiPaymentRepository = new EmiPaymentRepository();
        }

        public List<EmiPayment> GetAllPayments()
        {
            List<EmiPayment> emiPayments = emiPaymentRepository.GetAllPayments();
            return emiPayments;
        }

        public List<EmiPayment> GetPaymentsByCustomerId(int customerId)
        {
            EmiService emiService = new EmiService();
            List<Emi> emis = emiService.GetEmisByCustomerId(customerId);

            List<EmiPayment> emiPayments = new List<EmiPayment>();
            foreach (Emi emi in emis)
            {
                foreach (var emiPayment in emi.EmiPayments)
                {
                    emiPayments.Add(emiPayment);
                }
            }

            return emiPayments;
        }

        public EmiPayment GetPaymentByPaymentId(int paymentId)
        {
            EmiPayment emiPayment = emiPaymentRepository.GetPaymentByEmiPaymentId(paymentId);
            return emiPayment;
        }

        public List<EmiPayment> GetPaymentsByEmiId(int EmiId)
        {
            List<EmiPayment> emiPayments = emiPaymentRepository.GetPaymentsByEmiId(EmiId);
            return emiPayments;
        }

        public EmiPayment AddPayment(int emiId)
        {
            EmiService emiService = new EmiService();
            Emi emi = emiService.GetEmiById(emiId);

            if(emi == null || emi.EmiCompleted)
            {
                return null;
            }

            List<EmiPayment> emiPayments = GetPaymentsByEmiId(emiId);

            DateTime issueDate;

            if (emiPayments.Any())
            {
                issueDate = emiPayments.Last().IssueDate.AddMonths(1);
            }
            else
            {
                issueDate = emi.StartDate.AddMonths(1);
            }

            EmiPayment emiPayment = new EmiPayment(emi, issueDate);

            EmiPayment newEmiPayment = emiPaymentRepository.AddPayment(emiPayment);

            if(emiPayments.Count == emi.Months - 1)
            {
                emiService.CompleteEmi(emi);
            }

            return newEmiPayment;
        }
    }
}
