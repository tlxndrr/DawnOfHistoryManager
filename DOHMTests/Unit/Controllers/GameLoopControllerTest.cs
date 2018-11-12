using DawnOfHistoryManager.Controllers;
using DawnOfHistoryManager.Migrations;
using DawnOfHistoryManager.Models;
using DawnOfHistoryManager.Models.ViewModels;
using DOHMTests.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DOHMTests.Unit.Controllers
{
    public class GameLoopControllerTest
    {
        private GameContext GetTestContext(string testDb)
        {
            //Prep a context and controller
            GameContext gameContext = new GameContext(InMemoryContextFactory.GetContextOptions(testDb));

            //Add the civilization seed data
            gameContext.Civs.Add(new Civ {
                Id = 1,
                Name = "test",
                AstStone = 4,
                AstEarlyBronze = 7,
                AstLateBronze = 10,
                AstEarlyIron = 13,
                AstLateIron = 16
            });

            //Add a sample activeCiv
            gameContext.ActiveCivs.Add(new ActiveCiv {
                Id = 1,
                CivId = 1,
                GameName = "controller unit test",
                CurrentPhase = (int)ActiveCiv.Phases.TaxToSupport
            });

            gameContext.SaveChanges();

            return gameContext;
        }

        [Fact]
        public void CanDisplayIndexAtTaxToSupport()
        {
            //Get a test controller
            GameContext gameContext = GetTestContext("gameloop_display_taxtosupport");
            GameLoopController testController = new GameLoopController(gameContext);

            //Run the controller's Index()
            IActionResult result = testController.Index(1);

            //Assert that...
            //...we got a view back
            ViewResult viewResult = Assert.IsType<ViewResult>(result);
            //...the view data is a set of advancements
            Assert.IsAssignableFrom<TaxToSupportInput>(viewResult.ViewData.Model);
        }

        [Fact]
        public void TestIndexWithoutIdReturnsNotFound()
        {
            //Get a test controller
            GameContext context = GetTestContext("gameloop_details_no_id");
            GameLoopController testController = new GameLoopController(context);

            //Run the controller's Details() without an Id
            IActionResult result = testController.Index(null);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void TestIndexWithOutOfRangeIdReturnsNotFound()
        {
            //Get a test controller
            GameContext context = GetTestContext("gameloop_details_oob_id");
            GameLoopController testController = new GameLoopController(context);

            //Run the controller's Details() with an Id that isn't present in the database
            IActionResult result = testController.Index(context.ActiveCivs.Count() + 20);

            Assert.IsType<NotFoundResult>(result);
        }

        //TODO: test Post: ResolveTaxToSupport
        [Fact]
        public void CanResolveTaxToSupport()
        {
            //Get a test controller
            GameContext context = GetTestContext("gameloop_tax_to_support");
            GameLoopController testController = new GameLoopController(context);

            //Generate the form data
            TaxToSupportInput input = new TaxToSupportInput { Id = 1, Cities = 5 };

            //Run the controller's Details() without an Id
            IActionResult result = testController.ResolveTaxToSupport(1, input);

            //Assert that...
            //...we got a redirect back
            RedirectToActionResult redirect = Assert.IsType<RedirectToActionResult>(result);
            //...the action is the index
            Assert.Equal(nameof(GameLoopController.Index), redirect.ActionName);
            //...the route data is the ID of the active civ
            Assert.Equal(input.Id, redirect.RouteValues["id"]);
        }

        [Fact]
        public void TestTaxToSupportReturnsNotFoundWithIdMismatch()
        {
            //Get a test controller
            GameContext context = GetTestContext("gameloop_tax_to_support_mismatch");
            GameLoopController testController = new GameLoopController(context);

            //Generate the form data
            TaxToSupportInput input = new TaxToSupportInput { Id = 4, Cities = 5 };

            //Run the controller's ResolveTaxToSupport() with a mismatched Id
            IActionResult result = testController.ResolveTaxToSupport(1, input);

            //Assert that we got a not found result
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void TestTaxToSupportReturnsToFormOnInvalidModel()
        {
            //Get a test controller
            GameContext context = GetTestContext("gameloop_tax_to_support_invalid");
            GameLoopController testController = new GameLoopController(context);
            
            //Add an error to force the Post: Create() method to return to the form
            testController.ModelState.AddModelError("test error", "automated unit test error");

            //Generate the form data
            TaxToSupportInput input = new TaxToSupportInput { Id = 1, Cities = 5 };

            //Run the controller's ResolveTaxToSupport() with an invalid model
            IActionResult result = testController.ResolveTaxToSupport(1, input);

            //Assert that...
            //...we got a view back
            ViewResult viewResult = Assert.IsType<ViewResult>(result);
        }

        //Dataprovider for CanResolveMoveAst test
        public static IEnumerable<object[]> MoveASTData => new List<object[]>
        {
            new object[] { "ast_f",  0, 0, GameLoopController.ASTAdvances }, //Start of AST, no cities; expecting advancement message
            new object[] { "ast_b", 10, 0, GameLoopController.ASTRegresses }, //Start of AST, no cities; expecting regression message
            new object[] { "ast_s", 10, 1, GameLoopController.ASTStuck }, //Start of AST, no cities; expecting stuck message
        };

        [Theory]
        [MemberData(nameof(MoveASTData))]
        public void CanResolveMoveAstForward(string dbString, int astPosition, int cities, string expectedMessage)
        {
            //Get a test controller
            GameContext context = GetTestContext(dbString);
            GameLoopController testController = new GameLoopController(context);

            //Configure the active civ's status
            ActiveCiv activeCiv    = context.ActiveCivs.Find(1);
            activeCiv.AstPosition  = astPosition;
            activeCiv.Cities       = cities;
            activeCiv.CurrentPhase = (int)ActiveCiv.Phases.MoveAST;
            context.SaveChanges();

            //Run the resolution (via the index, since MoveAST is private
            IActionResult result = testController.Index(1);

            //Assert that...
            //...we got a view back
            ViewResult viewResult = Assert.IsType<ViewResult>(result);
            //...the view model is an ActiveCiv
            Assert.IsAssignableFrom<ActiveCiv>(viewResult.ViewData.Model);
            //...the view bag has the message we expect
            Assert.Equal(expectedMessage, viewResult.ViewData["MovementMessage"]);
        }
        
        [Fact]
        public void CanResolveMoveAstEnd()
        {
            //Get a test controller
            GameContext context = GetTestContext("gameloop_end");
            GameLoopController testController = new GameLoopController(context);

            //Configure the active civ's status
            ActiveCiv activeCiv = context.ActiveCivs.Find(1);
            activeCiv.AstPosition = 16;
            activeCiv.Cities = 5;
            activeCiv.CurrentPhase = (int)ActiveCiv.Phases.MoveAST;
            context.SaveChanges();

            //Run the controller's Details() without an Id
            IActionResult result = testController.Index(1);

            //Assert that...
            //...we got a redirect back
            RedirectToActionResult redirect = Assert.IsType<RedirectToActionResult>(result);
            //...the controller is "ActiveCivController"
            Assert.Equal("ActiveCivs", redirect.ControllerName);
            //...the action is the index
            Assert.Equal(nameof(ActiveCivsController.Details), redirect.ActionName);
            //...the route data is the ID of the new active civ
            Assert.Equal(activeCiv.Id, redirect.RouteValues["id"]);
        }
    }
}
