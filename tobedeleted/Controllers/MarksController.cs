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
    public class MarksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MarksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Marks
        public async Task<IActionResult> Index()
        {
            ViewBag.Users = (from Ur in _context.UserRoles
                             join U in _context.Users on Ur.UserId equals U.Id
                             join R in _context.Roles on Ur.RoleId equals R.Id
                             where Ur.UserId == U.Id && Ur.RoleId == R.Id && R.Name == "Learner"
                             select new ApplicationUser { Id = U.Id, firstName = U.firstName, lastName = U.lastName }).ToList();

            ViewBag.Mark = (from M in _context.Marks
                            join S in _context.Subjects on M.SubID equals S.SubID
                            //from Su in _db.Subjects
                            //join L in _db.Learner on Su.learnerId equals L.learnerId
                            from Us in _context.Users
                            join L in _context.Learner on Us.Id equals L.userLearnerId

                            where M.SubID == S.SubID && L.learnerId == M.learnerId
                            select new AssignMarks { marks = M, subject = S, learner = L }).ToList();

            return View(await _context.StuMarks.ToListAsync());

        }

        // GET: Marks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marks = await _context.Marks
                .FirstOrDefaultAsync(m => m.MarksId == id);
            if (marks == null)
            {
                return NotFound();
            }

            return View(marks);
        }

        // GET: Marks/Create
        public IActionResult Create()
        {
            ViewBag.Users = (from Ur in _context.UserRoles
                             join U in _context.Users on Ur.UserId equals U.Id
                             join R in _context.Roles on Ur.RoleId equals R.Id
                             where Ur.UserId == U.Id && Ur.RoleId == R.Id && R.Name == "Learner"
                             select new ApplicationUser { Id = U.Id, firstName = U.firstName, lastName = U.lastName }).ToList();

            ViewBag.Mark = (from M in _context.Marks
                            join S in _context.Subjects on M.SubID equals S.SubID
                            //from Su in _db.Subjects
                            //join L in _db.Learner on Su.learnerId equals L.learnerId
                            from Us in _context.Users
                            join L in _context.Learner on Us.Id equals L.userLearnerId

                            where M.SubID == S.SubID && L.learnerId == M.learnerId
                            select new AssignMarks { marks = M, subject = S, learner = L }).ToList();



            ViewBag.Assign = (from S in _context.StuMarks
                              join L in _context.Users on S.LearnerIdUser equals L.Id
                              from A in _context.AssignLearnerToParent
                              join l  in _context.Users on A.userLearnerId equals l.Id
                              join P in _context.Users on A.userParent equals P.Id

                              where S.LearnerIdUser == L.Id && A.userParent==l.Id
                              select new StuMark {});



            return View();
        }

        // POST: Marks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StuMark stuMark)
        {
           
            if (ModelState.IsValid)
            {
                _context.Add(stuMark);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stuMark);
        }

        // GET: Marks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marks = await _context.Marks.FindAsync(id);
            if (marks == null)
            {
                return NotFound();
            }
            return View(marks);
        }

        // POST: Marks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MarksId,learnerId,AssignmentID,SubID,Term1,Term2,Term3,Term4")] Marks marks)
        {
            if (id != marks.MarksId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarksExists(marks.MarksId))
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
            return View(marks);
        }

        // GET: Marks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var marks = await _context.Marks
                .FirstOrDefaultAsync(m => m.MarksId == id);
            if (marks == null)
            {
                return NotFound();
            }

            return View(marks);
        }

        // POST: Marks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var marks = await _context.Marks.FindAsync(id);
            _context.Marks.Remove(marks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarksExists(int id)
        {

            return _context.Marks.Any(e => e.MarksId == id);
        }
    }
}
