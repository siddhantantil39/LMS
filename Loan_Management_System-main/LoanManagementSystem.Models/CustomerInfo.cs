using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable
namespace LoanManagementSystem.Models
{
        public partial class CustomerInfo
        {
            public CustomerInfo()
            {
                Emis = new HashSet<Emi>();
                LoanApplications = new HashSet<LoanApplication>();
            }

            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Key]
            public int Id { get; set; }
            [Required]
            public string Custname { get; set; }

            [Display(Name = "Email address:")]
            [Required(ErrorMessage = "The email address is required")]
            [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
            public string Email { get; set; }
            
            [Display(Name = "PAN Card:")]
            [Required(ErrorMessage = "PAN Number is required")]
            [RegularExpression("^([A-Za-z]){5}([0-9]){4}([A-Za-z]){1}$", ErrorMessage = "Invalid PAN Number")]
            public string Pan { get; set; }

            [Display(Name = "Phone Number:")]
            [Required(ErrorMessage = "Phone Number is required")]
            [RegularExpression("^([0-9]){10}$", ErrorMessage = "Invalid Phone Number")]
            public string Phoneno { get; set; }
            public string CustAddress { get; set; }

            public virtual ICollection<Emi> Emis { get; set; }
            public virtual ICollection<LoanApplication> LoanApplications { get; set; }
        }
}
