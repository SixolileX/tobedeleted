using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tobedeleted.Data;
using tobedeleted.Models;

namespace tobedeleted.Controllers
{
    public class MeetingSchedulersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MeetingSchedulersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MeetingSchedulers
        public async Task<IActionResult> Index()
        {
            return View(await _context.MeetingScheduler.ToListAsync());
        }

        // GET: MeetingSchedulers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingScheduler = await _context.MeetingScheduler
                .FirstOrDefaultAsync(m => m.MeetingID == id);
            if (meetingScheduler == null)
            {
                return NotFound();
            }

            return View(meetingScheduler);
        }

        // GET: MeetingSchedulers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MeetingSchedulers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MeetingID,SetDate,MeetingDate,Desc,userID")] MeetingScheduler meetingScheduler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meetingScheduler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meetingScheduler);
        }

        // GET: MeetingSchedulers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingScheduler = await _context.MeetingScheduler.FindAsync(id);
            if (meetingScheduler == null)
            {
                return NotFound();
            }
            return View(meetingScheduler);
        }

        // POST: MeetingSchedulers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MeetingID,SetDate,MeetingDate,Desc,userID")] MeetingScheduler meetingScheduler)
        {
            if (id != meetingScheduler.MeetingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meetingScheduler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetingSchedulerExists(meetingScheduler.MeetingID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(meetingScheduler);
        }

        // GET: MeetingSchedulers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meetingScheduler = await _context.MeetingScheduler
                .FirstOrDefaultAsync(m => m.MeetingID == id);
            if (meetingScheduler == null)
            {
                return NotFound();
            }

            return View(meetingScheduler);
        }

        // POST: MeetingSchedulers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meetingScheduler = await _context.MeetingScheduler.FindAsync(id);
            _context.MeetingScheduler.Remove(meetingScheduler);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetingSchedulerExists(int id)
        {
            return _context.MeetingScheduler.Any(e => e.MeetingID == id);
        }
    }
}
