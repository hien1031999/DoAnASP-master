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
    public class LoaiSPModelsController : Controller
    {
        private readonly DPcontext _context;

        public LoaiSPModelsController(DPcontext context)
        {
            _context = context;
        }

        // GET: Admin/LoaiSPModels
        public async Task<IActionResult> Index()
        {
            var DsLoaiSanPham = from m in _context.LoaiSanPham
                                select m;
            ViewBag.DsLoaiSP = DsLoaiSanPham;
            ViewData["NhaCungCap"] = new SelectList(_context.Set<NCC>(), "ID", "ID");
            return View();
            //ViewData["MaNCC"] = new SelectList(_context.NCC, "ID", "TenNCC");
            //var dPcontext = _context.LoaiSanPham.Include(l => l.NCC);
            //return View(await dPcontext.ToListAsync());
        }

        // GET: Admin/LoaiSPModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiSPModels = await _context.LoaiSanPham
                .Include(l => l.NCC)
                .FirstOrDefaultAsync(m => m.MaLoai == id);
            if (loaiSPModels == null)
            {
                return NotFound();
            }

            return View(loaiSPModels);
        }

        // GET: Admin/LoaiSPModels/Create
        public IActionResult Create()
        {
            ViewData["MaNCC"] = new SelectList(_context.NCC, "ID", "TenNCC");
            return View();
        }

        // POST: Admin/LoaiSPModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaLoai,Ten,TT,MaNCC")] LoaiSPModels loaiSPModels)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loaiSPModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaNCC"] = new SelectList(_context.NCC, "ID", "ID", loaiSPModels.MaNCC);
            return View(loaiSPModels);
        }

        // GET: Admin/LoaiSPModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiSPModels = await _context.LoaiSanPham.FindAsync(id);
            if (loaiSPModels == null)
            {
                return NotFound();
            }
            ViewData["MaNCC"] = new SelectList(_context.NCC, "ID", "ID", loaiSPModels.MaNCC);
            return View(loaiSPModels);
        }

        // POST: Admin/LoaiSPModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaLoai,Ten,TT,MaNCC")] LoaiSPModels loaiSPModels)
        {
            if (id != loaiSPModels.MaLoai)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loaiSPModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoaiSPModelsExists(loaiSPModels.MaLoai))
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
            ViewData["MaNCC"] = new SelectList(_context.NCC, "ID", "ID", loaiSPModels.MaNCC);
            return View(loaiSPModels);
        }

        // GET: Admin/LoaiSPModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loaiSPModels = await _context.LoaiSanPham
                .Include(l => l.NCC)
                .FirstOrDefaultAsync(m => m.MaLoai == id);
            if (loaiSPModels == null)
            {
                return NotFound();
            }

            return View(loaiSPModels);
        }

        // POST: Admin/LoaiSPModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loaiSPModels = await _context.LoaiSanPham.FindAsync(id);
            _context.LoaiSanPham.Remove(loaiSPModels);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoaiSPModelsExists(int id)
        {
            return _context.LoaiSanPham.Any(e => e.MaLoai == id);
        }
    }
}
