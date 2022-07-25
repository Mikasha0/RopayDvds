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
    public class MembersController : Controller
    {
        private readonly RopayDatabaseContext _context;

        public MembersController(RopayDatabaseContext context)
        {
            _context = context;
        }

        // GET: Members
        public async Task<IActionResult> Index()
        {
            var ropayDatabaseContext = _context.Members.Include(m => m.MembershipCategoryNumberNavigation);
            return View(await ropayDatabaseContext.ToListAsync());
        }
        // GET: Members/Create
        public IActionResult Create()
        {
            ViewData["MembershipCategoryNumber"] = new SelectList(_context.MembershipCategories, "MembershipCategoryNumber", "MembershipCategoryDescription");
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MemberNumber,MembershipCategoryNumber,MemberLastName,MemberFirstName,MemberAddress,MemberDateOfBirth")] Member member)
        {
            if (ModelState.IsValid)
            {
                _context.Add(member);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MembershipCategoryNumber"] = new SelectList(_context.MembershipCategories, "MembershipCategoryNumber", "MembershipCategoryDescription", member.MembershipCategoryNumber);
            return View(member);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            var member = await _context.Members.FindAsync(id);
            ViewData["MembershipCategoryNumber"] = new SelectList(_context.MembershipCategories, "MembershipCategoryNumber", "MembershipCategoryDescription", member.MembershipCategoryNumber);
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("MemberNumber,MembershipCategoryNumber,MemberLastName,MemberFirstName,MemberAddress,MemberDateOfBirth")] Member member)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {}
                return RedirectToAction(nameof(Index));
            }
            ViewData["MembershipCategoryNumber"] = new SelectList(_context.MembershipCategories, "MembershipCategoryNumber", "MembershipCategoryDescription", member.MembershipCategoryNumber);
            return View(member);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(long id)
        {
            var member = await _context.Members.FindAsync(id);
            _context.Members.Remove(member);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
