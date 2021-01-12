using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DoAnASP1.Areas.Admin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DoAnASP1.Areas.Admin.Data
{
    public class DPcontext : IdentityDbContext<IdentityUser>
    {
        public DPcontext(DbContextOptions<DPcontext> options)
            : base(options)
        {
        }

        public DbSet<SanPhamModels> SanPham { get; set; }
        public DbSet<LoaiSPModels> LoaiSanPham { get; set; }
        public DbSet<NCC> NCC { get; set; }
        public DbSet<DoAnASP1.Areas.Admin.Models.User> User { get; set; }
        public DbSet<DoAnASP1.Areas.Admin.Models.HoaDon> HoaDon { get; set; }
        public DbSet<DoAnASP1.Areas.Admin.Models.Comment> Comment { get; set; }
        public DbSet<DoAnASP1.Areas.Admin.Models.CTHD> CTHD { get; set; }

    }
}
