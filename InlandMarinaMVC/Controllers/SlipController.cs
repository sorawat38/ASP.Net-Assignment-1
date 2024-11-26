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
        public ActionResult Index()
        {
            GetDock();

            // Create list of Slips based on selected Dock
            List<Slip> slips = SlipRepository.GetUnleasedSlips(_context);
            return View(slips);
        }

        // POST: Slip
        [HttpPost]
        public ActionResult Index(string id = "O")
        {
            List<SelectListItem> list = GetDock();

            foreach (var item in list)
            {
                if (item.Value == id)
                {
                    item.Selected = true;
                    break;
                }
            }

            List<Slip> slips = id == "O"
                ? SlipRepository.GetUnleasedSlips(_context)
                : SlipRepository.GetSlipsByDock(_context, Convert.ToInt32(id));
            
            return View(slips);
        }

        private List<SelectListItem> GetDock()
        {
            // Fetch the list of Docks
            List<Dock> docks = DockRepository.GetDocks(_context);
            // Create a select / dropdown list of Docks
            var list = new SelectList(docks, "ID", "Name").ToList();
            // Ensure that a Dock is not selected first
            // to see all Slips
            list.Insert(0, new SelectListItem("All Unleased Slips", "O"));
            // //storing list of Dock into ViewBag
            ViewBag.Dock = list;

            return list;
        }
    }
}