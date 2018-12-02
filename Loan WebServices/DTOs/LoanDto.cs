using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Loan_WebServices.Models;

namespace Loan_WebServices.DTOs
{
    public class LoanDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the Interest Rate.")]
        public double InterestRate { get; set; }
        [Required(ErrorMessage = "Please enter the Amount you want to borrow.")]
        public double Principal { get; set; }
        [Required(ErrorMessage = "Please enter the term in years")]
        public double Duration { get; set; }
        public double? SimpleInterest { get; set; }
        public double? Amount { get; set; }

    }
}