using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEER
{
    public class Beer
    {
        private string Name;
        private double Price;
        private type BeerType;


        public Beer(string n, double p, type bt)
        {
            Name = n;
            Price = p;
            BeerType = bt;
        }

        public double GetPrice()
        {
            return Price;
        }

        public type GetBeerType()
        {
            return BeerType;
        }
    }
}
