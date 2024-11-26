using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InlandMarinaData;

namespace InlandMarinaMVC.Controllers
{
    public class SlipController : Controller
    {
        private readonly InlandMarinaContext _context;

        public SlipController(InlandMarinaContext context)
        {
            _context = context;
        }

        // GET: Slip
        public async Task<IActionResult> Index()
        {
            var inlandMarinaContext = _context.Slips.Include(s => s.Dock);
            return View(await inlandMarinaContext.ToListAsync());
        }

        // GET: Slip/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slip = await _context.Slips
                .Include(s => s.Dock)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (slip == null)
            {
                return NotFound();
            }

            return View(slip);
        }

        // GET: Slip/Create
        public IActionResult Create()
        {
            ViewData["DockID"] = new SelectList(_context.Docks, "ID", "Name");
            return View();
        }

        // POST: Slip/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Width,Length,DockID")] Slip slip)
        {
            if (ModelState.IsValid)
            {
                _context.Add(slip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DockID"] = new SelectList(_context.Docks, "ID", "Name", slip.DockID);
            return View(slip);
        }

        // GET: Slip/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slip = await _context.Slips.FindAsync(id);
            if (slip == null)
            {
                return NotFound();
            }
            ViewData["DockID"] = new SelectList(_context.Docks, "ID", "Name", slip.DockID);
            return View(slip);
        }

        // POST: Slip/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Width,Length,DockID")] Slip slip)
        {
            if (id != slip.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(slip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SlipExists(slip.ID))
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
            ViewData["DockID"] = new SelectList(_context.Docks, "ID", "Name", slip.DockID);
            return View(slip);
        }

        // GET: Slip/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slip = await _context.Slips
                .Include(s => s.Dock)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (slip == null)
            {
                return NotFound();
            }

            return View(slip);
        }

        // POST: Slip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var slip = await _context.Slips.FindAsync(id);
            if (slip != null)
            {
                _context.Slips.Remove(slip);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SlipExists(int id)
        {
            return _context.Slips.Any(e => e.ID == id);
        }
    }
}
