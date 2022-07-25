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
    public class DvdCopiesController : Controller
    {
        private readonly RopayDatabaseContext _context;

        public DvdCopiesController(RopayDatabaseContext context)
        {
            _context = context;
        }

        // GET: DvdCopies
        public async Task<IActionResult> Index()
        {
            var ropayDatabaseContext = _context.DvdCopies.Include(d => d.DvdNumberNavigation);
            return View(await ropayDatabaseContext.ToListAsync());
        }
        
        // GET: DvdCopies/Create
        public IActionResult Create()
        {
            ViewData["DvdNumber"] = new SelectList(_context.DvdTitles, "DvdNumber", "DvdTite");
            return View();
        }

        // POST: DvdCopies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CopyNumber,DvdNumber,DatePurchased")] DvdCopy dvdCopy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dvdCopy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DvdNumber"] = new SelectList(_context.DvdTitles, "DvdNumber", "DvdTite", dvdCopy.DvdNumber);
            return View(dvdCopy);
        }

        // GET: DvdCopies/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            var dvdCopy = await _context.DvdCopies.FindAsync(id);
            ViewData["DvdNumber"] = new SelectList(_context.DvdTitles, "DvdNumber", "DvdTite", dvdCopy.DvdNumber);
            return View(dvdCopy);
        }

        // POST: DvdCopies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("CopyNumber,DvdNumber,DatePurchased")] DvdCopy dvdCopy)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dvdCopy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {}
                return RedirectToAction(nameof(Index));
            }
            ViewData["DvdNumber"] = new SelectList(_context.DvdTitles, "DvdNumber", "DvdTite", dvdCopy.DvdNumber);
            return View(dvdCopy);
        }

        // GET: DvdCopies/Delete/5
        public async Task<IActionResult> Delete(long id,string ctrName)//ctrName not null means request from report10
        {
            var dvdCopy = await _context.DvdCopies.FindAsync(id);
            _context.DvdCopies.Remove(dvdCopy);
            await _context.SaveChangesAsync();
            if (string.IsNullOrEmpty(ctrName))
                return RedirectToAction(nameof(Index));
            else
                return RedirectToAction("Report10", ctrName);
        }
    }
}
