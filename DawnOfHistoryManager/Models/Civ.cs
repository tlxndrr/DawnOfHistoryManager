using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DawnOfHistoryManager.Models
{
    public class Civ
    {
        public const string StoneAge = "Stone Age";
        public const string EarlyBronze = "Early Bronze Age";
        public const string LateBronze = "Late Bronze Age";
        public const string EarlyIron = "Early Iron Age";
        public const string LateIron = "Late Iron Age";

        public enum Eras { Stone, EarlyBronze, LateBronze, EarlyIron, LateIron };

        public int    Id             { get; set; }
        public string Name           { get; set; }
        [Display(Name = "End of Stone Age")]
        public int    AstStone       { get; set; }
        [Display(Name = "End of Early Bronze Age")]
        public int    AstEarlyBronze { get; set; }
        [Display(Name = "End of Late Bronze Age")]
        public int    AstLateBronze  { get; set; }
        [Display(Name = "End of Early Iron Age")]
        public int    AstEarlyIron   { get; set; }
        [Display(Name = "End of Late Iron Age")]
        public int    AstLateIron    { get; set; }

        public ICollection<ActiveCiv> ActiveCivs { get; set; }

        public string GetEraNameForAstPosition(int position)
        {
            //Work from latest to earliest era
            if (position > AstEarlyIron)
            {
                return LateIron;
            }

            if (position > AstLateBronze)
            {
                return EarlyIron;
            }

            if (position > AstEarlyBronze)
            {
                return LateBronze;
            }

            if (position > AstStone)
            {
                return EarlyBronze;
            }

            return StoneAge;
        }

        public Eras GetEraEnumForAstPosition(int position)
        {

            //Work from latest to earliest era
            if (position > AstEarlyIron)
            {
                return Eras.LateIron;
            }

            if (position > AstLateBronze)
            {
                return Eras.EarlyIron;
            }

            if (position > AstEarlyBronze)
            {
                return Eras.LateBronze;
            }

            if (position > AstStone)
            {
                return Eras.EarlyBronze;
            }

            return Eras.Stone;
        }
    }
}
