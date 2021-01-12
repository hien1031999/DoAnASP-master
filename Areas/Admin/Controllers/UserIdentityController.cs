using DoAnASP1.Areas.Admin.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnASP1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserIdentityController : Controller
    {
        private readonly DPcontext _context;

        public UserIdentityController(DPcontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.QL = _context.Users.ToList();
            return View();
                
        }
    }
}
