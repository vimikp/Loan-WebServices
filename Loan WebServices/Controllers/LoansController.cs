using Loan_WebServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Loan_WebServices.Controllers
{
    public class LoansController : Controller
    {
        // GET: Loans
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetLoans()
        {
            using (var db = new LoanDbContext())
            {
                var list = db.Loans.Select(x => x).ToList();

                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Loans/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Loans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Loans/Create
        [HttpPost]
        public ActionResult Create(Loan loan)
        {
            try
            {
                using (var db = new LoanDbContext())
                {
                    loan.SimpleInterest = loan.Principal * loan.InterestRate * loan.Duration / 100;
                    loan.Amount = loan.Principal + loan.SimpleInterest;

                    db.Loans.Add(loan);
                    db.SaveChanges();
                }

                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Loans/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Loans/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Loans/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Loans/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
