using LoanManagementSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;

#nullable disable
namespace LoanManagementSystem.Models
{
    public partial class Emi
    {
        public Emi()
        {
            EmiPayments = new List<EmiPayment>();
        }

        public Emi(LoanApplication application)
        {
            LoanType = application.LoanType;
            Cust = application.Cust;
            Interest = application.LoanType.InterestRate;
            Amount = application.Amount;
            EmiCompleted = false;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int? Amount { get; set; }
        public LoanType LoanType { get; set; }
        public int LoanTypeId { get; set; }
        public float Interest { get; set; }

        public virtual CustomerInfo Cust { get; set; }
        public int CustomerInfoId { get; set; }
        public virtual List<EmiPayment> EmiPayments { get; set; }

        public DateTime StartDate { get; set; }
        public int Months { get; set; }

        public bool EmiCompleted { get; set; }
    }
}
