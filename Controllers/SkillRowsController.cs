using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyResumeOfWPF.PDO;
using MyresumeWebApplication.Data;

namespace MyresumeWebApplication.Controllers
{
    [Authorize]
    public class SkillRowsController : Controller
    {
        private readonly MyresumeInfoContext _context;

        public SkillRowsController(MyresumeInfoContext context)
        {
            _context = context;
        }

        // GET: SkillRows
        public async Task<IActionResult> Index()
        {
              return _context.SkillRows != null ? 
                          View(await _context.SkillRows.ToListAsync()) :
                          Problem("Entity set 'MyresumeInfoContext.SkillRows'  is null.");
        }

        // GET: SkillRows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SkillRows == null)
            {
                return NotFound();
            }

            var skillRow = await _context.SkillRows
                .FirstOrDefaultAsync(m => m.SkillRowId == id);
            if (skillRow == null)
            {
                return NotFound();
            }

            return View(skillRow);
        }

        // GET: SkillRows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SkillRows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SkillRowId,ComponentOneColumn,ComponentTwoColumn,ComponentThreeColumn,ComponentFourColumn,TopicColumn")] SkillRow skillRow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(skillRow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(skillRow);
        }

        // GET: SkillRows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SkillRows == null)
            {
                return NotFound();
            }

            var skillRow = await _context.SkillRows.FindAsync(id);
            if (skillRow == null)
            {
                return NotFound();
            }
            return View(skillRow);
        }

        // POST: SkillRows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SkillRowId,ComponentOneColumn,ComponentTwoColumn,ComponentThreeColumn,ComponentFourColumn,TopicColumn")] SkillRow skillRow)
        {
            if (id != skillRow.SkillRowId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(skillRow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkillRowExists(skillRow.SkillRowId))
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
            return View(skillRow);
        }

        // GET: SkillRows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SkillRows == null)
            {
                return NotFound();
            }

            var skillRow = await _context.SkillRows
                .FirstOrDefaultAsync(m => m.SkillRowId == id);
            if (skillRow == null)
            {
                return NotFound();
            }

            return View(skillRow);
        }

        // POST: SkillRows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SkillRows == null)
            {
                return Problem("Entity set 'MyresumeInfoContext.SkillRows'  is null.");
            }
            var skillRow = await _context.SkillRows.FindAsync(id);
            if (skillRow != null)
            {
                _context.SkillRows.Remove(skillRow);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SkillRowExists(int id)
        {
          return (_context.SkillRows?.Any(e => e.SkillRowId == id)).GetValueOrDefault();
        }
    }
}
