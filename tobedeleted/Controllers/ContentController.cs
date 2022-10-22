using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tobedeleted.Data;
using tobedeleted.Entities;

namespace tobedeleted.Controllers
{
    public class ContentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Content.ToListAsync());
        }

        public IActionResult Create(int categoryItemId, int categoryId)
        {
            Content content = new Content
            {
                CategoryId = categoryId,
                CatItemId = categoryItemId
            };

            return View(content);
        }

        // POST: Content/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,HTMLContent,VideoLink,CatItemId,CategoryId")] Content content)
        {
            if (ModelState.IsValid)
            {
                content.CategoryItem = await _context.CategoryItem.FindAsync(content.CatItemId);
                _context.Add(content);
                await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index), "CategoryItem", new {categoryId=content.CategoryId});
            }
            return View(content);
        }

        // GET: Content/Edit/5
        public async Task<IActionResult> Edit(int categoryItemId, int categoryId)
        {
            if (categoryItemId == 0)
            {
                return NotFound();
            }

            var content = await _context.Content.SingleOrDefaultAsync(item => item.CategoryItem.Id == categoryItemId);

            content.CategoryId = categoryId;
            
            if (content == null)
            {
                return NotFound();
            }
            return View(content);
        }

        // POST: Content/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,HTMLContent,VideoLink,CategoryId")] Content content)
        {
            if (id != content.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(content);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContentExists(content.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), "CategoryItem", new {categoryId=content.CategoryId});
            }
            return View(content);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var content = await _context.Content
                .FirstOrDefaultAsync(m => m.Id == id);
            if (content == null)
            {
                return NotFound();
            }

            return View(content);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var content = await _context.Content.FindAsync(id);
            _context.Content.Remove(content);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContentExists(int id)
        {
            return _context.Content.Any(e => e.Id == id);
        }
    }
}
