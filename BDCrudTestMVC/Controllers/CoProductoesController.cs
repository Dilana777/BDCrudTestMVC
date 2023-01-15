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
    public class CoProductoesController : Controller
    {
        private readonly BdcrudTestMvcContext _context;

        public CoProductoesController(BdcrudTestMvcContext context)
        {
            _context = context;
        }

        // GET: CoProductoes
        public async Task<IActionResult> Index(int id)
        {
            var bdcrudTestMvcContext = _context.CoProductos.Include(c => c.NIdCategoriNavigation);
            return View(await bdcrudTestMvcContext.ToListAsync());
        }

        // GET: CoProductoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CoProductos == null)
            {
                return NotFound();
            }

            var coProducto = await _context.CoProductos
                .Include(c => c.NIdCategoriNavigation)
                .FirstOrDefaultAsync(m => m.NIdProduct == id);
            if (coProducto == null)
            {
                return NotFound();
            }

            return View(coProducto);
        }

        // GET: CoProductoes/Create
        public IActionResult Create()
        {
            ViewData["NIdCategori"] = new SelectList(_context.CoCategoria, "NIdCategori", "NIdCategori");
            return View();
        }

        // POST: CoProductoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NIdProduct,CNombProdu,NPrecioProd,NIdCategori")] CoProducto coProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NIdCategori"] = new SelectList(_context.CoCategoria, "NIdCategori", "NIdCategori", coProducto.NIdCategori);
            return View(coProducto);
        }

        // GET: CoProductoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CoProductos == null)
            {
                return NotFound();
            }

            var coProducto = await _context.CoProductos.FindAsync(id);
            if (coProducto == null)
            {
                return NotFound();
            }
            ViewData["NIdCategori"] = new SelectList(_context.CoCategoria, "NIdCategori", "NIdCategori", coProducto.NIdCategori);
            return View(coProducto);
        }

        // POST: CoProductoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NIdProduct,CNombProdu,NPrecioProd,NIdCategori")] CoProducto coProducto)
        {
            if (id != coProducto.NIdProduct)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoProductoExists(coProducto.NIdProduct))
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
            ViewData["NIdCategori"] = new SelectList(_context.CoCategoria, "NIdCategori", "NIdCategori", coProducto.NIdCategori);
            return View(coProducto);
        }

        // GET: CoProductoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CoProductos == null)
            {
                return NotFound();
            }

            var coProducto = await _context.CoProductos
                .Include(c => c.NIdCategoriNavigation)
                .FirstOrDefaultAsync(m => m.NIdProduct == id);
            if (coProducto == null)
            {
                return NotFound();
            }

            return View(coProducto);
        }

        // POST: CoProductoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CoProductos == null)
            {
                return Problem("Entity set 'BdcrudTestMvcContext.CoProductos'  is null.");
            }
            var coProducto = await _context.CoProductos.FindAsync(id);
            if (coProducto != null)
            {
                _context.CoProductos.Remove(coProducto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoProductoExists(int id)
        {
          return _context.CoProductos.Any(e => e.NIdProduct == id);
        }

        public async Task<IActionResult> Usp_Sel_Co_Productos(int  id) 
        
                {
            var producto = from CoProducto in _context.CoProductos select CoProducto;
            producto = producto.Where(s => s.NIdCategori == id);
            return View(await producto.ToListAsync());


        }




    }
}
