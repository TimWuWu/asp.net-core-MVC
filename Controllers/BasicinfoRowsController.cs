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
    public class BasicinfoRowsController : Controller
    {
        private readonly MyresumeInfoContext _context;

        public BasicinfoRowsController(MyresumeInfoContext context)
        {
            _context = context;
        }

        // GET: BasicinfoRows
        public async Task<IActionResult> Index()
        {
              return _context.BasicinfoRows != null ? 
                          View(await _context.BasicinfoRows.ToListAsync()) :
                          Problem("Entity set 'MyresumeInfoContext.BasicinfoRows'  is null.");
        }

        // GET: BasicinfoRows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BasicinfoRows == null)
            {
                return NotFound();
            }

            var basicinfoRow = await _context.BasicinfoRows
                .FirstOrDefaultAsync(m => m.BasicinfoRowId == id);
            if (basicinfoRow == null)
            {
                return NotFound();
            }

            return View(basicinfoRow);
        }

        // GET: BasicinfoRows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BasicinfoRows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BasicinfoRowId,NameColumn,AddressColumn,AgeColumn,EmailColumn,PhonenumberColumn,ExperienceColumn")] BasicinfoRow basicinfoRow)
        {
            if (ModelState.IsValid)
            {
                //个人信息有唯一性，这里是保证唯一性的逻辑
                if (_context.BasicinfoRows.Count()==0)
                {
                    _context.Add(basicinfoRow);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _context.BasicinfoRows.Remove(_context.BasicinfoRows.First());
                    _context.Add(basicinfoRow);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(basicinfoRow);
        }

        // GET: BasicinfoRows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BasicinfoRows == null)
            {
                return NotFound();
            }

            var basicinfoRow = await _context.BasicinfoRows.FindAsync(id);
            if (basicinfoRow == null)
            {
                return NotFound();
            }
            return View(basicinfoRow);
        }

        // POST: BasicinfoRows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BasicinfoRowId,NameColumn,AddressColumn,AgeColumn,EmailColumn,PhonenumberColumn,ExperienceColumn")] BasicinfoRow basicinfoRow)
        {
            if (id != basicinfoRow.BasicinfoRowId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(basicinfoRow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BasicinfoRowExists(basicinfoRow.BasicinfoRowId))
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
            return View(basicinfoRow);
        }

        // GET: BasicinfoRows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BasicinfoRows == null)
            {
                return NotFound();
            }

            var basicinfoRow = await _context.BasicinfoRows
                .FirstOrDefaultAsync(m => m.BasicinfoRowId == id);
            if (basicinfoRow == null)
            {
                return NotFound();
            }

            return View(basicinfoRow);
        }

        // POST: BasicinfoRows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BasicinfoRows == null)
            {
                return Problem("Entity set 'MyresumeInfoContext.BasicinfoRows'  is null.");
            }
            var basicinfoRow = await _context.BasicinfoRows.FindAsync(id);
            if (basicinfoRow != null)
            {
                _context.BasicinfoRows.Remove(basicinfoRow);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BasicinfoRowExists(int id)
        {
          return (_context.BasicinfoRows?.Any(e => e.BasicinfoRowId == id)).GetValueOrDefault();
        }
    }
}
