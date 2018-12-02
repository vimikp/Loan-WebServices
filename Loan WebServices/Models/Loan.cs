using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Loan_WebServices.Models
{
    public class LoanDbContext : DbContext
    {
        public DbSet<Loan> Loans { get; set; }
    }

    public class Loan
    {
        public int Id { get; set; }
        public double InterestRate { get; set; }
        public double Principal { get; set; }
        public double Duration { get; set; }
        public double SimpleInterest { get; set; }
        public double Amount { get; set; }

    }
}