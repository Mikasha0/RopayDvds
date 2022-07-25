using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RopayDvd.Models;

namespace RopayDvd.Controllers
{
    public class DvdTitlesController : Controller
    {
        private readonly RopayDatabaseContext _context;

        public DvdTitlesController(RopayDatabaseContext context)
        {
            _context = context;
        }

        // GET: DvdTitles
        public async Task<IActionResult> Index()
        {
            var ropayDatabaseContext = _context.DvdTitles.Include(d => d.CategoryNumberNavigation).Include(d => d.ProducerNumberNavigation).Include(d => d.StudioNumberNavigation);
            return View(await ropayDatabaseContext.ToListAsync());
        }

        // GET: DvdTitles/Create
        public IActionResult Create()
        {
            ViewData["CategoryNumber"] = new SelectList(_context.DvdCategories, "CategoryNumber", "CategoryDescription");
            ViewData["ProducerNumber"] = new SelectList(_context.Producers, "ProducerNumber", "ProducerName");
            ViewData["StudioNumber"] = new SelectList(_context.Studios, "StudioNumber", "StudioName");
            ViewData["ActorNumber"] = new SelectList(_context.Actors.Select(a=>new {ActorNumber=a.ActorNumber,ActorName=a.ActorFirstName+" "+a.ActorLastName }), "ActorNumber", "ActorName");
            return View();
        }

        // POST: DvdTitles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DvdTitle dvdTitle,int SelectedCastMember)
        {
            if (ModelState.IsValid)
            {
                
                try
                {
                    _context.DvdTitles.Add(dvdTitle);
                    await _context.SaveChangesAsync();
                    CastMember cstMember = new CastMember { ActorNumber = SelectedCastMember, DvdNumber = dvdTitle.DvdNumber };
                    _context.CastMembers.Add(cstMember);
                    await _context.SaveChangesAsync();
                }
                catch { }                                
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryNumber"] = new SelectList(_context.DvdCategories, "CategoryNumber", "CategoryDescription", dvdTitle.CategoryNumber);
            ViewData["ProducerNumber"] = new SelectList(_context.Producers, "ProducerNumber", "ProducerName", dvdTitle.ProducerNumber);
            ViewData["StudioNumber"] = new SelectList(_context.Studios, "StudioNumber", "StudioName", dvdTitle.StudioNumber);
            ViewData["ActorNumber"] = new SelectList(_context.Actors.Select(a => new { ActorNumber = a.ActorNumber, ActorName = a.ActorFirstName + " " + a.ActorLastName }), "ActorNumber", "ActorName",SelectedCastMember);
            return View(dvdTitle);
        }

        // GET: DvdTitles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var dvdTitle = await _context.DvdTitles.FindAsync(id);
            ViewData["CategoryNumber"] = new SelectList(_context.DvdCategories, "CategoryNumber", "CategoryDescription", dvdTitle.CategoryNumber);
            ViewData["ProducerNumber"] = new SelectList(_context.Producers, "ProducerNumber", "ProducerName", dvdTitle.ProducerNumber);
            ViewData["StudioNumber"] = new SelectList(_context.Studios, "StudioNumber", "StudioName", dvdTitle.StudioNumber);
            return View(dvdTitle);
        }

        // POST: DvdTitles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DvdNumber,CategoryNumber,StudioNumber,ProducerNumber,DvdTite,DateReleased,StandardCharge,PenaltyCharge")] DvdTitle dvdTitle)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dvdTitle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {}
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryNumber"] = new SelectList(_context.DvdCategories, "CategoryNumber", "CategoryDescription", dvdTitle.CategoryNumber);
            ViewData["ProducerNumber"] = new SelectList(_context.Producers, "ProducerNumber", "ProducerName", dvdTitle.ProducerNumber);
            ViewData["StudioNumber"] = new SelectList(_context.Studios, "StudioNumber", "StudioName", dvdTitle.StudioNumber);
            return View(dvdTitle);
        }

        // GET: DvdTitles/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var dvdTitle = await _context.DvdTitles.FindAsync(id);
            _context.DvdTitles.Remove(dvdTitle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
