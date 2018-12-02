using AutoMapper;
using Loan_WebServices.DTOs;
using Loan_WebServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Loan_WebServices.Controllers.Api
{
    public class LoansController : ApiController
    {
 
        //GET /api/loans
        public IEnumerable<LoanDto> GetLoans()
        {
            if (ModelState.IsValid)
            {
                using (var db = new LoanDbContext())
                {
                    return db.Loans.ToList().Select(Mapper.Map<Loan, LoanDto>);
                }
            }

            return null;
                
        }

        // GET: api/Loans/5
        public string Get(int id)
        {
            return "value";
        }

        // PUT: api/Loans/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Loans/5
        public void Delete(int id)
        {
        }

        [HttpPost]
        public LoanDto Create(LoanDto loanDto)
        {
            if (ModelState.IsValid)
            {
                using (var db = new LoanDbContext())
                {
                    var loan = Mapper.Map<LoanDto, Loan>(loanDto);
                    loan.SimpleInterest = loan.Principal * loan.InterestRate * loan.Duration / 100;
                    loan.Amount = loan.Principal + loan.SimpleInterest;

                    db.Loans.Add(loan);
                    db.SaveChanges();
                    loanDto.Id = loan.Id;
                    loanDto.Amount = loan.Amount;
                    loanDto.SimpleInterest = loan.SimpleInterest;

                    return loanDto;
                }
            }
            return null;        

        }

        [HttpDelete]
        public void DeleteAllLoans()
        {
            using(var db = new LoanDbContext())
            {
                db.Database.ExecuteSqlCommand("DELETE FROM [Loans]");
                db.SaveChanges();
            }

        }

    }
}
