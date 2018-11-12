using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DawnOfHistoryManager.Models;
using DawnOfHistoryManager.Models.ViewModels;
using DawnOfHistoryManager.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DawnOfHistoryManager.Controllers
{
    public class GameLoopController : Controller
    {
        public const string ASTAdvances  = "AST Advances. Now at: ";
        public const string ASTRegresses = "AST Regresses. Now at: ";
        public const string ASTStuck     = "AST did not move. Remains at: ";

        private readonly GameContext _context;

        public GameLoopController(GameContext context)
        {
            _context = context;
        }

        /* GET: GameLoop/Index/5
         * Returns the page corresponding to the ActiveCiv's current turn phase
         */
        public IActionResult Index(int? id)
        {
            //Find the active civ
            if (id == null)
            {
                return NotFound();
            }

            ActiveCiv activeCiv;
            try
            {
                activeCiv =  _context.ActiveCivs.Include(c => c.Civ).Include(c => c.OwnedAdvancements).Single(c => c.Id == id);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }

            //Ensure that the phase indicated for the civ is never outside of the phase bounds
            ActiveCiv.Phases currentPhase = (ActiveCiv.Phases)(activeCiv.CurrentPhase % 4);

            ViewBag.GameName = activeCiv.GameName;

            //Go to the appropriate phase page.
            switch (currentPhase)
            {
                case ActiveCiv.Phases.TaxToSupport:
                    return View("TaxToSupport", new TaxToSupportInput { Id = activeCiv.Id, Cities = activeCiv.Cities });
                case ActiveCiv.Phases.CalculateSpendLimit:
                    //return View("CalculateSpendLimit", activeCiv);
                case ActiveCiv.Phases.BuyAdvances:
                    //return View("BuyAdvances", activeCiv);
                case ActiveCiv.Phases.MoveAST:
                    return MoveAST(activeCiv);
                default:
                    /* In theory, this line is unreachable since the switch
                     * is based on an enum and all of its values are present
                     */
                    return NotFound();
            }
        }

        /* POST: GameLoop/ResolveTaxToSupport/5
         * Handles user input for the Tax To Support phase
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ResolveTaxToSupport(int id, [Bind("Id,Cities")] TaxToSupportInput viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                GameLoop loop = new GameLoop(_context, id);
                loop.ResolveTaxToSupport(viewModel.Cities);
                return RedirectToAction(nameof(Index), new { id = viewModel.Id });
            }
            return View(viewModel);
        }

        //TODO: build action for POST: CalculateSpendLimit
        //TODO: build action for POST: BuyAdvances

        //TODO: Consider moving this to the GameLoop service class
        //Resolves the Move AST phase. Called from Index()
        private IActionResult MoveAST(ActiveCiv activeCiv)
        {
            //Move the AST
            GameLoop loop = new GameLoop(_context, activeCiv.Id);
            int direction = loop.ResolveMoveAst();

            //If the game ended, go to the detailed active civilization view
            if(loop.CheckForGameEnd())
            {
                return RedirectToAction(
                    nameof(ActiveCivsController.Details),
                    "ActiveCivs",
                    new { id = activeCiv.Id }
                );
            }

            //If the game didn't end, present a message to the player about what happened to the AST
            switch(direction)
            {
                case -1:
                    ViewBag.MovementMessage = ASTRegresses;
                    break;
                case 1:
                    ViewBag.MovementMessage = ASTAdvances;
                    break;
                case 0:
                default:
                    ViewBag.MovementMessage = ASTStuck;
                    break;
            }

            return View("MoveAST", activeCiv);
        }
    }
}