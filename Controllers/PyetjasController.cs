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
    public class PyetjasController : Controller
    {
        private readonly PIPOSTEST_Context _context;

        public PyetjasController(PIPOSTEST_Context context)
        {
            _context = context;
        }

        // GET: Pyetjas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pyetjas.ToListAsync());
        }

        // GET: Pyetjas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pyetja = await _context.Pyetjas
                .FirstOrDefaultAsync(m => m.PyetjaId == id);
            if (pyetja == null)
            {
                return NotFound();
            }

            return View(pyetja);
        }

        // GET: Pyetjas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pyetjas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PyetjaId,Pytja")] Pyetja pyetja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pyetja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pyetja);
        }

        // GET: Pyetjas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pyetja = await _context.Pyetjas.FindAsync(id);
            if (pyetja == null)
            {
                return NotFound();
            }
            return View(pyetja);
        }

        // POST: Pyetjas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("PyetjaId,Pytja")] Pyetja pyetja)
        {
            if (id != pyetja.PyetjaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pyetja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PyetjaExists(pyetja.PyetjaId))
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
            return View(pyetja);
        }

        // GET: Pyetjas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pyetja = await _context.Pyetjas
                .FirstOrDefaultAsync(m => m.PyetjaId == id);
            if (pyetja == null)
            {
                return NotFound();
            }

            return View(pyetja);
        }

        // POST: Pyetjas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var pyetja = await _context.Pyetjas.FindAsync(id);
            _context.Pyetjas.Remove(pyetja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PyetjaExists(string id)
        {
            return _context.Pyetjas.Any(e => e.PyetjaId == id);
        }
    }
}
