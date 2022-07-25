using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RopayDvd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RopayDvd.Controllers
{
    [Authorize]
    public class ReportsController : Controller
    {
        private readonly RopayDatabaseContext _context;

        public ReportsController(RopayDatabaseContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Report1(int SelectedActorId=0)
        {
            ViewBag.ActorList =new SelectList( await _context.Actors.ToListAsync(),nameof(Actor.ActorNumber),nameof(Actor.ActorLastName),SelectedActorId);
            return View(await _context.CastMembers.Include(c=>c.DvdNumberNavigation).Where(c=>c.ActorNumber==SelectedActorId).ToListAsync());
        }
        [AllowAnonymous]
        public async Task<IActionResult> Report2(int SelectedActorId = 0)
        {
            ViewBag.ActorList = new SelectList(await _context.Actors.ToListAsync(), nameof(Actor.ActorNumber), nameof(Actor.ActorLastName), SelectedActorId);
            return View(await _context.CastMembers.Include(c => c.DvdNumberNavigation).ThenInclude(c=>c.DvdCopies.Where(d=>_context.Loans.Where(l=>l.DateReturned==null &&l.CopyNumber==d.CopyNumber).FirstOrDefault()==null)).Where(c => c.ActorNumber == SelectedActorId).ToListAsync());
        }
        public async Task<IActionResult> Report3(int SelectedMemberId = 0)
        {
            ViewBag.MemberList = new SelectList(await _context.Members.ToListAsync(), nameof(Member.MemberNumber), nameof(Member.MemberLastName), SelectedMemberId);
            return View(await _context.Loans.Include(l=>l.CopyNumberNavigation).ThenInclude(c => c.DvdNumberNavigation).Where(l => l.MemberNumber == SelectedMemberId && l.DateOut>=DateTime.Today.AddDays(-31)).ToListAsync());
        }
        public async Task<IActionResult> Report4()
        {
            var loans = _context.DvdTitles.Include(d=>d.ProducerNumberNavigation).Include(d=>d.StudioNumberNavigation).Include(d=>d.CastMembers.OrderBy(d=>d.ActorNumberNavigation.ActorLastName)).ThenInclude(c=>c.ActorNumberNavigation).OrderBy(d=>d.DateReleased).ThenBy(d=>d.DvdTite);
            return View(await loans.ToListAsync());
        }
        public async Task<IActionResult> Report5(long SelectedCopyId = 0)
        {
            ViewBag.CopyList = new SelectList(await _context.DvdCopies.ToListAsync(), nameof(DvdCopy.CopyNumber), nameof(DvdCopy.CopyNumber), SelectedCopyId);
            return View(await _context.Loans.Include(l=>l.MemberNumberNavigation).Include(l => l.CopyNumberNavigation).ThenInclude(c => c.DvdNumberNavigation).Where(l => l.CopyNumber == SelectedCopyId).ToListAsync());
        }
        public IActionResult Report6()
        {
            return RedirectToAction("Create", "Loans");
        }
        public async Task<IActionResult> Report7()
        {
            var loans = _context.Loans.Include(l => l.CopyNumberNavigation).ThenInclude(l=>l.DvdNumberNavigation).Include(l => l.LoanTypeNumberNavigation).Include(l => l.MemberNumberNavigation).Where(l=>l.DateReturned==null);
            return View(await loans.ToListAsync());
        }
        public async Task<IActionResult> Report8()
        {
            var members = _context.Members.Include(m=>m.MembershipCategoryNumberNavigation).Include(m=>m.Loans.Where(l=>l.DateReturned==null)).OrderBy(m=>m.MemberFirstName).ThenBy(m=>m.MemberLastName);
            return View(await members.ToListAsync());
        }
        public IActionResult Report9()
        {
            return RedirectToAction("Create", "DvdTitles");
        }
        
        public async Task<IActionResult> Report10()
        {
            var copies = _context.DvdCopies.Include(c=>c.DvdNumberNavigation).Include(c=>c.Loans.Where(l=>l.DateReturned==null)).Where(d=>d.Loans.Count==0 && d.DatePurchased<DateTime.Today.AddDays(-365));
            return View(await copies.ToListAsync());
        }
        
        public async Task<IActionResult> Report11()
        {
            var loans = _context.Loans.Include(l=>l.MemberNumberNavigation).Include(l=>l.CopyNumberNavigation).ThenInclude(l=>l.DvdNumberNavigation).Where(l => l.DateReturned == null).OrderBy(l=>l.DateOut).ThenBy(l=>l.CopyNumberNavigation.DvdNumberNavigation.DvdTite);
            return View(await loans.ToListAsync());
        }        
        public async Task<IActionResult> Report12()
        {
            var loans = _context.Loans.Include(l=>l.CopyNumberNavigation).ThenInclude(l=>l.DvdNumberNavigation).Include(l => l.MemberNumberNavigation).Where(l=>l.DateOut==_context.Loans.Where(ml=>ml.MemberNumber==l.MemberNumber).Max(ml=>ml.DateOut) && l.DateOut < DateTime.Today.AddDays(-31)).OrderBy(m=> m.DateOut);
            return View(await loans.ToListAsync());
        }
        public async Task<IActionResult> Report13()
        {
            var dvdTitles = _context.DvdTitles.Include(d=>d.DvdCopies).ThenInclude(d => d.Loans.Where(l => l.DateOut>=DateTime.Today.AddDays(-31))).Where(d=>d.DvdCopies.Count==0);
            return View(await dvdTitles.ToListAsync());
        }
    }
}
