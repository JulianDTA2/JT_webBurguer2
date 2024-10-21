using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JT_webBurguer2.Data;
using JT_webBurguer2.Models;

namespace JT_webBurguer2.Controllers
{
    public class PromosController : Controller
    {
        private readonly JT_webBurguer2Context _context;

        public PromosController(JT_webBurguer2Context context)
        {
            _context = context;
        }

        // GET: Promos
        public async Task<IActionResult> Index()
        {
            var jT_webBurguer2Context = _context.Promos.Include(p => p.Burguer);
            return View(await jT_webBurguer2Context.ToListAsync());
        }

        // GET: Promos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promos = await _context.Promos
                .Include(p => p.Burguer)
                .FirstOrDefaultAsync(m => m.PromosId == id);
            if (promos == null)
            {
                return NotFound();
            }

            return View(promos);
        }

        // GET: Promos/Create
        public IActionResult Create()
        {
            ViewData["BurguerId"] = new SelectList(_context.Burguer, "BurguerId", "BurguerName");
            return View();
        }

        // POST: Promos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PromosId,Description,FechaPromo,BurguerId")] Promos promos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(promos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BurguerId"] = new SelectList(_context.Burguer, "BurguerId", "BurguerName", promos.BurguerId);
            return View(promos);
        }

        // GET: Promos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promos = await _context.Promos.FindAsync(id);
            if (promos == null)
            {
                return NotFound();
            }
            ViewData["BurguerId"] = new SelectList(_context.Burguer, "BurguerId", "BurguerName", promos.BurguerId);
            return View(promos);
        }

        // POST: Promos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PromosId,Description,FechaPromo,BurguerId")] Promos promos)
        {
            if (id != promos.PromosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromosExists(promos.PromosId))
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
            ViewData["BurguerId"] = new SelectList(_context.Burguer, "BurguerId", "BurguerName", promos.BurguerId);
            return View(promos);
        }

        // GET: Promos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promos = await _context.Promos
                .Include(p => p.Burguer)
                .FirstOrDefaultAsync(m => m.PromosId == id);
            if (promos == null)
            {
                return NotFound();
            }

            return View(promos);
        }

        // POST: Promos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promos = await _context.Promos.FindAsync(id);
            if (promos != null)
            {
                _context.Promos.Remove(promos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromosExists(int id)
        {
            return _context.Promos.Any(e => e.PromosId == id);
        }
    }
}
