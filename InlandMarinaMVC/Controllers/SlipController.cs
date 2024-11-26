using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InlandMarinaData;

namespace InlandMarinaMVC.Controllers
{
    public class SlipController : Controller
    {
        private readonly InlandMarinaContext _context;

        public SlipController(InlandMarinaContext context)
        {
            _context = context;
        }

        // GET: Slip
        public IActionResult Index()
        {
            List<Slip> unleasedSlips = SlipRepository.GetUnleasedSlips(_context);
            return View(unleasedSlips);
        }

        // GET: Slip/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var slip = await _context.Slips
                .Include(s => s.Dock)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (slip == null)
            {
                return NotFound();
            }

            return View(slip);
        }
    }
}
