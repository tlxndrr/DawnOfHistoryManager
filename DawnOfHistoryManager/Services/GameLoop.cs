using DawnOfHistoryManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace DawnOfHistoryManager.Services
{
    public class GameLoop
    {
        public GameContext GameContext { get; }
        public ActiveCiv ActiveCiv { get; set; }
        
        public GameLoop(GameContext gameContext, int activeCivId)
        {
            GameContext = gameContext;
            ActiveCiv = GameContext.ActiveCivs.Find(activeCivId);
        }

        //Resolves the Tax To Support phase, which asks for a new cities controlled count
        public void ResolveTaxToSupport(int newCityCount)
        {
            //Update the city count
            ActiveCiv.Cities = newCityCount;

            //Mark the civ as at the next phase
            ActiveCiv.CurrentPhase = (int)ActiveCiv.Phases.CalculateSpendLimit;
            GameContext.SaveChanges();
        }

        //Resolves the Calculate Spend Limit phase
        public void ResolveCalculateSpendLimit(int treasury, Commodity[] cardSets)
        {
            //Calculate the new spending limit
            int SpendingLimit = treasury;
            foreach(Commodity cardSet in cardSets)
            {
                SpendingLimit += cardSet.CalculateTotalValue();
            }
            ActiveCiv.SpendLimit = SpendingLimit;

            //Mark the civ as at the next phase
            ActiveCiv.CurrentPhase = (int)ActiveCiv.Phases.BuyAdvances;
            GameContext.SaveChanges();
        }

        //Resolves the BuyAdvances phase
        public bool ResolveBuyAdvances(int[] newAdvancements)
        {
            //TODO: handle attempts to buy advancements that the player already owns

            //Only mark the advancements as owned if the player can afford them
            bool totalCostUnderSpendLimit = CheckPlayerCanAffordAdvancements(newAdvancements);
            if(totalCostUnderSpendLimit)
            {
                //Update the list of owned advancements
                foreach(int newAdvancementId in newAdvancements)
                {
                    ActiveCiv.OwnedAdvancements.Add(new OwnedAdvancement { AdvancementId = newAdvancementId });
                }
            }
            
            //Mark the civ as at the next phase
            ActiveCiv.CurrentPhase = (int)ActiveCiv.Phases.MoveAST;
            GameContext.SaveChanges();

            return totalCostUnderSpendLimit;
        }

        //Validates that the player can afford the requested advancements
        public bool CheckPlayerCanAffordAdvancements(int[] advancements)
        {
            //Gather discount information
            int artDiscount      = ActiveCiv.GetTotalArtCredit();
            int civicDiscount    = ActiveCiv.GetTotalCivicCredit();
            int craftDiscount    = ActiveCiv.GetTotalCraftCredit();
            int religionDiscount = ActiveCiv.GetTotalReligionCredit();
            int scienceDiscount  = ActiveCiv.GetTotalScienceCredit();
            int specificDiscount = 0;

            int totalPrice = 0;

            //For each advancement the player wishes to buy...
            foreach (int advancementId in advancements)
            {
                Advancement candidateAdvance = GameContext.Advancements.Find(advancementId);

                //Get any discounts for specifically this advance
                specificDiscount = ActiveCiv.GetDiscountForAdvancement(candidateAdvance);

                totalPrice += candidateAdvance.GetDiscountedPrice(
                    artDiscount,
                    civicDiscount,
                    craftDiscount,
                    religionDiscount,
                    scienceDiscount,
                    specificDiscount
                );
            }

            //Return whether the total price is less than or equal to the spending limit
            return totalPrice <= ActiveCiv.SpendLimit;
        }
        
        //Resolves the Move AST phase
        public int ResolveMoveAst()
        {
            int ASTChange = 0; //The AST only changes if it advances or regresses

            /* 
             * Advance the AST one space if we meet the requirements for the next space and we aren't at the end of the chart
             * Requirements:
             * -In the Stone Age:        no requirements
             * -In the Early Bronze Age: own 2 cities
             * -In the Late Bronze Age:  own 3 cities and have at least three advancements
             * -In the Early Iron Age:   own 4 cities and have at least three advancements that are worth at least 2 points each
             * -In the Late Iron Age:    own 5 cities and have at least three advancements that are worth at 3 points each
             */
            Civ.Eras era = ActiveCiv.Civ.GetEraEnumForAstPosition(ActiveCiv.AstPosition + 1);
            int advances          = ActiveCiv.OwnedAdvancements.Count;
            int midValueAdvances  = ActiveCiv.OwnedAdvancements.Where(p => p.Advancement.Points >= 2).Count();
            int highValueAdvances = ActiveCiv.OwnedAdvancements.Where(p => p.Advancement.Points == 3).Count();
            
            if (
                    era == Civ.Eras.Stone
                || (era == Civ.Eras.EarlyBronze && ActiveCiv.Cities >= 2)
                || (era == Civ.Eras.LateBronze  && ActiveCiv.Cities >= 3 && advances >= 3)
                || (era == Civ.Eras.EarlyIron   && ActiveCiv.Cities >= 4 && midValueAdvances >= 3)
                || (era == Civ.Eras.LateIron    && ActiveCiv.Cities >= 5 && highValueAdvances >= 3)
            ) {
                ActiveCiv.AstPosition++;
                ASTChange = 1;
            }

            //Regress the AST one space if we are not in the stone age have have no cities
            if (ActiveCiv.AstPosition > ActiveCiv.Civ.AstStone && ActiveCiv.Cities == 0)
            {
                ActiveCiv.AstPosition--;
                ASTChange = -1;
            }

            GameContext.SaveChanges();

            return ASTChange; //Positive value indicates advancement, negative value indicates regression, 0 indicates no change
        }

        //Checks whether the game should end or continue this turn
        public bool CheckForGameEnd()
        {
            //If the active civ is at the last space of the Late Iron Age, the game ends. For all standardcivilizations, this is space 16
            if(ActiveCiv.AstPosition >= ActiveCiv.Civ.AstLateIron)
            {
                return true;
            }

            //If the game hasn't ended, mark the civ's current phase as the first phase for the next turn
            ActiveCiv.CurrentPhase = (int)ActiveCiv.Phases.TaxToSupport;

            GameContext.SaveChanges();

            return false;
        }
    }
}
