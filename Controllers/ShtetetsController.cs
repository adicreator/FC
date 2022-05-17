#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheTjerrs.Models;

namespace TheTjerrs.Controllers
{
    public class ShtetetsController : Controller
    {
        private readonly PIPOSTEST_Context _context;

        public ShtetetsController(PIPOSTEST_Context context)
        {
            _context = context;
        }

        // GET: Shtetets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Shtetets.ToListAsync());
        }

        // GET: Shtetets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shtetet = await _context.Shtetets
                .FirstOrDefaultAsync(m => m.ShtetiId == id);
            if (shtetet == null)
            {
                return NotFound();
            }

            return View(shtetet);
        }

        // GET: Shtetets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shtetets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShtetiId,EmriShtetit,NumriBanorve")] Shtetet shtetet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shtetet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shtetet);
        }

        // GET: Shtetets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shtetet = await _context.Shtetets.FindAsync(id);
            if (shtetet == null)
            {
                return NotFound();
            }
            return View(shtetet);
        }

        // POST: Shtetets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShtetiId,EmriShtetit,NumriBanorve")] Shtetet shtetet)
        {
            if (id != shtetet.ShtetiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shtetet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShtetetExists(shtetet.ShtetiId))
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
            return View(shtetet);
        }

        // GET: Shtetets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shtetet = await _context.Shtetets
                .FirstOrDefaultAsync(m => m.ShtetiId == id);
            if (shtetet == null)
            {
                return NotFound();
            }

            return View(shtetet);
        }

        // POST: Shtetets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shtetet = await _context.Shtetets.FindAsync(id);
            _context.Shtetets.Remove(shtetet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShtetetExists(int id)
        {
            return _context.Shtetets.Any(e => e.ShtetiId == id);
        }
    }
}
