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
    public class EducationRowsController : Controller
    {
        private readonly MyresumeInfoContext _context;

        public EducationRowsController(MyresumeInfoContext context)
        {
            _context = context;
        }

        // GET: EducationRows
        public async Task<IActionResult> Index()
        {
              return _context.EducationRows != null ? 
                          View(await _context.EducationRows.ToListAsync()) :
                          Problem("Entity set 'MyresumeInfoContext.EducationRows'  is null.");
        }

        // GET: EducationRows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EducationRows == null)
            {
                return NotFound();
            }

            var educationRow = await _context.EducationRows
                .FirstOrDefaultAsync(m => m.EducationRowId == id);
            if (educationRow == null)
            {
                return NotFound();
            }

            return View(educationRow);
        }

        // GET: EducationRows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EducationRows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EducationRowId,SchoolnameColumn,MajoyColumn,StartColumn,PeriodColumn,StageColumn")] EducationRow educationRow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(educationRow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(educationRow);
        }

        // GET: EducationRows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EducationRows == null)
            {
                return NotFound();
            }

            var educationRow = await _context.EducationRows.FindAsync(id);
            if (educationRow == null)
            {
                return NotFound();
            }
            return View(educationRow);
        }

        // POST: EducationRows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EducationRowId,SchoolnameColumn,MajoyColumn,StartColumn,PeriodColumn,StageColumn")] EducationRow educationRow)
        {
            if (id != educationRow.EducationRowId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(educationRow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EducationRowExists(educationRow.EducationRowId))
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
            return View(educationRow);
        }

        // GET: EducationRows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EducationRows == null)
            {
                return NotFound();
            }

            var educationRow = await _context.EducationRows
                .FirstOrDefaultAsync(m => m.EducationRowId == id);
            if (educationRow == null)
            {
                return NotFound();
            }

            return View(educationRow);
        }

        // POST: EducationRows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EducationRows == null)
            {
                return Problem("Entity set 'MyresumeInfoContext.EducationRows'  is null.");
            }
            var educationRow = await _context.EducationRows.FindAsync(id);
            if (educationRow != null)
            {
                _context.EducationRows.Remove(educationRow);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EducationRowExists(int id)
        {
          return (_context.EducationRows?.Any(e => e.EducationRowId == id)).GetValueOrDefault();
        }
    }
}
