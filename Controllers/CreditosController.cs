﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cantina.Models;

namespace Cantina.Controllers
{
    public class CreditosController : Controller
    {
        private readonly CantinaContext _context;

        public CreditosController(CantinaContext context)
        {
            _context = context;
        }

        // GET: Creditos
        public async Task<IActionResult> Index()
        {
            var cantinaContext = _context.Creditos.Include(c => c.IdEmpleadoNavigation);
            return View(await cantinaContext.ToListAsync());
        }

        // GET: Creditos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credito = await _context.Creditos
                .Include(c => c.IdEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.IdCredito == id);
            if (credito == null)
            {
                return NotFound();
            }

            return View(credito);
        }

        // GET: Creditos/Create
        public IActionResult Create()
        {
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado");
            return View();
        }

        // POST: Creditos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCredito,IdEmpleado,CreditosAsignados,CreditosConsumidos")] Credito credito)
        {
            if (ModelState.IsValid)
            {
                _context.Add(credito);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", credito.IdEmpleado);
            return View(credito);
        }

        // GET: Creditos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credito = await _context.Creditos.FindAsync(id);
            if (credito == null)
            {
                return NotFound();
            }
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", credito.IdEmpleado);
            return View(credito);
        }

        // POST: Creditos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCredito,IdEmpleado,CreditosAsignados,CreditosConsumidos")] Credito credito)
        {
            if (id != credito.IdCredito)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(credito);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CreditoExists(credito.IdCredito))
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
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "IdEmpleado", credito.IdEmpleado);
            return View(credito);
        }

        // GET: Creditos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var credito = await _context.Creditos
                .Include(c => c.IdEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.IdCredito == id);
            if (credito == null)
            {
                return NotFound();
            }

            return View(credito);
        }

        // POST: Creditos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var credito = await _context.Creditos.FindAsync(id);
            if (credito != null)
            {
                _context.Creditos.Remove(credito);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CreditoExists(int id)
        {
            return _context.Creditos.Any(e => e.IdCredito == id);
        }
    }
}
