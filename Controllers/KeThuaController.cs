using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaiThiNVA0025.Models;
using BaiThiNVA0025.Models.Process;

namespace BaiThiNVA0025.Controllers
{
    public class KeThuaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private StringProcess strPro = new StringProcess();

        public KeThuaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: KeThua
        public async Task<IActionResult> Index()
        {
              return _context.KeThua != null ? 
                          View(await _context.KeThua.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.KeThua'  is null.");
        }

        // GET: KeThua/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.KeThua == null)
            {
                return NotFound();
            }

            var keThua = await _context.KeThua
                .FirstOrDefaultAsync(m => m.KeThuaID == id);
            if (keThua == null)
            {
                return NotFound();
            }

            return View(keThua);
        }

        // GET: KeThua/Create
        public IActionResult Create()
        {
            var IDdautien = "MSV01";
            var countAn = _context.KeThua.Count();
            if (countAn > 0)
            {
                var KeThuaID = _context.KeThua.OrderByDescending(m => m.KeThuaID).First().KeThuaID;
                IDdautien = strPro.AutoGenerateCode(KeThuaID);
            }
            ViewBag.newID = IDdautien;
            return View();
        }

        // POST: KeThua/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KeThuaID")] KeThua keThua)
        {
            if (ModelState.IsValid)
            {
                _context.Add(keThua);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(keThua);
        }

        // GET: KeThua/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.KeThua == null)
            {
                return NotFound();
            }

            var keThua = await _context.KeThua.FindAsync(id);
            if (keThua == null)
            {
                return NotFound();
            }
            return View(keThua);
        }

        // POST: KeThua/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("KeThuaID")] KeThua keThua)
        {
            if (id != keThua.KeThuaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(keThua);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KeThuaExists(keThua.KeThuaID))
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
            return View(keThua);
        }

        // GET: KeThua/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.KeThua == null)
            {
                return NotFound();
            }

            var keThua = await _context.KeThua
                .FirstOrDefaultAsync(m => m.KeThuaID == id);
            if (keThua == null)
            {
                return NotFound();
            }

            return View(keThua);
        }

        // POST: KeThua/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.KeThua == null)
            {
                return Problem("Entity set 'ApplicationDbContext.KeThua'  is null.");
            }
            var keThua = await _context.KeThua.FindAsync(id);
            if (keThua != null)
            {
                _context.KeThua.Remove(keThua);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KeThuaExists(string id)
        {
          return (_context.KeThua?.Any(e => e.KeThuaID == id)).GetValueOrDefault();
        }
    }
}
