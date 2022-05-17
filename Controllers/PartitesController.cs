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
    public class PartitesController : Controller
    {
        private readonly PIPOSTEST_Context _context;

        public PartitesController(PIPOSTEST_Context context)
        {
            _context = context;
        }

        // GET: Partites
        public async Task<IActionResult> Index()
        {
            var pIPOSTEST_Context = _context.Partites.Include(p => p.Epoll);
            return View(await pIPOSTEST_Context.ToListAsync());
        }

        // GET: Partites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partite = await _context.Partites
                .Include(p => p.Epoll)
                .FirstOrDefaultAsync(m => m.PartiId == id);
            if (partite == null)
            {
                return NotFound();
            }

            return View(partite);
        }

        // GET: Partites/Create
        public IActionResult Create()
        {
            ViewData["EpollId"] = new SelectList(_context.ExitPolls, "EpollId", "EpollId");
            return View();
        }

        // POST: Partites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PartiId,EmriPartise,EpollId")] Partite partite)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partite);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EpollId"] = new SelectList(_context.ExitPolls, "EpollId", "EpollId", partite.EpollId);
            return View(partite);
        }

        // GET: Partites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partite = await _context.Partites.FindAsync(id);
            if (partite == null)
            {
                return NotFound();
            }
            ViewData["EpollId"] = new SelectList(_context.ExitPolls, "EpollId", "EpollId", partite.EpollId);
            return View(partite);
        }

        // POST: Partites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PartiId,EmriPartise,EpollId")] Partite partite)
        {
            if (id != partite.PartiId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartiteExists(partite.PartiId))
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
            ViewData["EpollId"] = new SelectList(_context.ExitPolls, "EpollId", "EpollId", partite.EpollId);
            return View(partite);
        }

        // GET: Partites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partite = await _context.Partites
                .Include(p => p.Epoll)
                .FirstOrDefaultAsync(m => m.PartiId == id);
            if (partite == null)
            {
                return NotFound();
            }

            return View(partite);
        }

        // POST: Partites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partite = await _context.Partites.FindAsync(id);
            _context.Partites.Remove(partite);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartiteExists(int id)
        {
            return _context.Partites.Any(e => e.PartiId == id);
        }
    }
}
