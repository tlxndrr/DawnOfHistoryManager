using DawnOfHistoryManager.Controllers;
using DawnOfHistoryManager.Migrations;
using DawnOfHistoryManager.Models;
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
    public class ActiveCivsControllerTest
    {
        private GameContext GetTestContext(string testDb)
        {
            //Prep a context and controller
            GameContext gameContext = new GameContext(InMemoryContextFactory.GetContextOptions(testDb));

            //Add the civilization seed data
            foreach (Civ civ in Iteration1Seeder.GetSeedCivilizations())
            {
                gameContext.Civs.Add(civ);
            }

            //Add a sample activeCiv
            gameContext.ActiveCivs.Add(new ActiveCiv { Id = 1, CivId = 4, GameName = "controller unit test" });

            gameContext.SaveChanges();

            return gameContext;
        }

        [Fact]
        public async Task CanGetIndex()
        {
            //Get a test controller
            GameContext gameContext = GetTestContext("activeciv_index");
            ActiveCivsController testController = new ActiveCivsController(gameContext);

            //Run the controller's Index()
            IActionResult result = await testController.Index();

            //Assert that...
            //...we got a view back
            ViewResult viewResult = Assert.IsType<ViewResult>(result);
            //...the view data is a set of ActiveCivs
            IEnumerable<ActiveCiv> model = Assert.IsAssignableFrom<IEnumerable<ActiveCiv>>(viewResult.ViewData.Model);
            //...the whole ActiveCiv set is present
            Assert.Equal(gameContext.ActiveCivs.Count(), model.Count());
        }

        [Fact]
        public async Task CanGetDetails()
        {
            int testActiveCivId = 1;

            //Get a test controller
            GameContext gameContext = GetTestContext("activeciv_details");
            ActiveCivsController testController = new ActiveCivsController(gameContext);

            //Run the controller's Details()
            IActionResult result = await testController.Details(testActiveCivId);

            //Assert that...
            //...we got a view back
            ViewResult viewResult = Assert.IsType<ViewResult>(result);
            //...the view model is an ActiveCiv
            Assert.IsAssignableFrom<ActiveCiv>(viewResult.ViewData.Model);
        }

        [Fact]
        public async Task TestDetailsWithoutIdReturnsNotFound()
        {
            //Get a test controller
            GameContext context = GetTestContext("activeciv_details_no_id");
            ActiveCivsController testController = new ActiveCivsController(context);

            //Run the controller's Details() without an Id
            IActionResult result = await testController.Details(null);

            //Assert that we got a not found result
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task TestDetailsWithOutOfRangeIdReturnsNotFound()
        {
            //Get a test controller
            GameContext context = GetTestContext("activeciv_details_oob_id");
            ActiveCivsController testController = new ActiveCivsController(context);

            //Run the controller's Details() with an Id that isn't present in the database
            IActionResult result = await testController.Details(context.ActiveCivs.Count() + 20);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void TestCreateFormHasCivs()
        {
            //Get a test controller
            GameContext gameContext = GetTestContext("activeciv_create_form");
            ActiveCivsController testController = new ActiveCivsController(gameContext);

            //Grab the output of Get: Create()
            IActionResult result = testController.Create();

            //Assert that...
            //...we got a view back
            ViewResult viewResult = Assert.IsType<ViewResult>(result);
            //...the view data has civ ids
            Assert.NotNull(viewResult.ViewData["CivId"]);

        }
        
        [Fact]
        public async Task CreateGoesToGameLoopForActiveCiv()
        {
            //Get a test controller
            GameContext gameContext = GetTestContext("activeciv_create_successful");
            ActiveCivsController testController = new ActiveCivsController(gameContext);

            //Build a new ActiveCiv
            ActiveCiv activeCiv = new ActiveCiv { Id = 10, CivId = 1, GameName = "Create Game Test" };

            //Run the controller's Post: Create()
            IActionResult result = await testController.Create(activeCiv);

            //Assert that...
            //...we got a redirect back
            RedirectToActionResult redirect = Assert.IsType<RedirectToActionResult>(result);
            //...the controller is "GameLoop"
            Assert.Equal("GameLoop", redirect.ControllerName);
            //...the action is the index
            Assert.Equal(nameof(GameLoopController.Index), redirect.ActionName);
            //...the route data is the ID of the new active civ
            Assert.Equal(activeCiv.Id, redirect.RouteValues["id"]);
        }
        
        [Fact]
        public async Task CreateReturnsToFormOnInvalidModel()
        {
            //Get a test controller
            GameContext gameContext = GetTestContext("activeciv_create_invalid");
            ActiveCivsController testController = new ActiveCivsController(gameContext);

            //Add an error to force the Post: Create() method to return to the form
            testController.ModelState.AddModelError("test error", "automated unit test error");

            //Build a new ActiveCiv
            ActiveCiv activeCiv = new ActiveCiv { Id = 10, CivId = 1, GameName = "Create Game Test" };

            //Run the controller's Post: Create()
            IActionResult result = await testController.Create(activeCiv);

            //Assert that...
            //...we got a view back
            ViewResult viewResult = Assert.IsType<ViewResult>(result);
            //...the view data has civ ids
            Assert.NotNull(viewResult.ViewData["CivId"]);
        }

        [Fact]
        public async Task CanGetDelete()
        {
            int testActiveCivId = 1;

            //Get a test controller
            GameContext gameContext = GetTestContext("activeciv_delete_get");
            ActiveCivsController testController = new ActiveCivsController(gameContext);

            //Run the controller's Details()
            IActionResult result = await testController.Delete(testActiveCivId);

            //Assert that...
            //...we got a view back
            ViewResult viewResult = Assert.IsType<ViewResult>(result);
            //...the view model is an ActiveCiv
            Assert.IsAssignableFrom<ActiveCiv>(viewResult.ViewData.Model);
        }

        [Fact]
        public async Task TestDeleteWithoutIdReturnsNotFound()
        {
            //Get a test controller
            GameContext context = GetTestContext("activeciv_delete_get_no_id");
            ActiveCivsController testController = new ActiveCivsController(context);

            //Run the controller's Details() without an Id
            IActionResult result = await testController.Delete(null);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task TestDeleteWithOutOfRangeIdReturnsNotFound()
        {
            //Get a test controller
            GameContext context = GetTestContext("activeciv_delete_get_oob_id");
            ActiveCivsController testController = new ActiveCivsController(context);

            //Run the controller's Details() with an Id that isn't present in the database
            IActionResult result = await testController.Delete(context.ActiveCivs.Count() + 20);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task CanConfirmDelete()
        {
            //Get a test controller
            GameContext gameContext = GetTestContext("activeciv_delete_confirm");
            ActiveCivsController testController = new ActiveCivsController(gameContext);

            //Run the controller's Index()
            IActionResult result = await testController.DeleteConfirmed(1);

            //Assert that...
            //...we got a redirect back
            RedirectToActionResult redirect = Assert.IsType<RedirectToActionResult>(result);
            //...the action is the index
            Assert.Equal(nameof(GameLoopController.Index), redirect.ActionName);
        }
    }
}
