using LoanManagementSystem.Models;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

#nullable disable
namespace LoanManagementSystem.Models
{
    public enum LoanStatus
    { 
        APPLIED, 
        ACCEPTED,
        DECLINED
    }

    public partial class LoanApplication
    {
        [Key]
        public int Id { get; set; }
        public LoanType LoanType { get; set; }
        public int LoanTypeId { get; set; }
        public virtual CustomerInfo Cust { get; set; }
        public int CustomerInfoId { get; set; }
        public LoanStatus status { get; set; }
        public float Amount { get; set; }
        public float Interest { get; set; }
        public int Months { get; set; }



        public int BankDetailId { get; set; }
        public BankDetail BankDetail { get; set; }
    }
}
