using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RopayDvd.Models;

namespace RopayDvd.Controllers
{
    [Authorize]
    public class LoansController : Controller
    {
        private readonly RopayDatabaseContext _context;

        public LoansController(RopayDatabaseContext context)
        {
            _context = context;
        }

        // GET: Loans
        public async Task<IActionResult> Index()
        {
            var ropayDatabaseContext = _context.Loans.Include(l => l.CopyNumberNavigation).Include(l => l.LoanTypeNumberNavigation).Include(l => l.MemberNumberNavigation);
            return View(await ropayDatabaseContext.ToListAsync());
        }
        // GET: Loans/Create
        public IActionResult Create()
        {
            ViewData["CopyNumber"] = new SelectList(_context.DvdCopies, "CopyNumber", "CopyNumber");
            ViewData["LoanTypeNumber"] = new SelectList(_context.LoanTypes, "LoanTypeNumber", "LoanTypeName");
            ViewData["MemberNumber"] = new SelectList(_context.Members.Select(m=>new {MemberNumber=m.MemberNumber,MemberName=m.MemberFirstName+" "+m.MemberLastName }), "MemberNumber", "MemberName");
            return View();
        }

        // POST: Loans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Loan loan)
        {
            loan.DateOut = DateTime.Today;
            loan.DateDue = DateTime.Today.AddDays(_context.LoanTypes.Find(loan.LoanTypeNumber).LoanDuration);
            if(DateTime.Today.Subtract(Convert.ToDateTime(_context.Members.Find(loan.MemberNumber).MemberDateOfBirth)).TotalDays<365*18)
            {
                ModelState.AddModelError("", "Age restricted.");
            }
            else if(_context.Loans.Where(l => l.MemberNumber == loan.MemberNumber && l.DateReturned == null).ToList().Count >= _context.Members.Include(m=>m.MembershipCategoryNumberNavigation).Where(m=>m.MemberNumber==loan.MemberNumber).First().MembershipCategoryNumberNavigation.MembershipCategoryTotalLoans)
            {
                ModelState.AddModelError("", "Loan quota full.");
            }
            else if (ModelState.IsValid)
            {
                _context.Add(loan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CopyNumber"] = new SelectList(_context.DvdCopies, "CopyNumber", "CopyNumber", loan.CopyNumber);
            ViewData["LoanTypeNumber"] = new SelectList(_context.LoanTypes, "LoanTypeNumber", "LoanTypeName", loan.LoanTypeNumber);
            ViewData["MemberNumber"] = new SelectList(_context.Members.Select(m => new { MemberNumber = m.MemberNumber, MemberName = m.MemberFirstName + " " + m.MemberLastName }), "MemberNumber", "MemberName");
            return View(loan);
        }

        // GET: Loans/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            var loan = await _context.Loans.FindAsync(id);
            ViewData["CopyNumber"] = new SelectList(_context.DvdCopies, "CopyNumber", "CopyNumber", loan.CopyNumber);
            ViewData["LoanTypeNumber"] = new SelectList(_context.LoanTypes, "LoanTypeNumber", "LoanTypeName", loan.LoanTypeNumber);
            ViewData["MemberNumber"] = new SelectList(_context.Members.Select(m => new { MemberNumber = m.MemberNumber, MemberName = m.MemberFirstName + " " + m.MemberLastName }), "MemberNumber", "MemberName");
            return View(loan);
        }

        // POST: Loans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("LoanNumber,LoanTypeNumber,CopyNumber,MemberNumber,DateOut,DateDue,DateReturned")] Loan loan)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {}
                return RedirectToAction(nameof(Index));
            }
            ViewData["CopyNumber"] = new SelectList(_context.DvdCopies, "CopyNumber", "CopyNumber", loan.CopyNumber);
            ViewData["LoanTypeNumber"] = new SelectList(_context.LoanTypes, "LoanTypeNumber", "LoanTypeName", loan.LoanTypeNumber);
            ViewData["MemberNumber"] = new SelectList(_context.Members.Select(m => new { MemberNumber = m.MemberNumber, MemberName = m.MemberFirstName + " " + m.MemberLastName }), "MemberNumber", "MemberName");
            return View(loan);
        }

        // GET: Loans/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            var loan = await _context.Loans.FindAsync(id);
            _context.Loans.Remove(loan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> ReturnDVDCopy(long id)//required by report 7
        {
            var loan = await _context.Loans.FindAsync(id);
            loan.DateReturned = DateTime.Today;
            try
            {
                _context.Update(loan);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            { }
            return RedirectToAction("Report7","Reports");
        }
    }
}
