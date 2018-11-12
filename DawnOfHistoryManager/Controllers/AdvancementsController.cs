using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DawnOfHistoryManager.Models;

namespace DawnOfHistoryManager.Controllers
{
    public class AdvancementsController : Controller
    {
        private readonly GameContext _context;

        public AdvancementsController(GameContext context)
        {
            _context = context;
        }

        // GET: Advancements
        public async Task<IActionResult> Index()
        {
            var gameContext = _context.Advancements.Include(a => a.CreditAdvancement);
            return View(await gameContext.ToListAsync());
        }

        // GET: Advancements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advancement = await _context.Advancements
                .Include(a => a.CreditAdvancement)
                .Include(a => a.Abilities)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (advancement == null)
            {
                return NotFound();
            }

            return View(advancement);
        }
    }
}
