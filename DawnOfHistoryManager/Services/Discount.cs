using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DawnOfHistoryManager.Services
{
    /* Ties together an advancement's category with the applicable credit
     * Used by Advancement when calculating its discounted price
     */
    public class Discount
    {
        public bool IsCategory { get; set; }
        public int Credit { get; set; }
    }
}
