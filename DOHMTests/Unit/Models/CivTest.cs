using DawnOfHistoryManager.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xunit;

namespace DOHMTests.Unit.Models
{
    /* 
     * Contatins tests for calcuated data in the ActiveCiv class
     */
    public class CivTest
    {
        //Dataprovider for CanGetEraNameForAstPosition test
        public static IEnumerable<object[]> AstPositionDataName => new List<object[]>
        {
            new object[] { 5, Civ.StoneAge },    //Last space of Stone Age
            new object[] { 6, Civ.EarlyBronze }, //First space of Early Bronze Age
            new object[] { 8, Civ.EarlyBronze }, //Last space of Early Bronze Age
            new object[] { 9, Civ.LateBronze },  //First space of Late Bronze Age
            new object[] { 11, Civ.LateBronze }, //Last space of Late Bronze Age
            new object[] { 12, Civ.EarlyIron },  //First space of Early Iron Age
            new object[] { 14, Civ.EarlyIron },  //Last space of Early Iron Age
            new object[] { 15, Civ.LateIron },   //First space of Late Iron Age
        };
        
        [Theory]
        [MemberData(nameof(AstPositionDataName))]
        public void CanGetEraNameForAstPosition(int astPosition, string expectedEra)
        {
            Civ testCiv = new Civ { AstStone = 5, AstEarlyBronze = 8, AstLateBronze = 11, AstEarlyIron = 14 };

            string actualEra = testCiv.GetEraNameForAstPosition(astPosition);

            Assert.Equal(expectedEra, actualEra);
        }

        //Dataprovider for CanGetEraEnumForAstPosition test
        public static IEnumerable<object[]> AstPositionDataEnum => new List<object[]>
        {
            new object[] { 5, (int)Civ.Eras.Stone },       //Last space of Stone Age
            new object[] { 6, (int)Civ.Eras.EarlyBronze }, //First space of Early Bronze Age
            new object[] { 8, (int)Civ.Eras.EarlyBronze }, //Last space of Early Bronze Age
            new object[] { 9, (int)Civ.Eras.LateBronze },  //First space of Late Bronze Age
            new object[] { 11, (int)Civ.Eras.LateBronze }, //Last space of Late Bronze Age
            new object[] { 12, (int)Civ.Eras.EarlyIron },  //First space of Early Iron Age
            new object[] { 14, (int)Civ.Eras.EarlyIron },  //Last space of Early Iron Age
            new object[] { 15, (int)Civ.Eras.LateIron },   //First space of Late Iron Age
        };

        [Theory]
        [MemberData(nameof(AstPositionDataEnum))]
        public void CanGetEraEnumForAstPosition(int astPosition, int expectedEra)
        {
            Civ testCiv = new Civ { AstStone = 5, AstEarlyBronze = 8, AstLateBronze = 11, AstEarlyIron = 14 };

            int actualEra = (int)testCiv.GetEraEnumForAstPosition(astPosition);

            Assert.Equal(expectedEra, actualEra);
        }
    }
}
