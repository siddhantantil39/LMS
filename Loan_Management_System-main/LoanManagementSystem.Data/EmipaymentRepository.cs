using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;


namespace LoanManagementSystem.Data
{
    public class EmiPaymentRepository:BaseRepository
    {
        public EmiPayment AddPayment(Emi emi, int amountPaid)
        {
            EmiPayment payment = new EmiPayment();
            payment.Emi = emi;
            payment.EmiAmount = amountPaid;
            _dbcontext.Add(payment);
            _dbcontext.SaveChanges();
            return payment;
        }

        public List<EmiPayment> GetAllPayments()
        {
            return _dbcontext.Emipayments.ToList();
        }

        public List<EmiPayment> GetPaymentByEmiId(int emiId)
        {
            return _dbcontext.Emipayments.Where(payment => payment.Emi.Id == emiId).ToList();
        }

        public EmiPayment GetPaymentByEmiPaymentId(int paymentId)
        {
            return _dbcontext.Emipayments.FirstOrDefault(payment => payment.Id == paymentId);
        }

        
       
    }
}
