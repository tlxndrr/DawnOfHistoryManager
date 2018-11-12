using DawnOfHistoryManager.Models;
using DawnOfHistoryManager.Services;
using DOHMTests.Utility;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xunit;

namespace DOHMTests.Unit.Services
{
    public class GameLoopTest
    {
        [Fact]
        public void CanResolveTaxToSupport()
        {
            int expectedCities = 4;
            int expectedPhase = (int)ActiveCiv.Phases.CalculateSpendLimit;

            //Prep the context
            DbContextOptions<GameContext> options = InMemoryContextFactory.GetContextOptions("Tax_to_support");
            GameContext context = new GameContext(options);

            //Create an active civ
            ActiveCiv activeCiv = context.ActiveCivs
                .Add(new ActiveCiv { OwnedAdvancements = new Collection<OwnedAdvancement> { } })
                .Entity;
            context.SaveChanges();
            
            //Make the game loop
            GameLoop testLoop = new GameLoop(context, activeCiv.Id);

            //Act
            testLoop.ResolveTaxToSupport(expectedCities);

            //Assert
            Assert.Equal(expectedCities, testLoop.ActiveCiv.Cities);
            Assert.Equal(expectedPhase, testLoop.ActiveCiv.CurrentPhase);

        }

        //Dataprovider for CanCalculateTotalValue test
        public static IEnumerable<object[]> SpendLimitData => new List<object[]>
        {
            new object[] { 0, new Commodity[0], 0 },  //Total  0 <= No treasury nor commodity cards
            new object[] { 5, new Commodity[0], 5 },  //Total  5 <= Five tokens in treasury, no commodity cards
            new object[]                              //Total 16 <= No treasury, a pair of 3s, and a single 4
            {
                0,
                new Commodity[]
                {
                    new Commodity(3, 2),
                    new Commodity(4, 1)
                },
                16
            },
            new object[]                              //Total 35 <= Two tokens in treasury, 4 copies of 2s, and a single 1
            {
                2,
                new Commodity[]
                {
                    new Commodity(2, 4),
                    new Commodity(1, 1)
                },
                35
            },
        };

        [Theory]
        [MemberData(nameof(SpendLimitData))]
        public void CanResolveCalculateSpendLimit(int treasury, Commodity[] commodities, int expectedSpendLimit)
        {
            int expectedPhase = (int)ActiveCiv.Phases.BuyAdvances;

            //Prep the context
            DbContextOptions<GameContext> options = InMemoryContextFactory.GetContextOptions("calculate_spend_limit");
            GameContext context = new GameContext(options);

            //Create an active civ
            ActiveCiv activeCiv = context.ActiveCivs
                .Add(new ActiveCiv { OwnedAdvancements = new Collection<OwnedAdvancement> { } })
                .Entity;
            context.SaveChanges();

            //Make the game loop
            GameLoop testLoop = new GameLoop(context, activeCiv.Id);

            //Act
            testLoop.ResolveCalculateSpendLimit(treasury, commodities);

            //Assert
            Assert.Equal(expectedSpendLimit, testLoop.ActiveCiv.SpendLimit);
            Assert.Equal(expectedPhase, testLoop.ActiveCiv.CurrentPhase);
        }

        //Dataprovider for CanResolveBuyAdvances test
        public static IEnumerable<object[]> BuyAdvancesData => new List<object[]>
        {
            new object[] { "buy_advances1", new int[] { },         new int[] { },    true },  //No new advances, no existing advances
            new object[] { "buy_advances2", new int[] { 5 },       new int[] { },    true },  //One new advance, no existing advances
            new object[] { "buy_advances3", new int[] { 2, 3 },    new int[] { },    true },  //Two new advances, no existing advances
            new object[] { "buy_advances4", new int[] { },         new int[] { 15 }, true },  //No new advances, existing advances
            new object[] { "buy_advances5", new int[] { 5 },       new int[] { 15 }, true },  //One new advance, existing advances
            new object[] { "buy_advances6", new int[] { 2, 3 },    new int[] { 15 }, true },  //Two new advances, existing advances
            new object[] { "buy_advances7", new int[] { 2, 3, 4 }, new int[] { },    false }, //Advances total cost too high
        };
        
        [Theory]
        [MemberData(nameof(BuyAdvancesData))]
        public void CanResolveBuyAdvances(string dbString, int[] newAdvances, int[] existingAdvances, bool expectedAffordability)
        {
            int expectedPhase = (int)ActiveCiv.Phases.MoveAST;

            //Build the list of expected advancements after purchase
            List<int> expectedAdvancements = new List<int>(existingAdvances);
            if(expectedAffordability)
            {
                foreach(int newAdvance in newAdvances)
                {
                    expectedAdvancements.Add(newAdvance);
                }
            }
            
            //Prep the context
            DbContextOptions<GameContext> options = InMemoryContextFactory.GetContextOptions(dbString);
            GameContext context = new GameContext(options);
            
            //Add advancements
            foreach (int advancementId in newAdvances)
            {
                context.Advancements.Add(new Advancement { Id = advancementId, BaseCost = 50 });
            }
            foreach (int advancementId in existingAdvances)
            {
                context.Advancements.Add(new Advancement { Id = advancementId, BaseCost = 50 });
            }

            //Create an active civ
            ActiveCiv activeCiv = context.ActiveCivs
                .Add(new ActiveCiv { SpendLimit = 100, OwnedAdvancements = new Collection<OwnedAdvancement> { } } )
                .Entity;
            
            //Add the existing advancements to the active civ and build the list of expected advancements after buying the new ones
            foreach(int existingAdvance in existingAdvances)
            {
                activeCiv.OwnedAdvancements.Add(new OwnedAdvancement { AdvancementId = existingAdvance });
            }
            context.SaveChanges();

            //Make the game loop
            GameLoop testLoop = new GameLoop(context, activeCiv.Id);

            //Act
            bool result = testLoop.ResolveBuyAdvances(newAdvances);

            //Assert

            //Assert that the advances were bought (or not) as expected
            Assert.Equal(expectedAffordability, result);

            //Assert correct phase
            Assert.Equal(expectedPhase, testLoop.ActiveCiv.CurrentPhase);
            //Assert expected number of owned advancements
            Assert.Equal(expectedAdvancements.Count, testLoop.ActiveCiv.OwnedAdvancements.Count);
            /* Assert that all of the expected owned advancements are present
             * (and with the previous assertion, only those advancements)
             */
            foreach(int expectedAdvancementId in expectedAdvancements)
            {
                Assert.Equal(
                    expectedAdvancementId,
                    testLoop.ActiveCiv.OwnedAdvancements.Single(a => a.AdvancementId == expectedAdvancementId).AdvancementId
                );
            }
        }

