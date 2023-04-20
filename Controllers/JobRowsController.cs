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
    public class JobRowsController : Controller
    {
        private readonly MyresumeInfoContext _context;

        public JobRowsController(MyresumeInfoContext context)
        {
            _context = context;
        }

        // GET: JobRows
        public async Task<IActionResult> Index()
        {
              return _context.JobRows != null ? 
                          View(await _context.JobRows.ToListAsync()) :
                          Problem("Entity set 'MyresumeInfoContext.JobRows'  is null.");
        }

        // GET: JobRows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.JobRows == null)
            {
                return NotFound();
            }

            var jobRow = await _context.JobRows
                .FirstOrDefaultAsync(m => m.JobRowId == id);
            if (jobRow == null)
            {
                return NotFound();
            }

            return View(jobRow);
        }

        // GET: JobRows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobRows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobRowId,CompanyNameColumn,TitleColumn,DutyColumn,InputColumn,OutputColumn")] JobRow jobRow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobRow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobRow);
        }

        // GET: JobRows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.JobRows == null)
            {
                return NotFound();
            }

            var jobRow = await _context.JobRows.FindAsync(id);
            if (jobRow == null)
            {
                return NotFound();
            }
            return View(jobRow);
        }

        // POST: JobRows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobRowId,CompanyNameColumn,TitleColumn,DutyColumn,InputColumn,OutputColumn")] JobRow jobRow)
        {
            if (id != jobRow.JobRowId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobRow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobRowExists(jobRow.JobRowId))
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
            return View(jobRow);
        }

        // GET: JobRows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.JobRows == null)
            {
                return NotFound();
            }

            var jobRow = await _context.JobRows
                .FirstOrDefaultAsync(m => m.JobRowId == id);
            if (jobRow == null)
            {
                return NotFound();
            }

            return View(jobRow);
        }

        // POST: JobRows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.JobRows == null)
            {
                return Problem("Entity set 'MyresumeInfoContext.JobRows'  is null.");
            }
            var jobRow = await _context.JobRows.FindAsync(id);
            if (jobRow != null)
            {
                _context.JobRows.Remove(jobRow);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobRowExists(int id)
        {
          return (_context.JobRows?.Any(e => e.JobRowId == id)).GetValueOrDefault();
        }
    }
}
