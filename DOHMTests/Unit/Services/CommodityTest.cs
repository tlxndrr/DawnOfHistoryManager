using DawnOfHistoryManager.Services;
using System.Collections.Generic;
using Xunit;

namespace DOHMTests.Unit.Services
{
    public class CommodityTest
    {
        //Dataprovider for CanCalculateTotalValue test
        public static IEnumerable<object[]> CommodityData => new List<object[]>
        {
            new object[] { 1, 1, 1 },  //Single 1
            new object[] { 5, 1, 5 },  //Single 5
            new object[] { 1, 2, 4 },  //Pair of 1s
            new object[] { 4, 3, 36 }, //Triple 4s
        };

        [Theory]
        [MemberData(nameof(CommodityData))]
        public void CanCalculateTotalValue(int value, int quantity, int expectedTotal)
        {
            Commodity testCommodity = new Commodity(value, quantity);

            int actualTotal = testCommodity.CalculateTotalValue();

            Assert.Equal(expectedTotal, actualTotal);
        }
    }
}
