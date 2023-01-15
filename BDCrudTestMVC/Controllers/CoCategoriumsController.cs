using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BDCrudTestMVC.Models;

namespace BDCrudTestMVC.Controllers
{
    public class CoCategoriumsController : Controller
    {
        private readonly BdcrudTestMvcContext _context;

        public CoCategoriumsController(BdcrudTestMvcContext context)
        {
            _context = context;
        }

        // GET: CoCategoriums
        public async Task<IActionResult> Index()
        {
              return View(await _context.CoCategoria.ToListAsync());
        }

        // GET: CoCategoriums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CoCategoria == null)
            {
                return NotFound();
            }

            var coCategorium = await _context.CoCategoria
                .FirstOrDefaultAsync(m => m.NIdCategori == id);
            if (coCategorium == null)
            {
                return NotFound();
            }

            return View(coCategorium);
        }

        // GET: CoCategoriums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CoCategoriums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NIdCategori,CNombCateg,CEsActiva")] CoCategorium coCategorium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coCategorium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coCategorium);
        }

        // GET: CoCategoriums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CoCategoria == null)
            {
                return NotFound();
            }

            var coCategorium = await _context.CoCategoria.FindAsync(id);
            if (coCategorium == null)
            {
                return NotFound();
            }
            return View(coCategorium);
        }

        // POST: CoCategoriums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NIdCategori,CNombCateg,CEsActiva")] CoCategorium coCategorium)
        {
            if (id != coCategorium.NIdCategori)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coCategorium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoCategoriumExists(coCategorium.NIdCategori))
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
            return View(coCategorium);
        }

        // GET: CoCategoriums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CoCategoria == null)
            {
                return NotFound();
            }

            var coCategorium = await _context.CoCategoria
                .FirstOrDefaultAsync(m => m.NIdCategori == id);
            if (coCategorium == null)
            {
                return NotFound();
            }

            return View(coCategorium);
        }

        // POST: CoCategoriums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CoCategoria == null)
            {
                return Problem("Entity set 'BdcrudTestMvcContext.CoCategoria'  is null.");
            }
            var coCategorium = await _context.CoCategoria.FindAsync(id);
            if (coCategorium != null)
            {
                _context.CoCategoria.Remove(coCategorium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoCategoriumExists(int id)
        {
          return _context.CoCategoria.Any(e => e.NIdCategori == id);
        }
    }
}
