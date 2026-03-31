using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinTrackPro.Data;
using FinTrackPro.Models;

namespace FinTrackPro.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly FinTrackProContext _context;

        public TransactionsController(FinTrackProContext context)
        {
            _context = context;
        }

        // GET: Transactions
        public async Task<IActionResult> Index()
        {
            var finTrackProContext = _context.Transaction.Include(t => t.Account);
            return View(await finTrackProContext.ToListAsync());
        }

        // GET: Transactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .Include(t => t.Account)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // GET: Transactions/Create
        public IActionResult Create()
        {
            ViewData["AccountId"] = new SelectList(_context.Account, "Id", "AccountHolderName");
            ViewBag.CategoryList = new SelectList(new[] { "Credit", "Debit" });
            return View();
        }

        // POST: Transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Amount,Category,Date,AccountId")] Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                // update account balance based on category
                var account = await _context.Account.FindAsync(transaction.AccountId);
                if (account != null)
                {
                    if (!string.IsNullOrEmpty(transaction.Category) && transaction.Category.Equals("Credit", StringComparison.OrdinalIgnoreCase))
                    {
                        account.Balance += transaction.Amount;
                    }
                    else if (!string.IsNullOrEmpty(transaction.Category) && transaction.Category.Equals("Debit", StringComparison.OrdinalIgnoreCase))
                    {
                        account.Balance -= transaction.Amount;
                    }
                }

                _context.Transaction.Add(transaction);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Accounts", new { id = transaction.AccountId });
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "Id", "AccountHolderName", transaction.AccountId);
            ViewBag.CategoryList = new SelectList(new[] { "Credit", "Debit" });
            return View(transaction);
        }

        // GET: Transactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "Id", "AccountHolderName", transaction.AccountId);
            ViewBag.CategoryList = new SelectList(new[] { "Credit", "Debit" }, transaction.Category);
            return View(transaction);
        }

        // POST: Transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Amount,Category,Date,AccountId")] Transaction transaction)
        {
            if (id != transaction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // fetch existing transaction to compute balance adjustments
                    var existing = await _context.Transaction.AsNoTracking().FirstOrDefaultAsync(t => t.Id == id);
                    if (existing != null)
                    {
                        var oldAccount = await _context.Account.FindAsync(existing.AccountId);
                        var newAccount = await _context.Account.FindAsync(transaction.AccountId);

                        // helper to compute signed amount based on category
                        static double SignedAmount(Transaction t)
                        {
                            if (t == null) return 0;
                            if (!string.IsNullOrEmpty(t.Category) && t.Category.Equals("Credit", StringComparison.OrdinalIgnoreCase)) return t.Amount;
                            return -t.Amount;
                        }

                        if (oldAccount != null && newAccount != null && oldAccount.Id == newAccount.Id)
                        {
                            // same account: apply net change
                            var net = SignedAmount(transaction) - SignedAmount(existing);
                            oldAccount.Balance += net;
                        }
                        else
                        {
                            // revert old transaction effect
                            if (oldAccount != null)
                            {
                                if (!string.IsNullOrEmpty(existing.Category) && existing.Category.Equals("Credit", StringComparison.OrdinalIgnoreCase))
                                {
                                    oldAccount.Balance -= existing.Amount;
                                }
                                else if (!string.IsNullOrEmpty(existing.Category) && existing.Category.Equals("Debit", StringComparison.OrdinalIgnoreCase))
                                {
                                    oldAccount.Balance += existing.Amount;
                                }
                            }

                            // apply new transaction effect
                            if (newAccount != null)
                            {
                                if (!string.IsNullOrEmpty(transaction.Category) && transaction.Category.Equals("Credit", StringComparison.OrdinalIgnoreCase))
                                {
                                    newAccount.Balance += transaction.Amount;
                                }
                                else if (!string.IsNullOrEmpty(transaction.Category) && transaction.Category.Equals("Debit", StringComparison.OrdinalIgnoreCase))
                                {
                                    newAccount.Balance -= transaction.Amount;
                                }
                            }
                        }
                    }

                    _context.Update(transaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionExists(transaction.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.Account, "Id", "AccountHolderName", transaction.AccountId);
            ViewBag.CategoryList = new SelectList(new[] { "Credit", "Debit" }, transaction.Category);
            return View(transaction);
        }

        // GET: Transactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transaction = await _context.Transaction
                .Include(t => t.Account)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transaction = await _context.Transaction.FindAsync(id);
            if (transaction != null)
            {
                var account = await _context.Account.FindAsync(transaction.AccountId);
                if (account != null)
                {
                    if (!string.IsNullOrEmpty(transaction.Category) && transaction.Category.Equals("Credit", StringComparison.OrdinalIgnoreCase))
                    {
                        account.Balance -= transaction.Amount;
                    }
                    else if (!string.IsNullOrEmpty(transaction.Category) && transaction.Category.Equals("Debit", StringComparison.OrdinalIgnoreCase))
                    {
                        account.Balance += transaction.Amount;
                    }
                }

                _context.Transaction.Remove(transaction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionExists(int id)
        {
            return _context.Transaction.Any(e => e.Id == id);
        }
    }
}
