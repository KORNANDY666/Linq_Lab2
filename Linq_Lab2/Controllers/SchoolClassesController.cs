using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Linq_Lab2.Data;
using Linq_Lab2.Models;

namespace Linq_Lab2.Controllers
{
    public class SchoolClassesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SchoolClassesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SchoolClasses
        public async Task<IActionResult> Index()
        {
              return _context.SchoolClass != null ? 
                          View(await _context.SchoolClass.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.SchoolClass'  is null.");
        }

        // GET: SchoolClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SchoolClass == null)
            {
                return NotFound();
            }

            var schoolClass = await _context.SchoolClass
                .FirstOrDefaultAsync(m => m.SchoolClassId == id);
            if (schoolClass == null)
            {
                return NotFound();
            }

            return View(schoolClass);
        }

        // GET: SchoolClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SchoolClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SchoolClassId,StudentClass")] SchoolClass schoolClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(schoolClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(schoolClass);
        }

        // GET: SchoolClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SchoolClass == null)
            {
                return NotFound();
            }

            var schoolClass = await _context.SchoolClass.FindAsync(id);
            if (schoolClass == null)
            {
                return NotFound();
            }
            return View(schoolClass);
        }

        // POST: SchoolClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SchoolClassId,StudentClass")] SchoolClass schoolClass)
        {
            if (id != schoolClass.SchoolClassId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(schoolClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchoolClassExists(schoolClass.SchoolClassId))
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
            return View(schoolClass);
        }

        // GET: SchoolClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SchoolClass == null)
            {
                return NotFound();
            }

            var schoolClass = await _context.SchoolClass
                .FirstOrDefaultAsync(m => m.SchoolClassId == id);
            if (schoolClass == null)
            {
                return NotFound();
            }

            return View(schoolClass);
        }

        // POST: SchoolClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SchoolClass == null)
            {
                return Problem("Entity set 'ApplicationDbContext.SchoolClass'  is null.");
            }
            var schoolClass = await _context.SchoolClass.FindAsync(id);
            if (schoolClass != null)
            {
                _context.SchoolClass.Remove(schoolClass);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SchoolClassExists(int id)
        {
          return (_context.SchoolClass?.Any(e => e.SchoolClassId == id)).GetValueOrDefault();
        }
    }
}
