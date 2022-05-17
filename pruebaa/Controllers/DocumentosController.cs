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
    public class DocumentosController : Controller
    {
        private readonly pruebaContext _context;

        public DocumentosController(pruebaContext context)
        {
            _context = context;
        }

        // GET: Documentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.PDocumentos.ToListAsync());
        }

        // GET: Documentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pDocumento = await _context.PDocumentos
                .FirstOrDefaultAsync(m => m.IdPDocumento == id);
            if (pDocumento == null)
            {
                return NotFound();
            }

            return View(pDocumento);
        }

        // GET: Documentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Documentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPDocumento,Name,PCarpetaIdPCarpeta")] PDocumento pDocumento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pDocumento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pDocumento);
        }

        // GET: Documentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pDocumento = await _context.PDocumentos.FindAsync(id);
            if (pDocumento == null)
            {
                return NotFound();
            }
            return View(pDocumento);
        }

        // POST: Documentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPDocumento,Name,PCarpetaIdPCarpeta")] PDocumento pDocumento)
        {
            if (id != pDocumento.IdPDocumento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pDocumento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PDocumentoExists(pDocumento.IdPDocumento))
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
            return View(pDocumento);
        }

        // GET: Documentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pDocumento = await _context.PDocumentos
                .FirstOrDefaultAsync(m => m.IdPDocumento == id);
            if (pDocumento == null)
            {
                return NotFound();
            }

            return View(pDocumento);
        }

        // POST: Documentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pDocumento = await _context.PDocumentos.FindAsync(id);
            _context.PDocumentos.Remove(pDocumento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PDocumentoExists(int id)
        {
            return _context.PDocumentos.Any(e => e.IdPDocumento == id);
        }
    }
}
