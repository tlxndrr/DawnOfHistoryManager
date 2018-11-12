using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DawnOfHistoryManager.Models;
using System.Collections.ObjectModel;

namespace DawnOfHistoryManager.Controllers
{
    public class ActiveCivsController : Controller
    {
        private readonly GameContext _context;

        public ActiveCivsController(GameContext context)
        {
            _context = context;
        }

        // GET: ActiveCivs
        public async Task<IActionResult> Index()
        {
            var gameContext = _context.ActiveCivs.Include(a => a.Civ);
            return View(await gameContext.ToListAsync());
        }

        // GET: ActiveCivs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activeCiv = await _context.ActiveCivs
                .Include(a => a.Civ)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activeCiv == null)
            {
                return NotFound();
            }

            return View(activeCiv);
        }

        // GET: ActiveCivs/Create
        public IActionResult Create()
        {
            ViewData["CivId"] = new SelectList(_context.Civs, "Id", "Name");
            return View();
        }

        // POST: ActiveCivs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CivId,GameName")] ActiveCiv activeCiv)
        {
            activeCiv.OwnedAdvancements = new Collection<OwnedAdvancement> { };
            if (ModelState.IsValid)
            {
                ActiveCiv newCiv = _context.Add(activeCiv).Entity;
                await _context.SaveChangesAsync();
                //Go to the game loop
                return RedirectToAction(nameof(GameLoopController.Index), "GameLoop", new { id = newCiv.Id });
            }
            ViewData["CivId"] = new SelectList(_context.Civs, "Id", "Id", activeCiv.CivId);
            return View(activeCiv);
        }

        // GET: ActiveCivs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activeCiv = await _context.ActiveCivs
                .Include(a => a.Civ)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activeCiv == null)
            {
                return NotFound();
            }

            return View(activeCiv);
        }

        // POST: ActiveCivs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activeCiv = await _context.ActiveCivs.FindAsync(id);
            _context.ActiveCivs.Remove(activeCiv);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActiveCivExists(int id)
        {
            return _context.ActiveCivs.Any(e => e.Id == id);
        }
    }
}
