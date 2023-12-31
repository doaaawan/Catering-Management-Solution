﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CateringManagement.Data;
using CateringManagement.Models;
using CateringManagement.CustomControllers;
//Done by: Doaa Awan

namespace CateringManagement.Controllers
{
    public class MealTypesController : CognizantController
    {
        private readonly CateringContext _context;

        public MealTypesController(CateringContext context)
        {
            _context = context;
        }

        // GET: MealTypes
        public async Task<IActionResult> Index()
        {
              return View(await _context.MealTypes.ToListAsync());
        }

        // GET: MealTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MealTypes == null)
            {
                return NotFound();
            }

            var mealType = await _context.MealTypes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mealType == null)
            {
                return NotFound();
            }

            return View(mealType);
        }

        // GET: MealTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MealTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name")] MealType mealType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mealType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mealType);
        }

        // GET: MealTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MealTypes == null)
            {
                return NotFound();
            }

            var mealType = await _context.MealTypes.FindAsync(id);
            if (mealType == null)
            {
                return NotFound();
            }
            return View(mealType);
        }

        // POST: MealTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name")] MealType mealType)
        {
            if (id != mealType.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mealType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MealTypeExists(mealType.ID))
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
            return View(mealType);
        }

        // GET: MealTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MealTypes == null)
            {
                return NotFound();
            }

            var mealType = await _context.MealTypes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (mealType == null)
            {
                return NotFound();
            }

            return View(mealType);
        }

        // POST: MealTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MealTypes == null)
            {
                return Problem("Entity set 'CateringContext.MealTypes'  is null.");
            }
            var mealType = await _context.MealTypes.FindAsync(id);
            if (mealType != null)
            {
                _context.MealTypes.Remove(mealType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MealTypeExists(int id)
        {
          return _context.MealTypes.Any(e => e.ID == id);
        }
    }
}
