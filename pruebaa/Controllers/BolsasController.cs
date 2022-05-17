using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using prueba.Models;

namespace prueba.Controllers
{
    public class BolsasController : Controller
    {
        private readonly pruebaContext _context;

        public BolsasController(pruebaContext context)
        {
            _context = context;
        }

        // GET: Bolsas
        public async Task<IActionResult> Index()
        {
            return View(await _context.PBolsas.ToListAsync());
        }

        // GET: Bolsas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pBolsa = await _context.PBolsas
                .FirstOrDefaultAsync(m => m.IdPBolsa == id);
            if (pBolsa == null)
            {
                return NotFound();
            }

            return View(pBolsa);
        }

        // GET: Bolsas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bolsas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPBolsa,Name,PCajaIsPCaja")] PBolsa pBolsa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pBolsa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pBolsa);
        }

        // GET: Bolsas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pBolsa = await _context.PBolsas.FindAsync(id);
            if (pBolsa == null)
            {
                return NotFound();
            }
            return View(pBolsa);
        }

        // POST: Bolsas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPBolsa,Name,PCajaIsPCaja")] PBolsa pBolsa)
        {
            if (id != pBolsa.IdPBolsa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pBolsa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PBolsaExists(pBolsa.IdPBolsa))
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
            return View(pBolsa);
        }

        // GET: Bolsas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pBolsa = await _context.PBolsas
                .FirstOrDefaultAsync(m => m.IdPBolsa == id);
            if (pBolsa == null)
            {
                return NotFound();
            }

            return View(pBolsa);
        }

        // POST: Bolsas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pBolsa = await _context.PBolsas.FindAsync(id);
            _context.PBolsas.Remove(pBolsa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PBolsaExists(int id)
        {
            return _context.PBolsas.Any(e => e.IdPBolsa == id);
        }
    }
}
