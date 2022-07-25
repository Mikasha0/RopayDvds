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
    public class DvdCategoriesController : Controller
    {
        private readonly RopayDatabaseContext _context;

        public DvdCategoriesController(RopayDatabaseContext context)
        {
            _context = context;
        }

        // GET: DvdCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.DvdCategories.ToListAsync());
        }       
        // GET: DvdCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DvdCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryNumber,CategoryDescription,AgeRestricted")] DvdCategory dvdCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dvdCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dvdCategory);
        }

        // GET: DvdCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var dvdCategory = await _context.DvdCategories.FindAsync(id);
            return View(dvdCategory);
        }

        // POST: DvdCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryNumber,CategoryDescription,AgeRestricted")] DvdCategory dvdCategory)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dvdCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                   
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dvdCategory);
        }

        // GET: DvdCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var dvdCategory = await _context.DvdCategories.FindAsync(id);
            _context.DvdCategories.Remove(dvdCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
