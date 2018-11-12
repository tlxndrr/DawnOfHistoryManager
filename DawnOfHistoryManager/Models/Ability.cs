using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DawnOfHistoryManager.Models
{
    public class Ability
    {
        public int         Id            { get; set; }
        [Display(Name = "Advancement ID")]
        public int         AdvancementId { get; set; }
        [ForeignKey("AdvancementId")]
        [Display(Name = "Advancement")]
        public Advancement Advancement   { get; set; }
        [Display(Name = "Rules Text")]
        public string      RulesText     { get; set; }
    }
}
