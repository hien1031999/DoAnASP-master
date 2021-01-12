using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DoAnASP.NET1.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using DoAnASP1.Areas.Admin.Data;
using DoAnASP1.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace DoAnASP.NET1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DPcontext _context;

        public HomeController(DPcontext context)
        {
            _context = context;
        }

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public async Task<IActionResult> Index()
        {

            var dPcontext = _context.SanPham.Include(s => s.LoaiSP);
            return View(await dPcontext.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Product()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
