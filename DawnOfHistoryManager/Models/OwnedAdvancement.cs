using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DawnOfHistoryManager.Models
{
    public class OwnedAdvancement
    {
        public int Id { get; set; }

        [ForeignKey("ActiveCivId")]
        public ActiveCiv ActiveCiv   { get; set; }
        public int       ActiveCivId { get; set; }

        [ForeignKey("AdvancementId")]
        public Advancement Advancement   { get; set; }
        public int         AdvancementId { get; set; }
    }
}
