using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DawnOfHistoryManager.Models
{
    public class ActiveCiv
    {
        public enum Phases { TaxToSupport, CalculateSpendLimit, BuyAdvances, MoveAST };

        private const int AstPointValue = 5;

        public int Id { get; set; }

        //User
        //TODO: tie Active Civs to their users
        
        [ForeignKey("CivId")]
        [Display(Name = "Civilization")]
        public Civ Civ   { get; set; }
        [Display(Name = "Civilization ID")]
        public int CivId { get; set; }

        public ICollection<OwnedAdvancement> OwnedAdvancements { get; set; }

        //Other data
        [Display(Name = "Game Name")]
        public string GameName  { get; set; }
        [Range(0,9)]
        [Display(Name = "Cities Owned")]
        public int Cities       { get; set; }
        [Display(Name = "AST Status")]
        public int AstPosition  { get; set; }
        [Range(0,3)]
        [Display(Name = "Current Phase")]
        public int CurrentPhase { get; set; }
        [Display(Name = "Spending Limit")]
        public int SpendLimit   { get; set; }

        //Calculated data

        /* Calculates the current score, composed of:
         * -The points value of the current position on the AST (Usually position * 5)
         * -The number of cities controlled
         * -The total point value of all owned advancements
         */
        public int GetScore()
        {
            int score = (AstPointValue * AstPosition) + Cities;

            //TODO: swap loop out for a proper map/reduce construct
            foreach (OwnedAdvancement ownedAdvancement in OwnedAdvancements)
            {
                score += ownedAdvancement.Advancement.Points;
            }

            return score;
        }

        public int GetDiscountForAdvancement(Advancement advancement)
        {
            int discount = 0;

            //For each owned advancement which grants credit toward the requested advancement...
            List<OwnedAdvancement> grantors = OwnedAdvancements.Where(a => a.Advancement.CreditAdvancementId == advancement.Id).ToList();
            foreach(OwnedAdvancement grantor in grantors)
            {
                //...increase the total discount by that owned advancement's credit value
                discount += grantor.Advancement.CreditAdvancementValue ?? 0;
            }

            return discount;
        }

        public int GetTotalArtCredit()
        {
            return GetTotalCredit(Advancement.Category.Art);
        }

        public int GetTotalCivicCredit()
        {
            return GetTotalCredit(Advancement.Category.Civic);
        }
        public int GetTotalCraftCredit()
        {
            return GetTotalCredit(Advancement.Category.Craft);
        }
        public int GetTotalReligionCredit()
        {
            return GetTotalCredit(Advancement.Category.Religion);
        }
        public int GetTotalScienceCredit()
        {
            return GetTotalCredit(Advancement.Category.Science);
        }

        private int GetTotalCredit(Advancement.Category category)
        {
            int totalCredit = 0;
            //TODO: swap loop out for a proper map/reduce construct
            foreach (OwnedAdvancement ownedAdvancement in OwnedAdvancements)
            {
                switch(category)
                {
                    case Advancement.Category.Art:
                        totalCredit += ownedAdvancement.Advancement.CreditArt;
                        break;
                    case Advancement.Category.Civic:
                        totalCredit += ownedAdvancement.Advancement.CreditCivic;
                        break;
                    case Advancement.Category.Craft:
                        totalCredit += ownedAdvancement.Advancement.CreditCraft;
                        break;
                    case Advancement.Category.Religion:
                        totalCredit += ownedAdvancement.Advancement.CreditReligion;
                        break;
                    case Advancement.Category.Science:
                        totalCredit += ownedAdvancement.Advancement.CreditScience;
                        break;
                }
            }

            return totalCredit;
        }
    }
}
