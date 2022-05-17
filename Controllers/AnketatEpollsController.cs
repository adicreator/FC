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
    public class AnketatEpollsController : Controller
    {
        private readonly PIPOSTEST_Context _context;

        public AnketatEpollsController(PIPOSTEST_Context context)
        {
            _context = context;
        }

        // GET: AnketatEpolls
        public async Task<IActionResult> Index()
        {
            var pIPOSTEST_Context = _context.AnketatEpolls.Include(a => a.Qyteti).Include(a => a.Shteti).Include(a => a.Vendvotimi).Include(a => a.Zona);
            return View(await pIPOSTEST_Context.ToListAsync());
        }

        // GET: AnketatEpolls/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anketatEpoll = await _context.AnketatEpolls
                .Include(a => a.Qyteti)
                .Include(a => a.Shteti)
                .Include(a => a.Vendvotimi)
                .Include(a => a.Zona)
                .FirstOrDefaultAsync(m => m.AnketaEpId == id);
            if (anketatEpoll == null)
            {
                return NotFound();
            }

            return View(anketatEpoll);
        }

        // GET: AnketatEpolls/Create
        public IActionResult Create()
        {
            ViewData["QytetiId"] = new SelectList(_context.Qytetets, "QytetiId", "QytetiId");
            ViewData["ShtetiId"] = new SelectList(_context.Shtetets, "ShtetiId", "ShtetiId");
            ViewData["VendvotimiId"] = new SelectList(_context.Vendvotimis, "NumriVendvotimit", "NumriVendvotimit");
            ViewData["ZonaId"] = new SelectList(_context.Zonas, "ZonaId", "ZonaId");
            return View();
        }

        // POST: AnketatEpolls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AnketaEpId,ShtetiId,QytetiId,ZonaId,VendvotimiId,Mosha,Gjinia")] AnketatEpoll anketatEpoll)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anketatEpoll);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["QytetiId"] = new SelectList(_context.Qytetets, "QytetiId", "QytetiId", anketatEpoll.QytetiId);
            ViewData["ShtetiId"] = new SelectList(_context.Shtetets, "ShtetiId", "ShtetiId", anketatEpoll.ShtetiId);
            ViewData["VendvotimiId"] = new SelectList(_context.Vendvotimis, "NumriVendvotimit", "NumriVendvotimit", anketatEpoll.VendvotimiId);
            ViewData["ZonaId"] = new SelectList(_context.Zonas, "ZonaId", "ZonaId", anketatEpoll.ZonaId);
            return View(anketatEpoll);
        }

        // GET: AnketatEpolls/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anketatEpoll = await _context.AnketatEpolls.FindAsync(id);
            if (anketatEpoll == null)
            {
                return NotFound();
            }
            ViewData["QytetiId"] = new SelectList(_context.Qytetets, "QytetiId", "QytetiId", anketatEpoll.QytetiId);
            ViewData["ShtetiId"] = new SelectList(_context.Shtetets, "ShtetiId", "ShtetiId", anketatEpoll.ShtetiId);
            ViewData["VendvotimiId"] = new SelectList(_context.Vendvotimis, "NumriVendvotimit", "NumriVendvotimit", anketatEpoll.VendvotimiId);
            ViewData["ZonaId"] = new SelectList(_context.Zonas, "ZonaId", "ZonaId", anketatEpoll.ZonaId);
            return View(anketatEpoll);
        }

        // POST: AnketatEpolls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AnketaEpId,ShtetiId,QytetiId,ZonaId,VendvotimiId,Mosha,Gjinia")] AnketatEpoll anketatEpoll)
        {
            if (id != anketatEpoll.AnketaEpId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anketatEpoll);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnketatEpollExists(anketatEpoll.AnketaEpId))
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
            ViewData["QytetiId"] = new SelectList(_context.Qytetets, "QytetiId", "QytetiId", anketatEpoll.QytetiId);
            ViewData["ShtetiId"] = new SelectList(_context.Shtetets, "ShtetiId", "ShtetiId", anketatEpoll.ShtetiId);
            ViewData["VendvotimiId"] = new SelectList(_context.Vendvotimis, "NumriVendvotimit", "NumriVendvotimit", anketatEpoll.VendvotimiId);
            ViewData["ZonaId"] = new SelectList(_context.Zonas, "ZonaId", "ZonaId", anketatEpoll.ZonaId);
            return View(anketatEpoll);
        }

        // GET: AnketatEpolls/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var anketatEpoll = await _context.AnketatEpolls
                .Include(a => a.Qyteti)
                .Include(a => a.Shteti)
                .Include(a => a.Vendvotimi)
                .Include(a => a.Zona)
                .FirstOrDefaultAsync(m => m.AnketaEpId == id);
            if (anketatEpoll == null)
            {
                return NotFound();
            }

            return View(anketatEpoll);
        }

        // POST: AnketatEpolls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var anketatEpoll = await _context.AnketatEpolls.FindAsync(id);
            _context.AnketatEpolls.Remove(anketatEpoll);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnketatEpollExists(string id)
        {
            return _context.AnketatEpolls.Any(e => e.AnketaEpId == id);
        }
    }
}
