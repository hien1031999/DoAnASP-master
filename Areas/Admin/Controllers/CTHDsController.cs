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
    public class CTHDsController : Controller
    {
        private readonly DPcontext _context;

        public CTHDsController(DPcontext context)
        {
            _context = context;
        }

        // GET: Admin/CTHDs
        public async Task<IActionResult> Index()
        {
            return View(await _context.CTHD.ToListAsync());
        }

        // GET: Admin/CTHDs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cTHD = await _context.CTHD
                .FirstOrDefaultAsync(m => m.MaCTHD == id);
            if (cTHD == null)
            {
                return NotFound();
            }

            return View(cTHD);
        }

        // GET: Admin/CTHDs/Create
        public IActionResult Create()
        {

            ViewData["MaSP"] = new SelectList(_context.SanPham, "MaSP", "MaSP");
        
            return View();
        }

        // POST: Admin/CTHDs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaCTHD,MaHD,MaSP,SoLuong,ThanhTien")] CTHD cTHD)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cTHD);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cTHD);
        }

        // GET: Admin/CTHDs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cTHD = await _context.CTHD.FindAsync(id);
            if (cTHD == null)
            {
                return NotFound();
            }
            return View(cTHD);
        }

        // POST: Admin/CTHDs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaCTHD,MaHD,MaSP,SoLuong,ThanhTien")] CTHD cTHD)
        {
            if (id != cTHD.MaCTHD)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cTHD);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CTHDExists(cTHD.MaCTHD))
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
            return View(cTHD);
        }

        // GET: Admin/CTHDs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cTHD = await _context.CTHD
                .FirstOrDefaultAsync(m => m.MaCTHD == id);
            if (cTHD == null)
            {
                return NotFound();
            }

            return View(cTHD);
        }

        // POST: Admin/CTHDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cTHD = await _context.CTHD.FindAsync(id);
            _context.CTHD.Remove(cTHD);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CTHDExists(int id)
        {
            return _context.CTHD.Any(e => e.MaCTHD == id);
        }
    }
}
