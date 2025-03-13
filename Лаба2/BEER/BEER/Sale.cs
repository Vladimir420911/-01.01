using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEER
{
    public class Sale
    {
        public Beer Beer;
        public int Quantity;
        public string Day;

        public Sale(Beer beer, int quantity, string day)
        {
            Beer = beer;
            Quantity = quantity;
            Day = day;
        }
    }
}
