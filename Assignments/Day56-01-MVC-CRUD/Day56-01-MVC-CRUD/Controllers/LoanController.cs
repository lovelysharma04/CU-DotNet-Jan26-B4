using Day56_01_MVC_CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day56_01_MVC_CRUD.Controllers
{
    public class LoanController : Controller
    {
        private static List<Loan> loans=new List<Loan>()
        {
            new Loan { Id = 1, BorrowerName = "Rahul Sharma", LenderName = "ABC Finance", Amount = 50000, IsSettled = false },
            new Loan { Id = 2, BorrowerName = "Priya Mehta", LenderName = "XYZ Bank", Amount = 120000, IsSettled = true },
            new Loan { Id = 3, BorrowerName = "Amit Verma", LenderName = "City Finance", Amount = 75000, IsSettled = false },
            new Loan { Id = 4, BorrowerName = "Neha Kapoor", LenderName = "Trust Bank", Amount = 200000, IsSettled = true },
            new Loan { Id = 5, BorrowerName = "Rohan Gupta", LenderName = "Capital Loans", Amount = 90000, IsSettled = false },
            new Loan { Id = 6, BorrowerName = "Sneha Arora", LenderName = "Prime Finance", Amount = 150000, IsSettled = false },
            new Loan { Id = 7, BorrowerName = "Vikas Jain", LenderName = "Smart Credit", Amount = 45000, IsSettled = true },
            new Loan { Id = 8, BorrowerName = "Pooja Singh", LenderName = "Global Bank", Amount = 300000, IsSettled = false }
        };
        // GET: LoanController
        public ActionResult Index()
        {
            return View(loans);
        }

        // GET: LoanController/Details/5
        public ActionResult Details(int id)
        {
            Loan loan = null;

            for (int i = 0; i < loans.Count; i++)
            {
                if (loans[i].Id == id)
                {
                    loan = loans[i];
                    break;
                }
            }

            if (loan == null)
                return NotFound();

            return View(loan);
        }

        // GET: LoanController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoanController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Loan loan)
        {
            if (ModelState.IsValid)
            {
                loan.Id = loans.Count + 1;
                loans.Add(loan);

                return RedirectToAction(nameof(Index));
            }

            return View(loan);
        }

        // GET: LoanController/Edit/5
        public IActionResult Edit(int id)
        {
            Loan loan = null;

            for (int i = 0; i < loans.Count; i++)
            {
                if (loans[i].Id == id)
                {
                    loan = loans[i];
                    break;
                }
            }

            if (loan == null)
                return NotFound();

            return View(loan);
        }

        // POST: LoanController/Edit/5
        // EDIT - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Loan loan)
        {
            if (ModelState.IsValid)
            {
                var existingLoan = loans.FirstOrDefault(x => x.Id == id);

                if (existingLoan != null)
                {
                    existingLoan.BorrowerName = loan.BorrowerName;
                    existingLoan.LenderName = loan.LenderName;
                    existingLoan.Amount = loan.Amount;
                    existingLoan.IsSettled = loan.IsSettled;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(loan);
        }

        // GET: LoanController/Delete/5
        public IActionResult Delete(int id)
        {
            for (int i = 0; i < loans.Count; i++)
            {
                if (loans[i].Id == id)
                {
                    loans.RemoveAt(i);
                    break;
                }
            }

            return RedirectToAction("Index");
        }

    }
}
