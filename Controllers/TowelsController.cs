using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TOWELS.Data;
using TOWELS.Models;

namespace TOWELS.Controllers
{
    /// <summary>
    /// Controller created with Scaffold
    /// </summary>
    public class TowelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TowelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Index page with the list of registered products
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await _context.Towels.ToListAsync());
        }

        // GET: Towels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var towel = await _context.Towels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (towel == null)
            {
                return NotFound();
            }

            return View(towel);
        }

        // GET: Towels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Towels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Color,size,tissue,review")] Towel towel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(towel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(towel);
        }

        // GET: Towels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var towel = await _context.Towels.FindAsync(id);
            if (towel == null)
            {
                return NotFound();
            }
            return View(towel);
        }

        // POST: Towels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Color,size,tissue,review")] Towel towel)
        {
            if (id != towel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(towel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TowelExists(towel.Id))
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
            return View(towel);
        }

        // GET: Towels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var towel = await _context.Towels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (towel == null)
            {
                return NotFound();
            }

            return View(towel);
        }

        // POST: Towels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var towel = await _context.Towels.FindAsync(id);
            _context.Towels.Remove(towel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TowelExists(int id)
        {
            return _context.Towels.Any(e => e.Id == id);
        }
    }
}
