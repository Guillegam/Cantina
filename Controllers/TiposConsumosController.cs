using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cantina.Models;

namespace Cantina.Controllers
{
    public class TiposConsumosController : Controller
    {
        private readonly CantinaContext _context;

        public TiposConsumosController(CantinaContext context)
        {
            _context = context;
        }

        // GET: TiposConsumos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposConsumos.ToListAsync());
        }

        // GET: TiposConsumos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposConsumo = await _context.TiposConsumos
                .FirstOrDefaultAsync(m => m.IdConsumo == id);
            if (tiposConsumo == null)
            {
                return NotFound();
            }

            return View(tiposConsumo);
        }

        // GET: TiposConsumos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposConsumos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConsumo,NombreConsumo,HorarioInicio,HorarioFin,CreditosRequeridos")] TiposConsumo tiposConsumo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposConsumo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposConsumo);
        }

        // GET: TiposConsumos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposConsumo = await _context.TiposConsumos.FindAsync(id);
            if (tiposConsumo == null)
            {
                return NotFound();
            }
            return View(tiposConsumo);
        }

        // POST: TiposConsumos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdConsumo,NombreConsumo,HorarioInicio,HorarioFin,CreditosRequeridos")] TiposConsumo tiposConsumo)
        {
            if (id != tiposConsumo.IdConsumo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposConsumo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposConsumoExists(tiposConsumo.IdConsumo))
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
            return View(tiposConsumo);
        }

        // GET: TiposConsumos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposConsumo = await _context.TiposConsumos
                .FirstOrDefaultAsync(m => m.IdConsumo == id);
            if (tiposConsumo == null)
            {
                return NotFound();
            }

            return View(tiposConsumo);
        }

        // POST: TiposConsumos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tiposConsumo = await _context.TiposConsumos.FindAsync(id);
            if (tiposConsumo != null)
            {
                _context.TiposConsumos.Remove(tiposConsumo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposConsumoExists(int id)
        {
            return _context.TiposConsumos.Any(e => e.IdConsumo == id);
        }
    }
}