        //Dataprovider for CanResolveMoveAst test
        public static IEnumerable<object[]> AffordabilityData => new List<object[]>
        {
            new object[] { "affordability_0", 100, new int[] {  }, true },
            new object[] { "affordability_1", 100, new int[] { 5 }, true },
            new object[] { "affordability_2", 100, new int[] { 5, 10 }, true },
            new object[] { "affordability_3", 100, new int[] { 1, 2, 3 }, false },
        };
        
        [Theory]
        [MemberData(nameof(AffordabilityData))]
        public void CanCheckPlayerCanAffordAdvancements(string dbString, int spendLimit, int[] advancements, bool expectedResult)
        {
            //Prep the context
            DbContextOptions<GameContext> options = InMemoryContextFactory.GetContextOptions(dbString);
            GameContext context = new GameContext(options);

            //Add advancements
            foreach(int advancementId in advancements)
            {
                context.Advancements.Add(new Advancement { Id = advancementId, BaseCost = 50 });
            }

            //Create an active civ
            ActiveCiv activeCiv = context.ActiveCivs
                .Add(new ActiveCiv { SpendLimit = spendLimit, OwnedAdvancements = new Collection<OwnedAdvancement> { } })
                .Entity;
            context.SaveChanges();

            //Make the game loop
            GameLoop testLoop = new GameLoop(context, activeCiv.Id);

            //Act
            bool actualResult = testLoop.CheckPlayerCanAffordAdvancements(advancements);

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }

        //Dataprovider for CanResolveMoveAst test
        public static IEnumerable<object[]> MoveAstData => new List<object[]>
        {
            //TODO: add cases for full condition coverage
            new object[] { 7, 1, 0 },  //Early Bronze Age, only 1 city, should not move
            new object[] { 7, 2, 1 },  //Early Bronze Age, 2 cities, should advance
            new object[] { 7, 0, -1 },  //Early Bronze Age, no cities, should regress
        };

        [Theory]
        [MemberData(nameof(MoveAstData))]
        public void CanResolveMoveAst(int astPosition, int cities, int expectedResult)
        {
            //Prep the context
            DbContextOptions<GameContext> options = InMemoryContextFactory.GetContextOptions("move_ast");
            GameContext context = new GameContext(options);

            //Create an active civ
            ActiveCiv activeCiv = context.ActiveCivs
                .Add(new ActiveCiv {
                    Civ = new Civ { AstStone = 5, AstEarlyBronze = 8, AstLateBronze = 11, AstEarlyIron = 14, AstLateIron = 16 },
                    Cities = cities,
                    AstPosition = astPosition,
                    OwnedAdvancements = new Collection<OwnedAdvancement> { }
                })
                .Entity;
            context.SaveChanges();

            //Make the game loop
            GameLoop testLoop = new GameLoop(context, activeCiv.Id);

            //Act
            int actualResult = testLoop.ResolveMoveAst();

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }

        //Dataprovider for CanCheckForGameEnd test
        public static IEnumerable<object[]> CheckForGameEndData => new List<object[]>
        {
            new object[] { 8, false, (int)ActiveCiv.Phases.TaxToSupport },  //Position 8; game continues with TaxToSupport
            new object[] { 16, true, (int)ActiveCiv.Phases.MoveAST},        //Position 16; game ends and phase does not change
        };

        [Theory]
        [MemberData(nameof(CheckForGameEndData))]
        public void CanCheckForGameEnd(int astPosition, bool expectedResult, int expectedPhase)
        {
            //Prep the context
            DbContextOptions<GameContext> options = InMemoryContextFactory.GetContextOptions("game_end");
            GameContext context = new GameContext(options);

            //Create an active civ
            ActiveCiv activeCiv = context.ActiveCivs
                .Add(new ActiveCiv
                {
                    CurrentPhase = (int)ActiveCiv.Phases.MoveAST,
                    Civ = new Civ { AstLateIron = 16 },
                    AstPosition = astPosition,
                })
                .Entity;
            context.SaveChanges();

            //Make the game loop
            GameLoop testLoop = new GameLoop(context, activeCiv.Id);

            //Act
            bool actualResult = testLoop.CheckForGameEnd();

            //Assert
            Assert.Equal(expectedResult, actualResult);
            Assert.Equal(expectedPhase, testLoop.ActiveCiv.CurrentPhase);
        }
    }
}
