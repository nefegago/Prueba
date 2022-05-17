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
    public class CarpetasController : Controller
    {
        private readonly pruebaContext _context;

        public CarpetasController(pruebaContext context)
        {
            _context = context;
        }

        // GET: Carpetas
        public async Task<IActionResult> Index()
        {
            return View(await _context.PCarpeta.ToListAsync());
        }

        // GET: Carpetas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pCarpetum = await _context.PCarpeta
                .FirstOrDefaultAsync(m => m.IdPCarpeta == id);
            if (pCarpetum == null)
            {
                return NotFound();
            }

            return View(pCarpetum);
        }

        // GET: Carpetas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carpetas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPCarpeta,Name,PBolsaIdPBolsa")] PCarpetum pCarpetum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pCarpetum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pCarpetum);
        }

        // GET: Carpetas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pCarpetum = await _context.PCarpeta.FindAsync(id);
            if (pCarpetum == null)
            {
                return NotFound();
            }
            return View(pCarpetum);
        }

        // POST: Carpetas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPCarpeta,Name,PBolsaIdPBolsa")] PCarpetum pCarpetum)
        {
            if (id != pCarpetum.IdPCarpeta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pCarpetum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PCarpetumExists(pCarpetum.IdPCarpeta))
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
            return View(pCarpetum);
        }

        // GET: Carpetas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pCarpetum = await _context.PCarpeta
                .FirstOrDefaultAsync(m => m.IdPCarpeta == id);
            if (pCarpetum == null)
            {
                return NotFound();
            }

            return View(pCarpetum);
        }

        // POST: Carpetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pCarpetum = await _context.PCarpeta.FindAsync(id);
            _context.PCarpeta.Remove(pCarpetum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PCarpetumExists(int id)
        {
            return _context.PCarpeta.Any(e => e.IdPCarpeta == id);
        }
    }
}
