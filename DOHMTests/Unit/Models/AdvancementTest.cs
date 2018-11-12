using DawnOfHistoryManager.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DOHMTests.Unit.Models
{
    public class AdvancementTest
    {
        //Dataprovider for CanGetScore test
        public static IEnumerable<object[]> DiscountData => new List<object[]>
        {
            new object[] { //No discounts
                80,
                new bool[] { true, false, false, false, false },
                new int[] { 0, 0, 0, 0, 0, 0 },
                80
            },
            new object[] { //Sufficient discounts to push final cost below 0
                80,
                new bool[] { true, false, false, false, false },
                new int[] { 100, 0, 0, 0, 0, 0 },
                0
            },
            new object[] { //Discount in relevant category
                80,
                new bool[] { true, false, false, false, false },
                new int[] { 30, 0, 0, 0, 0, 0 },
                50
            },
            new object[] { //Discount in irrelevant category
                80,
                new bool[] { true, false, false, false, false },
                new int[] { 0, 0, 0, 20, 0, 0 },
                80
            },
            new object[] { //Discount in multiple relevant category
                80,
                new bool[] { true, false, false, true, false },
                new int[] { 40, 0, 0, 20, 0, 0 },
                20
            },
            new object[] { //Discount specific to advancement
                80,
                new bool[] { true, false, false, false, false },
                new int[] { 0, 0, 0, 0, 0, 25 },
                55
            },
        };

        [Theory]
        [MemberData(nameof(DiscountData))]
        public void CanGetDiscountedPrice(int baseCost, bool[] categories, int[] discounts, int expectedPrice)
        {
            Advancement advancement = new Advancement
            {
                BaseCost = baseCost,
                IsArt      = categories[0],
                IsCivic    = categories[1],
                IsCraft    = categories[2],
                IsReligion = categories[3],
                IsScience  = categories[4],
            };

            int actualPrice = advancement.GetDiscountedPrice(
                discounts[0],
                discounts[1],
                discounts[2],
                discounts[3],
                discounts[4],
                discounts[5]
            );

            Assert.Equal(expectedPrice, actualPrice);
        }
    }
}
