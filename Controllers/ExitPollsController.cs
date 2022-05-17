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
    public class ExitPollsController : Controller
    {
        private readonly PIPOSTEST_Context _context;

        public ExitPollsController(PIPOSTEST_Context context)
        {
            _context = context;
        }

        // GET: ExitPolls
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExitPolls.ToListAsync());
        }

        // GET: ExitPolls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exitPoll = await _context.ExitPolls
                .FirstOrDefaultAsync(m => m.EpollId == id);
            if (exitPoll == null)
            {
                return NotFound();
            }

            return View(exitPoll);
        }

        // GET: ExitPolls/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExitPolls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EpollId,EmriEp")] ExitPoll exitPoll)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exitPoll);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(exitPoll);
        }

        // GET: ExitPolls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exitPoll = await _context.ExitPolls.FindAsync(id);
            if (exitPoll == null)
            {
                return NotFound();
            }
            return View(exitPoll);
        }

        // POST: ExitPolls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EpollId,EmriEp")] ExitPoll exitPoll)
        {
            if (id != exitPoll.EpollId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exitPoll);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExitPollExists(exitPoll.EpollId))
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
            return View(exitPoll);
        }

        // GET: ExitPolls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exitPoll = await _context.ExitPolls
                .FirstOrDefaultAsync(m => m.EpollId == id);
            if (exitPoll == null)
            {
                return NotFound();
            }

            return View(exitPoll);
        }

        // POST: ExitPolls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exitPoll = await _context.ExitPolls.FindAsync(id);
            _context.ExitPolls.Remove(exitPoll);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExitPollExists(int id)
        {
            return _context.ExitPolls.Any(e => e.EpollId == id);
        }
    }
}
