using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace LoanManagementSystem.Models
{
    public partial class EmiPayment
    {
        public EmiPayment()
        {

        }
        public EmiPayment(Emi emi, DateTime issueDate)
        {
            IssueDate = issueDate;
            PaidOn = DateTime.Now;
            EmiAmount = emi.Amount / emi.Months;
            Fine = 0;
            EmiId = emi.Id;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime IssueDate { get; set; }

        public float EmiAmount { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime PaidOn { get; set; }
        public float Fine { get; set; }
        public Emi Emi { get; set; }
        public int EmiId { get; set; }
    }
}
