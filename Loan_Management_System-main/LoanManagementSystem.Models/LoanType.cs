using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

#nullable disable
namespace LoanManagementSystem.Models
{
    public partial class LoanType
    {
        [Key]
        public int Id { get; set; }
        public string LoanTypeName { get; set; }
        public float InterestRate { get; set; }
    }
}
