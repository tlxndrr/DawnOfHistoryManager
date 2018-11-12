using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DawnOfHistoryManager.Services
{
    //Represents a set of identical commodity cards
    public class Commodity
    {
        int Value    { get; set; }
        int Quantity { get; set; }

        public Commodity(int value, int quantity)
        {
            Value = value;
            Quantity = quantity;
        }

        //Return the total value of the commodity set
        public int CalculateTotalValue()
        {
            return Value * (int)Math.Pow(Quantity, 2);
        }
    }
}
