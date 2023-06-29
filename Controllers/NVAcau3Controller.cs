using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaiThiNVA0025.Models;

namespace BaiThiNVA0025.Controllers
{
    public class NVAcau3Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public NVAcau3Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NVAcau3
        public async Task<IActionResult> Index()
        {
              return _context.NVAcau3 != null ? 
                          View(await _context.NVAcau3.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.NVAcau3'  is null.");
        }

        // GET: NVAcau3/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.NVAcau3 == null)
            {
                return NotFound();
            }

            var nVAcau3 = await _context.NVAcau3
                .FirstOrDefaultAsync(m => m.MaSinhVien == id);
            if (nVAcau3 == null)
            {
                return NotFound();
            }

            return View(nVAcau3);
        }

        // GET: NVAcau3/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NVAcau3/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSinhVien,TenSinhVien,PhoneSinhVien")] NVAcau3 nVAcau3)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nVAcau3);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nVAcau3);
        }

        // GET: NVAcau3/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.NVAcau3 == null)
            {
                return NotFound();
            }

            var nVAcau3 = await _context.NVAcau3.FindAsync(id);
            if (nVAcau3 == null)
            {
                return NotFound();
            }
            return View(nVAcau3);
        }

        // POST: NVAcau3/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaSinhVien,TenSinhVien,PhoneSinhVien")] NVAcau3 nVAcau3)
        {
            if (id != nVAcau3.MaSinhVien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nVAcau3);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NVAcau3Exists(nVAcau3.MaSinhVien))
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
            return View(nVAcau3);
        }

        // GET: NVAcau3/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.NVAcau3 == null)
            {
                return NotFound();
            }

            var nVAcau3 = await _context.NVAcau3
                .FirstOrDefaultAsync(m => m.MaSinhVien == id);
            if (nVAcau3 == null)
            {
                return NotFound();
            }

            return View(nVAcau3);
        }

        // POST: NVAcau3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.NVAcau3 == null)
            {
                return Problem("Entity set 'ApplicationDbContext.NVAcau3'  is null.");
            }
            var nVAcau3 = await _context.NVAcau3.FindAsync(id);
            if (nVAcau3 != null)
            {
                _context.NVAcau3.Remove(nVAcau3);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NVAcau3Exists(string id)
        {
          return (_context.NVAcau3?.Any(e => e.MaSinhVien == id)).GetValueOrDefault();
        }
    }
}
