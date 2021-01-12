using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoAnASP1.Areas.Admin.Data;
using DoAnASP1.Areas.Admin.Models;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace DoAnASP1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SanPhamModelsController : Controller
    {
        private readonly DPcontext _context;

        public SanPhamModelsController(DPcontext context)
        {
            _context = context;
        }

        // GET: Admin/SanPhamModels
        public async Task<IActionResult> Index()
        {
            ViewData["Ten"] = new SelectList(_context.LoaiSanPham, "MaLoai", "Ten");
            var dPcontext = _context.SanPham.Where(m => m.TrangThai==1);
            ViewBag.DSSanPham = dPcontext;
            return View();
        }

        // GET: Admin/SanPhamModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPhamModels = await _context.SanPham
                .Include(s => s.LoaiSP)
                .FirstOrDefaultAsync(m => m.MaSP == id);
            if (sanPhamModels == null)
            {
                return NotFound();
            }

            return View(sanPhamModels);
        }

        // GET: Admin/SanPhamModels/Create
        public IActionResult Create()
        {
            //ViewData["tenloai"] = new SelectList(_context.LoaiSanPham, "id", "ten");
            ViewData["Ten"] = new SelectList(_context.LoaiSanPham, "MaLoai", "Ten");
            return View();
        }

        // POST: Admin/SanPhamModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSP,TenSP,NgaySX,Hinh,MoTa,Gia,TrangThai,MaLoai")] SanPhamModels sanPhamModels, IFormFile ful)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanPhamModels);
                await _context.SaveChangesAsync();
                var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot/img/product", sanPhamModels.MaSP + "." + ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1]);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await ful.CopyToAsync(stream);
                }
                sanPhamModels.Hinh = sanPhamModels.MaSP + "." + ful.FileName.Split(".")[ful.FileName.Split(".").Length - 1];
                _context.Update(sanPhamModels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLoai"] = new SelectList(_context.LoaiSanPham, "MaLoai", "MaLoai", sanPhamModels.MaLoai);
            return View(sanPhamModels);
        }

        // GET: Admin/SanPhamModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPhamModels = await _context.SanPham.FindAsync(id);
            if (sanPhamModels == null)
            {
                return NotFound();
            }
            ViewData["MaLoai"] = new SelectList(_context.LoaiSanPham, "MaLoai", "MaLoai", sanPhamModels.MaLoai);
            return View(sanPhamModels);
        }

        // POST: Admin/SanPhamModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaSP,TenSP,NgaySX,Hinh,MoTa,Gia,TrangThai,MaLoai")] SanPhamModels sanPhamModels)
        {
            if (id != sanPhamModels.MaSP)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanPhamModels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamModelsExists(sanPhamModels.MaSP))
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
            ViewData["MaLoai"] = new SelectList(_context.LoaiSanPham, "MaLoai", "MaLoai", sanPhamModels.MaLoai);
            return View(sanPhamModels);
        }

        // GET: Admin/SanPhamModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPhamModels = await _context.SanPham
                .Include(s => s.LoaiSP)
                .FirstOrDefaultAsync(m => m.MaSP == id);
            if (sanPhamModels == null)
            {
                return NotFound();
            }

            return View(sanPhamModels);
        }

        // POST: Admin/SanPhamModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sanPhamModels = await _context.SanPham.FindAsync(id);
            _context.SanPham.Remove(sanPhamModels);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SanPhamModelsExists(int id)
        {
            return _context.SanPham.Any(e => e.MaSP == id);
        }
    }
}
