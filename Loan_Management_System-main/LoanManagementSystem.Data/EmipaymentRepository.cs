using LoanManagementSystem.Models;
using System;
using System.Collections.Generic;


namespace LoanManagementSystem.Data
{
    public class EmiPaymentRepository:BaseRepository
    {
        public EmiPayment AddPayment(EmiPayment emiPayment)
        {
            _dbcontext.Add(emiPayment);
            _dbcontext.SaveChanges();
            return emiPayment;
        }

        public List<EmiPayment> GetAllPayments()
        {
            return _dbcontext.Emipayments.ToList();
        }

        public List<EmiPayment> GetPaymentsByEmiId(int emiId)
        {
            return _dbcontext.Emipayments.Where(payment => payment.Emi.Id == emiId).ToList();
        }

        public EmiPayment GetPaymentByEmiPaymentId(int paymentId)
        {
            return _dbcontext.Emipayments.FirstOrDefault(payment => payment.Id == paymentId);
        }

        
       
    }
}
