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
    public class MembershipCategoriesController : Controller
    {
        private readonly RopayDatabaseContext _context;

        public MembershipCategoriesController(RopayDatabaseContext context)
        {
            _context = context;
        }

        // GET: MembershipCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.MembershipCategories.ToListAsync());
        }
        
        // GET: MembershipCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MembershipCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MembershipCategoryNumber,MembershipCategoryDescription,MembershipCategoryTotalLoans")] MembershipCategory membershipCategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(membershipCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(membershipCategory);
        }

        // GET: MembershipCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var membershipCategory = await _context.MembershipCategories.FindAsync(id);
            return View(membershipCategory);
        }

        // POST: MembershipCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MembershipCategoryNumber,MembershipCategoryDescription,MembershipCategoryTotalLoans")] MembershipCategory membershipCategory)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(membershipCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {}
                return RedirectToAction(nameof(Index));
            }
            return View(membershipCategory);
        }

        // GET: MembershipCategories/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var membershipCategory = await _context.MembershipCategories.FindAsync(id);
            _context.MembershipCategories.Remove(membershipCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
