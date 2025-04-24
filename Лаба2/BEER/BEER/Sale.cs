using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEER
{
    public class Sale
    {
        private Beer Beer;
        private int Quantity;
        private int Day;

        public Sale(Beer beer, int quantity, int day)
        {
            Beer = beer;
            Quantity = quantity;
            Day = day;
        }

        public Beer GetBeer()
        {
            return Beer;
        }

        public int GetQuantity()
        {
            return Quantity;
        }

        public int GetDay()
        {
            return Day;
        }
    }
}
