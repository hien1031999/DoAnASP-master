using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoAnASP1.Areas.Admin.Data;
using DoAnASP1.Areas.Admin.Models;

namespace DoAnASP1.Areas.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoaiSPModelsController : ControllerBase
    {
        private readonly DPcontext _context;

        public LoaiSPModelsController(DPcontext context)
        {
            _context = context;
        }

        // GET: api/LoaiSPModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoaiSPModels>>> GetLoaiSanPham()
        {
            return await _context.LoaiSanPham.ToListAsync();
        }

        // GET: api/LoaiSPModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoaiSPModels>> GetLoaiSPModels(int id)
        {
            var loaiSPModels = await _context.LoaiSanPham.FindAsync(id);

            if (loaiSPModels == null)
            {
                return NotFound();
            }

            return loaiSPModels;
        }

        // PUT: api/LoaiSPModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoaiSPModels(int id, LoaiSPModels loaiSPModels)
        {
            if (id != loaiSPModels.MaLoai)
            {
                return BadRequest();
            }

            _context.Entry(loaiSPModels).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaiSPModelsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/LoaiSPModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LoaiSPModels>> PostLoaiSPModels(LoaiSPModels loaiSPModels)
        {
            _context.LoaiSanPham.Add(loaiSPModels);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLoaiSPModels", new { id = loaiSPModels.MaLoai }, loaiSPModels);
        }

        // DELETE: api/LoaiSPModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LoaiSPModels>> DeleteLoaiSPModels(int id)
        {
            var loaiSPModels = await _context.LoaiSanPham.FindAsync(id);
            if (loaiSPModels == null)
            {
                return NotFound();
            }

            _context.LoaiSanPham.Remove(loaiSPModels);
            await _context.SaveChangesAsync();

            return loaiSPModels;
        }

        private bool LoaiSPModelsExists(int id)
        {
            return _context.LoaiSanPham.Any(e => e.MaLoai == id);
        }
    }
}
