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
    public class AdvancementControllerTest
    {
        private GameContext GetTestContext(string testDb)
        {
            //Prep a context and controller
            GameContext gameContext = new GameContext(InMemoryContextFactory.GetContextOptions(testDb));
            foreach (Advancement advancement in Iteration1Seeder.GetSeedAdvancements())
            {
                gameContext.Advancements.Add(advancement);
            }
            gameContext.SaveChanges();

            return gameContext;
        }

        [Fact]
        public async Task CanGetIndex()
        {
            //Get a test controller
            GameContext gameContext = GetTestContext("advance_index");
            AdvancementsController testController = new AdvancementsController(gameContext);

            //Run the controller's Index()
            IActionResult result = await testController.Index();

            //Assert that...
            //...we got a view back
            ViewResult viewResult = Assert.IsType<ViewResult>(result);
            //...the view data is a set of advancements
            IEnumerable<Advancement> model = Assert.IsAssignableFrom<IEnumerable<Advancement>>(viewResult.ViewData.Model);
            //...the whole advancement set is present
            Assert.Equal(gameContext.Advancements.Count(), model.Count());
        }

        [Fact]
        public async Task CanGetDetails()
        {
            int testAdvancementId = 2;

            //Get a test controller
            GameContext gameContext = GetTestContext("test_details");
            
            foreach (Ability ability in Iteration1Seeder.GetSeedAbilities())
            {
                gameContext.Abilities.Add(ability);
            }
            gameContext.SaveChanges();

            AdvancementsController testController = new AdvancementsController(gameContext);

            //Run the controller's Details()
            IActionResult result = await testController.Details(testAdvancementId);

            //Assert that...
            //...we got a view back
            ViewResult viewResult = Assert.IsType<ViewResult>(result);
            //...the view is an advancement
            Advancement model = Assert.IsAssignableFrom<Advancement>(viewResult.ViewData.Model);
            //...the abilities for the advancement are present
            Assert.Equal(gameContext.Abilities.Where(a => a.AdvancementId == testAdvancementId).Count(), model.Abilities.Count());
        }

        [Fact]
        public async Task TestDetailsWithoutIdReturnsNotFound()
        {
            //Get a test controller
            GameContext context = GetTestContext("advancement_details_no_id");
            AdvancementsController testController = new AdvancementsController(context);

            //Run the controller's Details() without an Id
            IActionResult result = await testController.Details(null);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task TestDetailsWithOutOfRangeIdReturnsNotFound()
        {
            //Get a test controller
            GameContext context = GetTestContext("advancement_details_oob_id");
            AdvancementsController testController = new AdvancementsController(context);

            //Run the controller's Details() with an Id that isn't present in the database
            IActionResult result = await testController.Details(context.Advancements.Count() + 20);

            Assert.IsType<NotFoundResult>(result);
        }
    }
}
