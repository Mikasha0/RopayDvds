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
    public class CastMembersController : Controller
    {
        private readonly RopayDatabaseContext _context;

        public CastMembersController(RopayDatabaseContext context)
        {
            _context = context;
        }

        // GET: CastMembers
        public async Task<IActionResult> Index()
        {
            var ropayDatabaseContext = _context.CastMembers.Include(c => c.ActorNumberNavigation).Include(c => c.DvdNumberNavigation);
            return View(await ropayDatabaseContext.ToListAsync());
        }
        // GET: CastMembers/Create
        public IActionResult Create()
        {
            ViewData["ActorNumber"] = new SelectList(_context.Actors.Select(a=>new {ActorNumber=a.ActorNumber, ActorFirstName = a.ActorFirstName+ " "+a.ActorLastName }), "ActorNumber", "ActorFirstName");
            ViewData["DvdNumber"] = new SelectList(_context.DvdTitles, "DvdNumber", "DvdTite");
            return View();
        }

        // POST: CastMembers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DvdNumber,ActorNumber")] CastMember castMember)
        {
            if (ModelState.IsValid)
            {
                _context.Add(castMember);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActorNumber"] = new SelectList(_context.Actors.Select(a => new { ActorNumber = a.ActorNumber, ActorFirstName = a.ActorFirstName + " " + a.ActorLastName }), "ActorNumber", "ActorFirstName", castMember.ActorNumber);
            ViewData["DvdNumber"] = new SelectList(_context.DvdTitles, "DvdNumber", "DvdTite", castMember.DvdNumber);
            return View(castMember);
        }
        // GET: CastMembers/Delete/5
        public async Task<IActionResult> Delete(int aid,int did)
        {
            var castMember = await _context.CastMembers.Where(c=>c.ActorNumber==aid && c.DvdNumber==did).FirstOrDefaultAsync();
            _context.CastMembers.Remove(castMember);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
