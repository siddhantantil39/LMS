using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable
namespace LoanManagementSystem.Models
{
    public partial class LoanType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string LoanTypeName { get; set; }
        public float InterestRate { get; set; }
    }
}
