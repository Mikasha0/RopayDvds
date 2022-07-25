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
    public class RopayUsersController : Controller
    {
        private readonly RopayDatabaseContext _context;

        public RopayUsersController(RopayDatabaseContext context)
        {
            _context = context;
        }

        // GET: RopayUsers
        public async Task<IActionResult> Index()
        {
            if(User.IsInRole("Manager"))//manager can see every user's detail
                return View(await _context.RopayUsers.ToListAsync());
            else//Assistant can view thier own details
                return View(await _context.RopayUsers.Where(u=>u.UserName.Equals(User.Identity.Name)).ToListAsync());
        }
        // GET: RopayUsers/Create
        [Authorize(Roles ="Manager")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: RopayUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Create([Bind("UserNumber,UserName,UserType,UserPassword")] RopayUser ropayUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ropayUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ropayUser);
        }

        // GET: RopayUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var ropayUser = await _context.RopayUsers.FindAsync(id);
            return View(ropayUser);
        }

        // POST: RopayUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserNumber,UserName,UserType,UserPassword")] RopayUser ropayUser)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ropayUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {}
                return RedirectToAction(nameof(Index));
            }
            return View(ropayUser);
        }

        // GET: RopayUsers/Delete/5
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Delete(int? id)
        {
            var ropayUser = await _context.RopayUsers.FindAsync(id);
            _context.RopayUsers.Remove(ropayUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
