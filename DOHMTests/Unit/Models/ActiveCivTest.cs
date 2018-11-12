using DawnOfHistoryManager.Migrations;
using DawnOfHistoryManager.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xunit;

namespace DOHMTests.Unit.Models
{
    /* 
     * Contatins tests for calcuated data in the ActiveCiv class
     */
    public class ActiveCivTest
    {
        //Dataprovider for CanGetScore test
        public static IEnumerable<object[]> ScoreData => new List<object[]>
        {
            new object[] { 0, 0, new int[] { }, 0 },      //Start of AST, no cities, no advances
            new object[] { 2, 0, new int[] { }, 10 },     //Second space of AST, no cities, no advances
            new object[] { 0, 4, new int[] { }, 4 },      //Start of AST, 4 cities, no advances
            new object[] { 0, 0, new int[] { 1 }, 1 },    //Start of AST, no cities, one advance worth 1 point
            new object[] { 0, 0, new int[] { 1, 3 }, 4 }, //Start of AST, no cities, two advances worth 1 and 3 points respectively
        };

        [Theory]
        [MemberData(nameof(ScoreData))]
        public void CanGetScore(int astPosition, int cities, int[] advancementValues, int expectedScore)
        {
            ICollection<OwnedAdvancement> ownedAdvancements = new Collection<OwnedAdvancement>();
            foreach (int pointValue in advancementValues)
            {
                //TODO: swap this to a mocked version
                ownedAdvancements.Add(
                    new OwnedAdvancement
                    {
                        Advancement = new Advancement
                        {
                            Points = pointValue
                        }
                    }
                );
            }

            ActiveCiv testCiv = new ActiveCiv {
                AstPosition = astPosition,
                Cities      = cities,
                OwnedAdvancements = ownedAdvancements
            };

            int actualScore = testCiv.GetScore();

            Assert.Equal(expectedScore, actualScore);
        }
        
        //Dataprovider for CanGetTotal<Category>Credit tests
        public static IEnumerable<object[]> AdvancementDiscountData => new List<object[]>
        {
            new object[] { new int[] { },       0 }, //No advancements providing discount
            new object[] { new int[] { 2 },    10 }, //One advancement providing discount
            new object[] { new int[] { 2, 3 }, 20 }  //Two advancements providing discount
        };

        [Theory]
        [MemberData(nameof(AdvancementDiscountData))]
        public void CanGetDiscountForAdvancement(int[] grantors, int expectedDiscount)
        {
            int advancementId = 1;
            Advancement testAdvancement = new Advancement { Id = advancementId };

            Collection<OwnedAdvancement> owned = new Collection<OwnedAdvancement>();
            foreach(int grantor in grantors)
            {
                owned.Add(
                    new OwnedAdvancement {
                        Advancement = new Advancement {
                            Id = grantor,
                            CreditAdvancementId = advancementId,
                            CreditAdvancementValue = 10
                        }
                    }
                );
            }

            ActiveCiv testCiv = new ActiveCiv { OwnedAdvancements = owned };

            int actualDiscount = testCiv.GetDiscountForAdvancement(testAdvancement);

            Assert.Equal(expectedDiscount, actualDiscount);
        }

        //Dataprovider for CanGetTotal<Category>Credit tests
        public static IEnumerable<object[]> CreditData => new List<object[]>
        {
            new object[] { new int[] { }, 0 },      //No advances
            new object[] { new int[] { 5 }, 5 },    //One advance providing 5 credits
            new object[] { new int[] { 5, 10 }, 15} //Two advances, providing 5 and 10 credits, respectively
        };
        
        [Theory]
        [MemberData(nameof(CreditData))]
        public void CanGetTotalArtCredit(int[] artCredits, int expectedTotal)
        {
            CanGetTotalCredit(Advancement.Category.Art, artCredits, expectedTotal);
        }

        [Theory]
        [MemberData(nameof(CreditData))]
        public void CanGetTotalCivicCredit(int[] civicCredits, int expectedTotal)
        {
            CanGetTotalCredit(Advancement.Category.Civic, civicCredits, expectedTotal);
        }

        [Theory]
        [MemberData(nameof(CreditData))]
        public void CanGetTotalCraftCredit(int[] craftCredits, int expectedTotal)
        {
            CanGetTotalCredit(Advancement.Category.Craft, craftCredits, expectedTotal);
        }

        [Theory]
        [MemberData(nameof(CreditData))]
        public void CanGetTotalReligionCredit(int[] religionCredits, int expectedTotal)
        {
            CanGetTotalCredit(Advancement.Category.Religion, religionCredits, expectedTotal);
        }

        [Theory]
        [MemberData(nameof(CreditData))]
        public void CanGetTotalScienceCredit(int[] scienceCredits, int expectedTotal)
        {
            CanGetTotalCredit(Advancement.Category.Science, scienceCredits, expectedTotal);
        }
        
        /*
         * Tests the GetTotal<Category>Credit method. Called by specific test cases above
         */
        private void CanGetTotalCredit(Advancement.Category category, int[] credits, int expectedTotal)
        {
            ActiveCiv testCiv = new ActiveCiv
            {
                //Convert the array of credits into a collection of mocked advancements 
                OwnedAdvancements = PrepareMockOwnedAdvancements(credits, category)
            };

            int actualTotal = -1;
            switch(category)
            {
                case Advancement.Category.Art:
                    actualTotal = testCiv.GetTotalArtCredit();
                    break;
                case Advancement.Category.Civic:
                    actualTotal = testCiv.GetTotalCivicCredit();
                    break;
                case Advancement.Category.Craft:
                    actualTotal = testCiv.GetTotalCraftCredit();
                    break;
                case Advancement.Category.Religion:
                    actualTotal = testCiv.GetTotalReligionCredit();
                    break;
                case Advancement.Category.Science:
                    actualTotal = testCiv.GetTotalScienceCredit();
                    break;
            }

            Assert.Equal(expectedTotal, actualTotal);
        }

        /*
         * Generates a collection of owned advancements with the specified credit values and credit category
         */
        private ICollection<OwnedAdvancement> PrepareMockOwnedAdvancements(int[] credits, Advancement.Category category)
        {
            ICollection<OwnedAdvancement> ownedAdvancements = new Collection<OwnedAdvancement>();
            foreach(int credit in credits)
            {
                //TODO: swap these to mocked versions
                Advancement advancement = new Advancement();
                switch (category)
                {
                    case Advancement.Category.Art:
                        advancement.CreditArt = credit;
                        break;
                    case Advancement.Category.Civic:
                        advancement.CreditCivic = credit;
                        break;
                    case Advancement.Category.Craft:
                        advancement.CreditCraft = credit;
                        break;
                    case Advancement.Category.Religion:
                        advancement.CreditReligion = credit;
                        break;
                    case Advancement.Category.Science:
                        advancement.CreditScience = credit;
                        break;
                }

                ownedAdvancements.Add(
                    new OwnedAdvancement
                    {
                        Advancement = advancement
                    }
                );
            }

            return ownedAdvancements;
        }
    }
}
