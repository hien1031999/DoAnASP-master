using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAnASP1.Areas.Admin.Data;
using DoAnASP1.Areas.Admin.Models;

namespace DoAnASP1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NCCsController : Controller
    {
        private readonly DPcontext _context;

        public NCCsController(DPcontext context)
        {
            _context = context;
        }

        // GET: Admin/NCCs
        public async Task<IActionResult> Index()
        {
            return View(await _context.NCC.ToListAsync());
        }

        // GET: Admin/NCCs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nCC = await _context.NCC
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nCC == null)
            {
                return NotFound();
            }

            return View(nCC);
        }

        // GET: Admin/NCCs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/NCCs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,TenNCC,DiaChi,TrangThai")] NCC nCC)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nCC);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nCC);
        }

        // GET: Admin/NCCs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nCC = await _context.NCC.FindAsync(id);
            if (nCC == null)
            {
                return NotFound();
            }
            return View(nCC);
        }

        // POST: Admin/NCCs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,TenNCC,DiaChi,TrangThai")] NCC nCC)
        {
            if (id != nCC.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nCC);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NCCExists(nCC.ID))
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
            return View(nCC);
        }

        // GET: Admin/NCCs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nCC = await _context.NCC
                .FirstOrDefaultAsync(m => m.ID == id);
            if (nCC == null)
            {
                return NotFound();
            }

            return View(nCC);
        }

        // POST: Admin/NCCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nCC = await _context.NCC.FindAsync(id);
            _context.NCC.Remove(nCC);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NCCExists(int id)
        {
            return _context.NCC.Any(e => e.ID == id);
        }
    }
}
