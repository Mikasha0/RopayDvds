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
    public class LoanTypesController : Controller
    {
        private readonly RopayDatabaseContext _context;

        public LoanTypesController(RopayDatabaseContext context)
        {
            _context = context;
        }

        // GET: LoanTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoanTypes.ToListAsync());
        }

      // GET: LoanTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LoanTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LoanTypeNumber,LoanTypeName,LoanDuration")] LoanType loanType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loanType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loanType);
        }

        // GET: LoanTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var loanType = await _context.LoanTypes.FindAsync(id);            
            return View(loanType);
        }

        // POST: LoanTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LoanTypeNumber,LoanTypeName,LoanDuration")] LoanType loanType)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loanType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {}
                return RedirectToAction(nameof(Index));
            }
            return View(loanType);
        }

        // GET: LoanTypes/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var loanType = await _context.LoanTypes.FindAsync(id);
            _context.LoanTypes.Remove(loanType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
