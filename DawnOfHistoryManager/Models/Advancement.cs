using DawnOfHistoryManager.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DawnOfHistoryManager.Models
{
    public class Advancement
    {
        public enum Category { Art, Civic, Craft, Religion, Science };

        //Basic information
        public int    Id       { get; set; }
        public string Name     { get; set; }
        [Display(Name="Base Cost")]
        public int    BaseCost { get; set; }
        [Display(Name = "Points")]
        public int    Points   { get; set; }

        //Categorization
        [Display(Name = "Art")]
        public bool IsArt      { get; set; }
        [Display(Name = "Civic")]
        public bool IsCivic    { get; set; }
        [Display(Name = "Craft")]
        public bool IsCraft    { get; set; }
        [Display(Name = "Religion")]
        public bool IsReligion { get; set; }
        [Display(Name = "Science")]
        public bool IsScience  { get; set; }

        //Advancement Credits Provided - Categories
        [Display(Name = "Art Credit")]
        public int CreditArt      { get; set; }
        [Display(Name = "Civic Credit")]
        public int CreditCivic    { get; set; }
        [Display(Name = "Craft Credit")]
        public int CreditCraft    { get; set; }
        [Display(Name = "Religion Credit")]
        public int CreditReligion { get; set; }
        [Display(Name = "Science Credit")]
        public int CreditScience  { get; set; }

        //Advancement Credits Provided - Specific Advancement
        [ForeignKey("CreditAdvancementId")]
        [Display(Name = "Advancement Credit")]
        public Advancement CreditAdvancement      { get; set; }
        [Display(Name = "Advancement Credit ID")]
        public int?        CreditAdvancementId    { get; set; }
        [Display(Name = "Adv. Credit Value")]
        public int?        CreditAdvancementValue { get; set; }

        //Other related objects
        public ICollection<Ability>          Abilities { get; set; }
        public ICollection<OwnedAdvancement> OwnedAdvancements { get; set; }

        //Calculated value
        public int GetDiscountedPrice(
            int artCredit,
            int civicCredit,
            int craftCredit,
            int religionCredit,
            int scienceCredit,
            int specificCredit = 0
        )
        {
            //Start with the base cost, and subtract the advancement-specific credit
            int discountedPrice = BaseCost - specificCredit;

            //Apply each of the discounts that apply to this particular advance
            Discount[] discounts = new Discount[] {
                new Discount { IsCategory = IsArt,      Credit = artCredit },
                new Discount { IsCategory = IsCivic,    Credit = civicCredit },
                new Discount { IsCategory = IsCraft,    Credit = craftCredit },
                new Discount { IsCategory = IsReligion, Credit = religionCredit },
                new Discount { IsCategory = IsScience,  Credit = scienceCredit },
            };

            foreach(Discount discount in discounts)
            {
                if(discount.IsCategory)
                {
                    discountedPrice -= discount.Credit;
                }
            }
            
            //The discounted price cannot be less than 0
            return Math.Max(discountedPrice, 0);
        }
    }
}
